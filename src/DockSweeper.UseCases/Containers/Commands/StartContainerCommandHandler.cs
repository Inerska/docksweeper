// // Copyright (c) Alexis Chân Gridel. All Rights Reserved.
// // Licensed under the GNU General Public License v3.0.
// // See the LICENSE file in the project root for more information.

namespace DockSweeper.UseCases.Containers.Commands;

using Docker.DotNet.Models;
using DockSweeper.Application.Abstractions.Docker;
using MediatR;

public class StartContainerCommandHandler
    : IRequestHandler<StartContainerCommand, bool>
{
    private readonly IDockerClientFactory _dockerClientFactory;

    public StartContainerCommandHandler(IDockerClientFactory dockerClientFactory)
    {
        _dockerClientFactory = dockerClientFactory;
    }

    public async Task<bool> Handle(StartContainerCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.ContainerId))
        {
            return false;
        }

        var client = _dockerClientFactory.GetDockerClient();
        var started = await client.Containers.StartContainerAsync(
            request.ContainerId,
            new ContainerStartParameters(),
            cancellationToken);

        return started;
    }
}
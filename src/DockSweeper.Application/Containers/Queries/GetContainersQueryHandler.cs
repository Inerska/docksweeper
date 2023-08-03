// // Copyright (c) Alexis Chân Gridel. All Rights Reserved.
// // Licensed under the GNU General Public License v3.0.
// // See the LICENSE file in the project root for more information.

using Docker.DotNet.Models;
using DockSweeper.Application.Abstractions.Docker;
using LanguageExt;
using MediatR;

namespace DockSweeper.Application.Containers.Queries;

public class GetContainersQueryHandler
    : IRequestHandler<GetContainersQuery, Option<IEnumerable<ContainerListResponse>>>
{
    private readonly IDockerClientFactory _dockerClientFactory;

    public GetContainersQueryHandler(IDockerClientFactory dockerClientFactory)
    {
        _dockerClientFactory = dockerClientFactory;
    }

    public async Task<Option<IEnumerable<ContainerListResponse>>> Handle(
        GetContainersQuery request,
        CancellationToken cancellationToken)
    {
        var dockerClient = _dockerClientFactory.GetDockerClient();

        var filters = request.All
            ? null
            : new Dictionary<string, IDictionary<string, bool>>
            {
                {
                    "status", new Dictionary<string, bool>
                    {
                        { "running", true }
                    }
                }
            };

        var containers = await dockerClient.Containers.ListContainersAsync(
            new ContainersListParameters
            {
                Limit = request.Limit,
                Filters = filters
            },
            cancellationToken);

        return containers.Any()
            ? Option<IEnumerable<ContainerListResponse>>.Some(containers)
            : Option<IEnumerable<ContainerListResponse>>.None;
    }
}
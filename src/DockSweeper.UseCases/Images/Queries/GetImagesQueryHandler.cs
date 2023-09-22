// Copyright (c) Alexis Chân Gridel. All Rights Reserved.
// Licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using Docker.DotNet.Models;
using DockSweeper.Application.Abstractions.Docker;
using MediatR;

namespace DockSweeper.UseCases.Images.Queries;

public sealed class GetImagesQueryHandler
    : IRequestHandler<GetImagesQuery, IEnumerable<ImagesListResponse>>
{
    private readonly IDockerClientFactory _dockerClientFactory;

    public GetImagesQueryHandler(IDockerClientFactory dockerClientFactory)
    {
        _dockerClientFactory = dockerClientFactory;
    }

    public async Task<IEnumerable<ImagesListResponse>> Handle(
        GetImagesQuery request,
        CancellationToken cancellationToken)
    {
        var dockerClient = _dockerClientFactory.GetDockerClient();

        var images = await dockerClient.Images.ListImagesAsync(
            new ImagesListParameters
            {
                All = request.All
            },
            cancellationToken);

        return images ?? new List<ImagesListResponse>();
    }
}
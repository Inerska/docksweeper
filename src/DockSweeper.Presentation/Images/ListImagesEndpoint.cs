// Copyright (c) Alexis Chân Gridel. All Rights Reserved.
// Licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using System.ComponentModel.DataAnnotations;
using System.Globalization;
using DockSweeper.UseCases.Images.Queries;
using FastEndpoints;
using MediatR;

namespace DockSweeper.Presentation.Images;

public sealed class ListImagesEndpoint
    : Endpoint<ListImagesEndpointRequest, ListImagesEndpointResponse>
{
    private readonly ILogger<ListImagesEndpoint> _logger;
    private readonly IMediator _mediator;

    public ListImagesEndpoint(
        IMediator mediator,
        ILogger<ListImagesEndpoint> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    public override void Configure()
    {
        Get("/api/images");
        AllowAnonymous();
    }

    public override async Task HandleAsync(ListImagesEndpointRequest req, CancellationToken ct)
    {
        var images = await _mediator.Send(
            new GetImagesQuery(req.Limit, req.All),
            ct);

        var imageListResponses = images.ToList();

        Response = new ListImagesEndpointResponse
        {
            Images = imageListResponses.Select(image =>
                    new ImageRecord(
                        image.ID,
                        image.RepoTags,
                        image.Created.ToString(CultureInfo.InvariantCulture),
                        image.Size))
                .ToList()
        };

        _logger.LogInformation("Got {Count} docker images", req.Limit);
    }
}

public sealed class ListImagesEndpointRequest
{
    [Range(1, 100)]
    public int Limit { get; init; } = 10;

    public bool All { get; init; } = false;
}

public sealed class ListImagesEndpointResponse
{
    public List<ImageRecord> Images { get; init; } = new();
}
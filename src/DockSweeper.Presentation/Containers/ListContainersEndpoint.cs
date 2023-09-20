// Copyright (c) Alexis Chân Gridel. All Rights Reserved.
// Licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using System.ComponentModel.DataAnnotations;
using System.Globalization;
using DockSweeper.UseCases.Containers.Queries;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace DockSweeper.Presentation.Containers;

public sealed class ListContainersEndpoint
    : Endpoint<ListContainersEndpointRequest, ListContainersEndpointResponse>
{
    private readonly ILogger<ListContainersEndpoint> _logger;
    private readonly IMediator _mediator;

    public ListContainersEndpoint(
        IMediator mediator,
        ILogger<ListContainersEndpoint> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    public override void Configure()
    {
        Get("/api/containers");
        AllowAnonymous();
    }

    public override async Task HandleAsync(
        ListContainersEndpointRequest req,
        CancellationToken ct)
    {
        var containers = await _mediator.Send(
            new GetContainersQuery(req.Limit, req.All),
            ct);

        var containerListResponses = containers.ToList();
        _logger.LogInformation("Got {Count} docker containers", containerListResponses.Count);

        Response = new ListContainersEndpointResponse
        {
            Containers = containerListResponses.Select(c =>
                    new ContainerRecord(
                        c.ID,
                        c.Names,
                        c.Image,
                        c.Command,
                        c.Created.ToString(CultureInfo.InvariantCulture),
                        c.State))
                .ToList()
        };
    }
}

public sealed class ListContainersEndpointRequest
{
    [Range(1, 100)] public int Limit { get; init; } = 10;

    public bool All { get; init; } = false;
}

public sealed class ListContainersEndpointResponse
{
    public List<ContainerRecord> Containers { get; init; } = new();
}
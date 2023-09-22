// Copyright (c) Alexis Chân Gridel. All Rights Reserved.
// Licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using System.Globalization;
using DockSweeper.UseCases.Networks.Queries;
using FastEndpoints;
using MediatR;

namespace DockSweeper.Presentation.Networks;

public sealed class ListNetworksEndpoint
    : Endpoint<ListNetworksEndpointRequest, ListNetworksEndpointResponse>
{
    private readonly ILogger<ListNetworksEndpoint> _logger;
    private readonly IMediator _mediator;

    public ListNetworksEndpoint(
        IMediator mediator,
        ILogger<ListNetworksEndpoint> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    public override async Task HandleAsync(ListNetworksEndpointRequest req, CancellationToken ct)
    {
        var networks = await _mediator.Send(
            new GetNetworksQuery(req.All),
            ct);

        var networkListResponses = networks.ToList();

        _logger.LogInformation("Got {Count} docker networks", networkListResponses.Count);

        Response = new ListNetworksEndpointResponse
        {
            Networks = networkListResponses.Select(network =>
                    new NetworkRecord(
                        network.ID,
                        network.Name,
                        network.Driver,
                        network.Scope,
                        network.Created.ToString(CultureInfo.InvariantCulture)))
                .ToList()
        };
    }

    public override void Configure()
    {
        Get("/api/networks");
        AllowAnonymous();
    }
}

public sealed class ListNetworksEndpointRequest
{
    public bool All { get; set; } = false;
}

public sealed class ListNetworksEndpointResponse
{
    public IEnumerable<NetworkRecord> Networks { get; set; } = Enumerable.Empty<NetworkRecord>();
}
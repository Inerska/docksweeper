// Copyright (c) Alexis Chân Gridel. All Rights Reserved.
// Licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using Docker.DotNet;
using Docker.DotNet.Models;
using DockSweeper.Application.Abstractions.Docker;
using MediatR;

namespace DockSweeper.UseCases.Networks.Queries;

public sealed class GetNetworksQueryHandler
    : IRequestHandler<GetNetworksQuery, IEnumerable<NetworkListResponse>>
{
    private readonly IDockerClientFactory _dockerClientFactory;

    public GetNetworksQueryHandler(
        IDockerClientFactory dockerClientFactory)
    {
        _dockerClientFactory = dockerClientFactory;
    }

    public async Task<IEnumerable<NetworkListResponse>> Handle(
        GetNetworksQuery request,
        CancellationToken cancellationToken)
    {
        var client = _dockerClientFactory.GetDockerClient();
        
        var networks = await client.Networks.ListNetworksAsync(
            new NetworksListParameters
            {
                Filters = request.All
                    ? null
                    : new Dictionary<string, IDictionary<string, bool>>
                    {
                        {
                            "driver", new Dictionary<string, bool>
                            {
                                { "bridge", true }
                            }
                        }
                    }
            },
            cancellationToken);
        
        return networks ?? new List<NetworkListResponse>();
    }
}
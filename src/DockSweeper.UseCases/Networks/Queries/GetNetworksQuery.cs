// Copyright (c) Alexis Chân Gridel. All Rights Reserved.
// Licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using MediatR;

namespace DockSweeper.UseCases.Networks.Queries;

public sealed record GetNetworksQuery(bool All = false)
    : IRequest<IEnumerable<NetworkListResponse>>;
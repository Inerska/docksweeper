// // Copyright (c) Alexis Chân Gridel. All Rights Reserved.
// // Licensed under the GNU General Public License v3.0.
// // See the LICENSE file in the project root for more information.

using Docker.DotNet.Models;
using LanguageExt;
using MediatR;

namespace DockSweeper.Application.Containers.Queries;

public record GetContainersQuery(int Limit, bool All = false)
    : IRequest<Option<IEnumerable<ContainerListResponse>>>;
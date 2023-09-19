// // Copyright (c) Alexis Chân Gridel. All Rights Reserved.
// // Licensed under the GNU General Public License v3.0.
// // See the LICENSE file in the project root for more information.

namespace DockSweeper.UseCases.Containers.Queries;

using Docker.DotNet.Models;
using LanguageExt;
using MediatR;

public record GetContainersQuery(int Limit, bool All = false)
    : IRequest<Option<IEnumerable<ContainerListResponse>>>;
// Copyright (c) Alexis Chân Gridel. All Rights Reserved.
// Licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using Docker.DotNet.Models;
using MediatR;

namespace DockSweeper.UseCases.Images.Queries;

public sealed record GetImagesQuery(int Limit, bool All = false)
    : IRequest<IEnumerable<ImagesListResponse>>;
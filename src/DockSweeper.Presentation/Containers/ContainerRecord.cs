// Copyright (c) Alexis Chân Gridel. All Rights Reserved.
// Licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

namespace DockSweeper.Presentation.Containers;

public record ContainerRecord(
    string Id,
    IList<string> Names,
    string Image,
    string Command,
    string Created,
    string State);
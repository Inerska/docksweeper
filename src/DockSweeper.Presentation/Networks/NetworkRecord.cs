// Copyright (c) Alexis Chân Gridel. All Rights Reserved.
// Licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

namespace DockSweeper.Presentation.Networks;

public sealed record NetworkRecord(
    string Id,
    string Name,
    string Created,
    string Driver,
    string Scope);
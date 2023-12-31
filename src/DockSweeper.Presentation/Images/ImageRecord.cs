// Copyright (c) Alexis Chân Gridel. All Rights Reserved.
// Licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

namespace DockSweeper.Presentation.Images;

public record ImageRecord(string Id, IList<string> RepoTags, string Created, long Size);
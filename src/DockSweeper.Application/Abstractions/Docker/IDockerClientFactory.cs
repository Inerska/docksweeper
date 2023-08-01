// // Copyright (c) Alexis Chân Gridel. All Rights Reserved.
// // Licensed under the GNU General Public License v3.0.
// // See the LICENSE file in the project root for more information.

using Docker.DotNet;

namespace DockSweeper.Application.Abstractions.Docker;

public interface IDockerClientFactory
{
    public DockerClient GetDockerClient();
}
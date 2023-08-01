using Docker.DotNet;

namespace DockSweeper.Application.Abstractions.Docker;

public interface IDockerClientFactory
{
    public DockerClient GetDockerClient();
}
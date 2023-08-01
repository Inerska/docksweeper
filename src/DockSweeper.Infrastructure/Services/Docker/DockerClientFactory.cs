using Docker.DotNet;
using DockSweeper.Application.Abstractions;
using DockSweeper.Application.Abstractions.Docker;
using DockSweeper.Infrastructure.Exceptions;

namespace DockSweeper.Infrastructure.Services.Docker;

public class DockerClientFactory
    : IDockerClientFactory
{
    private readonly IOperatingSystemService _operatingSystemService;

    public DockerClientFactory(IOperatingSystemService operatingSystemService)
    {
        _operatingSystemService = operatingSystemService;
    }

    public DockerClient GetDockerClient()
    {
        return _operatingSystemService switch
        {
            { IsWsl: true } => new DockerClientConfiguration(new Uri("npipe://./pipe/docker_engine"))
                .CreateClient(),
            { IsWindows: true } => new DockerClientConfiguration(new Uri("npipe://./pipe/docker_engine"))
                .CreateClient(),
            { IsLinux: true } => new DockerClientConfiguration(new Uri("unix:///var/run/docker.sock"))
                .CreateClient(),
            { IsMacOs: true } => new DockerClientConfiguration(new Uri("unix:///var/run/docker.sock"))
                .CreateClient(),
            _ => throw new UnsupportedOperatingSystemException()
        };
    }
}
// // Copyright (c) Alexis Chân Gridel. All Rights Reserved.
// // Licensed under the GNU General Public License v3.0.
// // See the LICENSE file in the project root for more information.

using DockSweeper.Application.Abstractions;
using DockSweeper.Infrastructure.Exceptions;
using DockSweeper.Infrastructure.Services.Docker;
using Moq;

namespace DockerSweeper.Infrastrcture.Tests;

public class DockerClientFactoryTests
{
    [Fact]
    public void GetDockerClient_WhenWindows_ReturnsWindowsClient()
    {
        // Arrange
        var mockOsService = new Mock<IOperatingSystemService>();
        mockOsService.Setup(x => x.IsWindows).Returns(true);
        var factory = new DockerClientFactory(mockOsService.Object);

        // Act
        var client = factory.GetDockerClient();

        // Assert
        Assert.Equal("npipe://./pipe/docker_engine", client.Configuration.EndpointBaseUri.AbsoluteUri);
    }

    [Fact]
    public void GetDockerClient_WhenLinux_ReturnsLinuxClient()
    {
        // Arrange
        var mockOsService = new Mock<IOperatingSystemService>();
        mockOsService.Setup(x => x.IsLinux).Returns(true);
        var factory = new DockerClientFactory(mockOsService.Object);

        // Act
        var client = factory.GetDockerClient();

        // Assert
        Assert.Equal("unix:///var/run/docker.sock", client.Configuration.EndpointBaseUri.AbsoluteUri);
    }

    [Fact]
    public void GetDockerClient_WhenMacOs_ReturnsMacOsClient()
    {
        // Arrange
        var mockOsService = new Mock<IOperatingSystemService>();
        mockOsService.Setup(x => x.IsMacOs).Returns(true);
        var factory = new DockerClientFactory(mockOsService.Object);

        // Act
        var client = factory.GetDockerClient();

        // Assert
        Assert.Equal("unix:///var/run/docker.sock", client.Configuration.EndpointBaseUri.AbsoluteUri);
    }

    [Fact]
    public void GetDockerClient_WhenUnsupportedOS_ThrowsException()
    {
        // Arrange
        var mockOsService = new Mock<IOperatingSystemService>();
        mockOsService.Setup(x => x.IsWindows).Returns(false);
        mockOsService.Setup(x => x.IsLinux).Returns(false);
        mockOsService.Setup(x => x.IsMacOs).Returns(false);
        var factory = new DockerClientFactory(mockOsService.Object);

        // Act & Assert
        Assert.Throws<UnsupportedOperatingSystemException>(() => factory.GetDockerClient());
    }

    [Fact]
    public void GetDockerClient_WhenWsl_ReturnsWslClient()
    {
        // Arrange
        var mockOsService = new Mock<IOperatingSystemService>();
        mockOsService.Setup(x => x.IsWsl).Returns(true);
        var factory = new DockerClientFactory(mockOsService.Object);

        // Act
        var client = factory.GetDockerClient();

        // Assert
        Assert.Equal("npipe://./pipe/docker_engine", client.Configuration.EndpointBaseUri.AbsoluteUri);
    }
}
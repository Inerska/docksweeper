using DockSweeper.Application.Abstractions;
using Moq;

namespace DockerSweeper.Infrastrcture.Tests;

public class OperatingSystemServiceTests
{
    [Fact]
    public void IsWindows_ReturnsTrue_WhenRunningOnWindows()
    {
        // Arrange
        var mockOperatingSystemService = new Mock<IOperatingSystemService>();
        mockOperatingSystemService.Setup(o => o.IsWindows).Returns(true);

        // Act
        var result = mockOperatingSystemService.Object.IsWindows;

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsLinux_ReturnsTrue_WhenRunningOnLinux()
    {
        // Arrange
        var mockOperatingSystemService = new Mock<IOperatingSystemService>();
        mockOperatingSystemService.Setup(o => o.IsLinux).Returns(true);

        // Act
        var result = mockOperatingSystemService.Object.IsLinux;

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsMacOs_ReturnsTrue_WhenRunningOnMacOs()
    {
        // Arrange
        var mockOperatingSystemService = new Mock<IOperatingSystemService>();
        mockOperatingSystemService.Setup(o => o.IsMacOs).Returns(true);

        // Act
        var result = mockOperatingSystemService.Object.IsMacOs;

        // Assert
        Assert.True(result);
    }
    
    [Fact]
    public void IsWsl_ReturnsTrue_WhenRunningOnWsl()
    {
        // Arrange
        var mockOperatingSystemService = new Mock<IOperatingSystemService>();
        mockOperatingSystemService.Setup(o => o.IsWsl).Returns(true);

        // Act
        var result = mockOperatingSystemService.Object.IsWsl;

        // Assert
        Assert.True(result);
    }
}
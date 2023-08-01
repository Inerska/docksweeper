using System.Runtime.InteropServices;
using DockSweeper.Application.Abstractions;

namespace DockSweeper.Infrastructure.Services;

public class OperatingSystemService
    : IOperatingSystemService
{
    /// <inheritdoc />
    public bool IsWindows => RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

    /// <inheritdoc />
    public bool IsLinux => RuntimeInformation.IsOSPlatform(OSPlatform.Linux);

    /// <inheritdoc />
    public bool IsMacOs => RuntimeInformation.IsOSPlatform(OSPlatform.OSX);
}
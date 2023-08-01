
using DockSweeper.Application.Abstractions;

namespace DockSweeper.Infrastructure.Services;

public class OperatingSystemService
    : IOperatingSystemService
{
    /// <inheritdoc />
    public bool IsWindows { get; }

    /// <inheritdoc />
    public bool IsLinux { get; }

    /// <inheritdoc />
    public bool IsMacOs { get; }
}
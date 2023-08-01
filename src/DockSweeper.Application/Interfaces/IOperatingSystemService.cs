namespace DockSweeper.Application.Interfaces;

public interface IOperatingSystemService
{
    /// <summary>
    ///     Returns true if the operating system is Windows.
    /// </summary>
    bool IsWindows { get; }

    /// <summary>
    ///     Returns true if the operating system is Linux.
    /// </summary>
    bool IsLinux { get; }

    /// <summary>
    ///     Returns true if the operating system is macOS.
    /// </summary>
    bool IsMacOs { get; }
}
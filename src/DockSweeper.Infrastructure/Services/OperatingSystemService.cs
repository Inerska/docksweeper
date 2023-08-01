// // Copyright (c) Alexis Chân Gridel. All Rights Reserved.
// // Licensed under the GNU General Public License v3.0.
// // See the LICENSE file in the project root for more information.

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

    /// <inheritdoc />
    public bool IsWsl
    {
        get
        {
            if (!IsLinux || !File.Exists("/proc/version")) return false;

            var version = File.ReadAllText("/proc/version");
            return version.Contains("Microsoft") || version.Contains("WSL");
        }
    }
}
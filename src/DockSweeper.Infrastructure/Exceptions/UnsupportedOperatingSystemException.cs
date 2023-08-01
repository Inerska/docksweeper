// // Copyright (c) Alexis Chân Gridel. All Rights Reserved.
// // Licensed under the GNU General Public License v3.0.
// // See the LICENSE file in the project root for more information.

namespace DockSweeper.Infrastructure.Exceptions;

public class UnsupportedOperatingSystemException
    : Exception
{
    public UnsupportedOperatingSystemException()
    {
    }

    public UnsupportedOperatingSystemException(string message)
        : base(message)
    {
    }

    public UnsupportedOperatingSystemException(string message, Exception inner)
        : base(message, inner)
    {
    }
}
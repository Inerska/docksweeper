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
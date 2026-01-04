

using System;

namespace DO;

public class ItemNotFoundException : Exception
{
    public ItemNotFoundException(string message)
        : base(message)
    {
        Console.WriteLine( message);
    }
}

public class ItemApperException : Exception
{
    public ItemApperException(string message)
        : base(message)
    {
        Console.WriteLine(message);

    }
}



namespace DO;

[global::System.Serializable]
public class DalItemNotFoundException : global::System.Exception
{
    public DalItemNotFoundException(string message)
        : base(message)
    { }
}

[global::System.Serializable]
public class DalItemAlreadyExistsException : global::System.Exception
{
    public DalItemAlreadyExistsException(string message)
        : base(message)
    { }
}
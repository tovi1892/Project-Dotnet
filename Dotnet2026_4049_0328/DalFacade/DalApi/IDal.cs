

namespace DalApi;

public interface IDal
{
    ISale Sale { get; }
    IProduct Product { get; }
    ICustomer Customer { get; }
}


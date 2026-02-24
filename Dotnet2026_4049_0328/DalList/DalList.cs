
using DalApi;

namespace Dal;

internal sealed class DalList : IDal
{
    private static readonly DalList instance= new DalList(); 

    public ISale Sale => new SaleImplementation();

    public IProduct Product => new ProductImplementation();

    public ICustomer Customer => new CustomerImplementation();



    private DalList()
    {
        
    }
    public static DalList Instance => instance;

}

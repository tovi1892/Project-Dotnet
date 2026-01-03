
using DalApi;
using DO;

namespace Dal;

public class DalList : IDal
{
    public ISale sale => new SaleImplementation();
       

    public IProduct product => new ProductImplementation();

    public ICustomer customer => new CustomerImplementation();

}

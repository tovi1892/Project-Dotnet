using DalApi;
using DO;
namespace DalTest;

public static class Initialization
{
    private static IDal? s_dal;
    public static void Initialize(IDal dal)
    {
        s_dal = dal;
        CreateCustomers();
        CreateProducts();
        CreateSales();
    }
    private static void CreateSales()
    {
        s_dal.Sale.Create(new Sale(1, 1, 1, 1, true, DateTime.Now, DateTime.Now.AddMonths(1)));

    }
    private static void CreateProducts()
    {
        s_dal.Product.Create(new Product(1, "k", Categories.Bracelets, 1, 1));
    }
    private static void CreateCustomers()
    {
        s_dal.Customer.Create(new Customer(2, "ttt", "cccc", "123123"));
    }
}

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
        s_dal.Sale.Create(new Sale(2, 1, 2, 2, false, DateTime.Now, DateTime.Now.AddMonths(1)));
        s_dal.Sale.Create(new Sale(3, 1, 3, 3, true, DateTime.Now, DateTime.Now.AddMonths(1)));
        s_dal.Sale.Create(new Sale(4, 1, 4, 4, false, DateTime.Now, DateTime.Now.AddMonths(1)));    




    }
    private static void CreateProducts()
    {
        s_dal.Product.Create(new Product(1, "Bracelet gold", Categories.Bracelets, 1, 1));
        s_dal.Product.Create(new Product(2, "Earrings silver", Categories.Earrings, 2, 2));
        s_dal.Product.Create(new Product(3, "Necklace diamond", Categories.Necklaces, 3, 3)); 
        s_dal.Product.Create(new Product(4, "Ring platinum", Categories.Rings, 4, 4));  
        s_dal.Product.Create(new Product(5, "Watch rolex", Categories.Watches, 5, 5));  

    }
    private static void CreateCustomers()
    {
        s_dal.Customer.Create(new Customer(2, "tovi", "sde chemed", "0556751892"));
        s_dal.Customer.Create(new Customer(1, "dudi", "tel aviv", "0543216789"));
        s_dal.Customer.Create(new Customer(3, "miki", "haifa", "0529876543"));  
        s_dal.Customer.Create(new Customer(4, "nati", "beer sheva", "0534567891"));
        s_dal.Customer.Create(new Customer(5, "yoni", "eilat", "0512345678"));

    }
}

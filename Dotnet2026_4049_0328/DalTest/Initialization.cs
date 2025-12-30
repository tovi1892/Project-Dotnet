


using DO;
using DalApi;
using DalList;
namespace DalTest;

public static class Initialization
{
    static Sale s_dalSale;
    static Product s_dalProduct;
    static Customer s_dalCustomer;
    public static void  createSale()
    {
        s_dalSale = new Sale();
       
       
    }
    public static void createProduct()
    {
        s_dalProduct = new Product();
        //s_dalProduct.pr



    } 
    public static void createCustomer() {
        s_dalCustomer = new Customer();
    }
}



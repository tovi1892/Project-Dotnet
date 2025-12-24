

namespace DalList//Dal?
{
    static internal class DataSource
    {
        static internal List<Customer?> customers = new  ();
        static internal List<Product?> products = new ();
        static internal List<Sale?> sales = new ();


        internal class Config
        {
            internal const int minProduct=100;
        }



    }
}

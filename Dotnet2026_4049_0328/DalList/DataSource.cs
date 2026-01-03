
using DalFacade;
using DO;

namespace Dal;


internal static class DataSource
{
    internal static List<Product?> Products = new();
    internal static List<Customer?> Customers = new();
    internal static List<Sale?> Sales = new();
    internal static class Config
    {
        internal const int MinIdProduct = 100;
        internal const int MinSaleId = 100;

        private static int _currentProductId = 100;
        private static int _currentSaleId = 100;

        public static int GetNextProductId()
        {
            return _currentProductId++;
        }

        public static int GetNextSaleId()
        {
            return _currentSaleId++;
        }

    }
}



namespace Dal;

static internal class DataSource
{
    static internal List<DO.Customer?> customers = new  ();
    static internal List<DO.Product?> products = new ();
    static internal List<DO.Sale?> sales = new ();

    public static object Sales { get; internal set; }
    public static object Products { get; internal set; }

    internal class Config
    {
        internal const int minProductId=100;
        internal const int minCustomerId = 100;
        internal const int minSaleId = 100;

        internal static int nextProductId=100;
        internal static  int nextCustomerId =100;
        internal static  int nextSaleId = 100; 
        
        int ProductId => ++nextProductId;
        int CustomerId => ++nextCustomerId;
        int SaleId => ++nextSaleId;
    }

 



}

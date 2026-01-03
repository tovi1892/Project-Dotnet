using DO;
using DalApi;
using static Dal.DataSource;

namespace Dal;

internal class SaleImplementation : ISale
{
    public int Creat(Sale item)
    {


        Sale s = item with { SaleId = Config.GetNextProductId() };


        //if (DataSource.Sales.Any(s => s.SaleId == item.SaleId))
        //    throw new DalListException($"Sale with ID {item.SaleId} already exists.");

        Sales.Add(s);
        return item.SaleId;
    }

    public void Delete(int id)
    {
        var sale = Sales.FirstOrDefault(s => s.SaleId == id);
        if (sale == null)
            throw new DalListException($"Sale with ID {id} not found.");

        Sales.Remove(sale);
    }

    public Sale? Read(int id)
    {
        var sale = DataSource.Sales.FirstOrDefault(s => s.SaleId == id);
        if (sale == null)
            throw new DalListException($"Sale with ID {id} not found.");

        return sale;
    }

    public List<Sale> ReadAll()
    {
        return Sales.ToList();
    }

    public void Update(Sale item)
    {
        Sale sale = Sales.FirstOrDefault(s => s.SaleId == item.SaleId) ?? throw new DalListException($"Sale with ID {item.SaleId} not found.");
        sale.ProductId = item.ProductId;
        sale.CustomerId = item.CustomerId;
        sale.Quantity = item.Quantity;
        sale.Date = item.Date;
    }
}

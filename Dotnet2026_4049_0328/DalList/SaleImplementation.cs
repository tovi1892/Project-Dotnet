using DO;
using DalApi;

namespace Dal;

internal class SaleImplementation : ISale
{
    public int Creat(Sale item)
    {
        if (DataSource.Sales.Any(s => s.SaleId == item.SaleId))
            throw new DalListException($"Sale with ID {item.SaleId} already exists.");

        DataSource.Sales.Add(item);
        return item.SaleId;
    }

    public void Delete(int id)
    {
        var sale = DataSource.Sales.FirstOrDefault(s => s.SaleId == id);
        if (sale == null)
            throw new DalListException($"Sale with ID {id} not found.");

        DataSource.Sales.Remove(sale);
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
        return DataSource.Sales.ToList();
    }

    public void Update(Sale item)
    {
        var sale = DataSource.Sales.FirstOrDefault(s => s.SaleId == item.SaleId);
        if (sale == null)
            throw new DalListException($"Sale with ID {item.SaleId} not found.");

        sale.ProductId = item.ProductId;
        sale.CustomerId = item.CustomerId;
        sale.Quantity = item.Quantity;
        sale.Date = item.Date;
    }
}

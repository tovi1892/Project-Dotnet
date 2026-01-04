using DO;
using DalApi;
using static Dal.DataSource;

namespace Dal;

internal class SaleImplementation : ISale
{
    public int Create(Sale item)
    {


        Sale s = item with { SaleId = Config.GetNextProductId() };


        Sales.Add(s);
        return item.SaleId;
    }

    public void Delete(int id)
    {
        var sale = Sales.FirstOrDefault(s => s.SaleId == id);
        if (sale == null)
            throw new ($"Sale with ID {id} not found.");

        Sales.Remove(sale);
    }

    public Sale? Read(int id)
    {
        var sale = DataSource.Sales.FirstOrDefault(s => s.SaleId == id);
        if (sale == null)
            throw new ($"Sale with ID {id} not found.");

        return sale;
    }

    public List<Sale> ReadAll()
    {
        return Sales.ToList();
    }

    public void Update(Sale item)
    {

        int itemIndex = Sales.FindIndex(p => p?.SaleId == item.SaleId);
        if (itemIndex == -1)
        {
            throw new ItemNotFoundException("item not found");

        }
        Sales[itemIndex] = item;
    }
}

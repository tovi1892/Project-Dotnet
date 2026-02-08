
using DalApi;
using DO;


using System.Linq;

using static Dal.DataSource;
namespace Dal;

internal class SaleImplementation : ISale
{
    public int Create(Sale item)
    {
       
        if (item.SaleId == 0)
        {
            int nextId = Sales.Any() ? Sales.Max(s => s.SaleId) + 1 : 1;
            item = item with { SaleId = nextId };
            Sales.Add(item);
            return item.SaleId;
        }

        var q = from s in Sales
                where s.SaleId == item.SaleId
                select s;
        if (q.FirstOrDefault() != null)
            throw new DalItemAlreadyExistsException($"Sale with ID {item.SaleId} already exists.");

        Sales.Add(item);
        return item.SaleId;
    }

    public void Delete(int id)
    {
        var q = from s in Sales
                where s.SaleId == id
                select s;

        Sale? sale = q.FirstOrDefault();
        if (sale == null)
            throw new DalItemNotFoundException($"Sale with ID {id} not found.");

        int idx = Sales.IndexOf(sale);
        if (idx == -1)
            throw new DalItemNotFoundException($"Sale with ID {id} not found.");

        Sales.RemoveAt(idx);
    }

    public Sale? Read(Func<Sale ,bool> filter)
    {
        var q = from s in Sales
                where filter(s)
                select s;

        Sale? sale = q.FirstOrDefault();
        if (sale == null)
            throw new DalItemNotFoundException($"Sale  not found.");
        return sale;
    }
    public List<Sale?> ReadAll(Func<Sale, bool>? filter=null)
{
        if(filter == null)
            return new List<Sale?>(Sales);

        var q = from s in Sales
                where filter(s)
                select s;
        return new List<Sale?>(q);
    }

    public void Update(Sale item)
    {
        var q = from s in Sales
                where s.SaleId == item.SaleId
                select s;

        Sale? sale = q.FirstOrDefault();
        if (sale == null)
            throw new DalItemNotFoundException($"Sale with ID {item.SaleId} not found.");

        int idx = Sales.IndexOf(sale);
        if (idx == -1)
            throw new DalItemNotFoundException($"Sale with ID {item.SaleId} not found.");

        Sales[idx] = item;
    }
}
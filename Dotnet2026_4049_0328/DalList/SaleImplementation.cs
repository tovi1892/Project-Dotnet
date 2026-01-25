
////using DalApi;
////using DO;
////using static Dal.DataSource;

////using DO;
////using DalApi;
////using static Dal.DataSource;

////namespace Dal;

////internal class SaleImplementation : ISale
////{
////    public int Create(Sale item)
////    {
////        Sale s = item with { SaleId = Config.GetNextProductId() };

////        Sales.Add(s);
////        return s.SaleId;
////    }

////    public void Delete(int id)
////    {
////        var sale = Sales.FirstOrDefault(s => s.SaleId == id);
////        if (sale == null)
////            throw new DalItemNotFoundException($"Sale with ID {id} not found.");

////        Sales.Remove(sale);
////    }

////    public Sale? Read(int id)
////    {
////        var sale = DataSource.Sales.FirstOrDefault(s => s.SaleId == id);
////        if (sale == null)
////            throw new DalItemNotFoundException($"Sale with ID {id} not found.");

////        return sale;
////    }

////    public List<Sale> ReadAll()
////    {
////        return Sales.ToList();
////    }

////    public void Update(Sale item)
////    {
////        int itemIndex = Sales.FindIndex(p => p?.SaleId == item.SaleId);
////        if (itemIndex == -1)
////        {
////            throw new DalItemNotFoundException($"Sale with ID {item.SaleId} not found.");
////        }
////        Sales[itemIndex] = item;
////    }
////}
//using DalApi;
//using DO;
//using static Dal.DataSource;



//namespace Dal;

//internal class SaleImplementation : ISale
//{
//    public int Create(Sale item)
//    {
//        // keep existing id generator usage
//        Sale s = item with { SaleId = Config.GetNextProductId() };
//        Sales.Add(s);
//        return s.SaleId;
//    }

//    public void Delete(int id)
//    {
//        var sale = Sales.FirstOrDefault(s => s.SaleId == id);
//        if (sale == null)
//            throw new DalItemNotFoundException($"Sale with ID {id} not found.");

//        Sales.Remove(sale);
//    }

//    public Sale? Read(int id)
//    {
//        var sale = Sales.FirstOrDefault(s => s.SaleId == id);
//        if (sale == null)
//            throw new DalItemNotFoundException($"Sale with ID {id} not found.");
//        return sale;
//    }

//    public List<Sale> ReadAll()
//    {
//        return Sales.ToList();
//    }

//    public void Update(Sale item)
//    {
//        var found = Sales
//            .Select((s, i) => new { Sale = s, Index = i })
//            .FirstOrDefault(x => x.Sale.SaleId == item.SaleId);

//        if (found == null)
//            throw new DalItemNotFoundException($"Sale with ID {item.SaleId} not found.");

//        Sales[found.Index] = item;
//    }
//}
using DalApi;
using DO;

using DalApi;
using DO;
using System.Linq;

using static Dal.DataSource;
namespace Dal;

internal class SaleImplementation : ISale
{
    public int Create(Sale item)
    {
        // אם caller לא מספק id -> DAL מקצה id (Max+1)
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

    public Sale? Read(int id)
    {
        var q = from s in Sales
                where s.SaleId == id
                select s;

        Sale? sale = q.FirstOrDefault();
        if (sale == null)
            throw new DalItemNotFoundException($"Sale with ID {id} not found.");
        return sale;
    }

    public List<Sale> ReadAll()
    {
        return Sales.ToList();
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
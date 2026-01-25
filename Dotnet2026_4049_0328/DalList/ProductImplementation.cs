
////using DalApi;
////using DO;
////using static Dal.DataSource;




////namespace Dal;

////internal class ProductImplementation : IProduct
////{
////    public int Create(Product item)
////    {
////        Product p = item with { ProductId = Config.GetNextProductId() };
////        Products.Add(p);
////        return p.ProductId;
////    }

////    public void Delete(int id)
////    {
////        var product = Products.FirstOrDefault(s => s.ProductId == id);
////        if (product == null)
////            throw new DalItemNotFoundException($"Product with ID {id} not found.");

////        Products.Remove(product);
////    }

////    public Product? Read(int id)
////    {
////        var product = Products.FirstOrDefault(p => p.ProductId == id);
////        return product;
////    }

////    public List<Product> ReadAll()
////    {
////        return Products.ToList();
////    }

////    public void Update(Product item)
////    {
////        int itemIndex = Products.FindIndex(p => p?.ProductId == item.ProductId);
////        if (itemIndex == -1)
////        {
////            throw new DalItemNotFoundException($"Product with ID {item.ProductId} not found.");
////        }
////        Products[itemIndex] = item;
////    }
////}
//using DalApi;
//using DO;
//using static Dal.DataSource;


//namespace Dal;

//internal class ProductImplementation : IProduct
//{
//    public int Create(Product item)
//    {
//        // assign a new id (keeps existing approach)
//        Product p = item with { ProductId = Config.GetNextProductId() };
//        Products.Add(p);
//        return p.ProductId;
//    }

//    public void Delete(int id)
//    {
//        var product = Products.FirstOrDefault(s => s.ProductId == id);
//        if (product == null)
//            throw new DalItemNotFoundException($"Product with ID {id} not found.");

//        Products.Remove(product);
//    }

//    public Product? Read(int id)
//    {
//        var product = Products.FirstOrDefault(p => p.ProductId == id);
//        if (product == null)
//            throw new DalItemNotFoundException($"Product with ID {id} not found.");
//        return product;
//    }

//    public List<Product> ReadAll()
//    {
//        return Products.ToList();
//    }

//    public void Update(Product item)
//    {
//        var found = Products
//            .Select((p, i) => new { Product = p, Index = i })
//            .FirstOrDefault(x => x.Product.ProductId == item.ProductId);

//        if (found == null)
//            throw new DalItemNotFoundException($"Product with ID {item.ProductId} not found.");

//        Products[found.Index] = item;
//    }
//}
using DalApi;
using DO;

using DalApi;
using DO;
using System.Linq;

using static Dal.DataSource;
namespace Dal;

internal class ProductImplementation : IProduct
{
    public int Create(Product item)
    {
        // אם caller לא מספק id -> DAL מקצה id (Max+1)
        if (item.ProductId == 0)
        {
            int nextId = Products.Any() ? Products.Max(p => p.ProductId) + 1 : 1;
            item = item with { ProductId = nextId };
            Products.Add(item);
            return item.ProductId;
        }

        var q = from p in Products
                where p.ProductId == item.ProductId
                select p;
        if (q.FirstOrDefault() != null)
            throw new DalItemAlreadyExistsException($"Product with ID {item.ProductId} already exists.");

        Products.Add(item);
        return item.ProductId;
    }

    public void Delete(int id)
    {
        var q = from p in Products
                where p.ProductId == id
                select p;

        Product? prod = q.FirstOrDefault();
        if (prod == null)
            throw new DalItemNotFoundException($"Product with ID {id} not found.");

        int idx = Products.IndexOf(prod);
        if (idx == -1)
            throw new DalItemNotFoundException($"Product with ID {id} not found.");

        Products.RemoveAt(idx);
    }

    public Product? Read(int id)
    {
        var q = from p in Products
                where p.ProductId == id
                select p;

        Product? prod = q.FirstOrDefault();
        if (prod == null)
            throw new DalItemNotFoundException($"Product with ID {id} not found.");
        return prod;
    }

    public List<Product> ReadAll()
    {
        return Products.ToList();
    }

    public void Update(Product item)
    {
        var q = from p in Products
                where p.ProductId == item.ProductId
                select p;

        Product? prod = q.FirstOrDefault();
        if (prod == null)
            throw new DalItemNotFoundException($"Product with ID {item.ProductId} not found.");

        int idx = Products.IndexOf(prod);
        if (idx == -1)
            throw new DalItemNotFoundException($"Product with ID {item.ProductId} not found.");

        Products[idx] = item;
    }
}
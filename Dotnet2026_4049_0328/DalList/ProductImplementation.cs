
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
using System.Reflection;
using Tools__;

using DalApi;
using DO;
using System.Linq;

using static Dal.DataSource;
namespace Dal;

internal class ProductImplementation : IProduct
{
    public int Create(Product item)
    {
        try
        {
            if (item.ProductId == 0)
            {
                int nextId = Products.Any() ? Products.Max(p => p.ProductId) + 1 : 1;
                item = item with { ProductId = nextId };
            }
            else
            {
                var q = from p in Products
                        where p.ProductId == item.ProductId
                        select p;
                if (q.FirstOrDefault() != null)
                    throw new DalItemAlreadyExistsException($"Product with ID {item.ProductId} already exists.");
            }

            Products.Add(item);

            LogManager.WriteLog(
                MethodBase.GetCurrentMethod().DeclaringType.Name,
                MethodBase.GetCurrentMethod().Name,
                $"Created new product with ID: {item.ProductId}"
            );

            return item.ProductId;
        }
        catch (Exception ex)
        {
            LogManager.WriteLog(
                MethodBase.GetCurrentMethod().DeclaringType.Name,
                MethodBase.GetCurrentMethod().Name,
                $"ERROR: {ex.Message}"
            );
            throw;
        }
    }

    public void Delete(int id)
    {
        try
        {
            var q = from p in Products
                    where p.ProductId == id
                    select p;

            Product? prod = q.FirstOrDefault();
            if (prod == null)
            {
                LogManager.WriteLog(
                    MethodBase.GetCurrentMethod().DeclaringType.Name,
                    MethodBase.GetCurrentMethod().Name,
                    $"ERROR: Product with ID {id} not found."
                );
                throw new DalItemNotFoundException($"Product with ID {id} not found.");
            }

            int idx = Products.IndexOf(prod);
            if (idx == -1)
            {
                LogManager.WriteLog(
                    MethodBase.GetCurrentMethod().DeclaringType.Name,
                    MethodBase.GetCurrentMethod().Name,
                    $"ERROR: Product with ID {id} not found."
                );
                throw new DalItemNotFoundException($"Product with ID {id} not found.");
            }

            Products.RemoveAt(idx);
            LogManager.WriteLog(
                MethodBase.GetCurrentMethod().DeclaringType.Name,
                MethodBase.GetCurrentMethod().Name,
                $"Deleted product with ID: {id}"
            );
        }
        catch (Exception ex)
        {
            LogManager.WriteLog(
                MethodBase.GetCurrentMethod().DeclaringType.Name,
                MethodBase.GetCurrentMethod().Name,
                $"ERROR: {ex.Message}"
            );
            throw;
        }
    }

    public Product? Read(Func<Product, bool> filter)
    {
        try
        {
            var q = from p in Products
                    where filter(p)
                    select p;

            Product? prod = q.FirstOrDefault();
            if (prod == null)
            {
                LogManager.WriteLog(
                    MethodBase.GetCurrentMethod().DeclaringType.Name,
                    MethodBase.GetCurrentMethod().Name,
                    $"ERROR: Product not found."
                );
                throw new DalItemNotFoundException($"Product not found.");
            }
            LogManager.WriteLog(
                MethodBase.GetCurrentMethod().DeclaringType.Name,
                MethodBase.GetCurrentMethod().Name,
                $"Read product with ID: {prod.ProductId}"
            );
            return prod;
        }
        catch (Exception ex)
        {
            LogManager.WriteLog(
                MethodBase.GetCurrentMethod().DeclaringType.Name,
                MethodBase.GetCurrentMethod().Name,
                $"ERROR: {ex.Message}"
            );
            throw;
        }
    }

    public List<Product?> ReadAll(Func<Product, bool>? filter = null)
    {
        try
        {
            List<Product?> result;
            if (filter == null)
                result = Products.ToList();
            else
            {
                var q = from p in Products
                        where filter(p)
                        select p;
                result = q.ToList();
            }
            LogManager.WriteLog(
                MethodBase.GetCurrentMethod().DeclaringType.Name,
                MethodBase.GetCurrentMethod().Name,
                $"ReadAll products, count: {result.Count}"
            );
            return result;
        }
        catch (Exception ex)
        {
            LogManager.WriteLog(
                MethodBase.GetCurrentMethod().DeclaringType.Name,
                MethodBase.GetCurrentMethod().Name,
                $"ERROR: {ex.Message}"
            );
            throw;
        }
    }

    public void Update(Product item)
    {
        try
        {
            var q = from p in Products
                    where p.ProductId == item.ProductId
                    select p;

            Product? prod = q.FirstOrDefault();
            if (prod == null)
            {
                LogManager.WriteLog(
                    MethodBase.GetCurrentMethod().DeclaringType.Name,
                    MethodBase.GetCurrentMethod().Name,
                    $"ERROR: Product with ID {item.ProductId} not found."
                );
                throw new DalItemNotFoundException($"Product with ID {item.ProductId} not found.");
            }

            int idx = Products.IndexOf(prod);
            if (idx == -1)
            {
                LogManager.WriteLog(
                    MethodBase.GetCurrentMethod().DeclaringType.Name,
                    MethodBase.GetCurrentMethod().Name,
                    $"ERROR: Product with ID {item.ProductId} not found."
                );
                throw new DalItemNotFoundException($"Product with ID {item.ProductId} not found.");
            }

            Products[idx] = item;
            LogManager.WriteLog(
                MethodBase.GetCurrentMethod().DeclaringType.Name,
                MethodBase.GetCurrentMethod().Name,
                $"Updated product with ID: {item.ProductId}"
            );
        }
        catch (Exception ex)
        {
            LogManager.WriteLog(
                MethodBase.GetCurrentMethod().DeclaringType.Name,
                MethodBase.GetCurrentMethod().Name,
                $"ERROR: {ex.Message}"
            );
            throw;
        }
    }
}

using DO;
using DalApi;
using static Dal.DataSource;

namespace Dal;

internal class ProductImplementation : IProduct
{
    public int Create(Product product)
    {
           
      Product p = product with { ProductId = Config.GetNextProductId() };
        //if (DataSource.Products.Any(p => p.ProductId == item.ProductId))
        //    throw new DalListException($"Product with ID {item.ProductId} already exists.");

        //DataSource.Products.Add(item);
        Products.Add(p);
        return p.ProductId;
    
   

    }

    public void Delete(int id)
    {
        var product = Products.FirstOrDefault(s => s.ProductId == id);
        if (product == null)
            throw new DalListException($"Sale with ID {id} not found.");

        Products.Remove(product);
    }

    public Product? Read(int id)
    {
        var product = Products.FirstOrDefault(p => p.ProductId == id);
        if (product == null)
            throw new DalListException($"Product with ID {id} not found.");

        return product;
    }

    public List<Product> ReadAll()
    {
        return Products.ToList();
    }

    public void Update(Product item)
    {
        Product product = Products.FirstOrDefault(p => p.ProductId == item.ProductId);
        if (product == null)
            throw new DalListException($"Product with ID {item.ProductId} not found.");

        product.ProductName = item.ProductName;
        product.Price = item.Price;
        product.QuantityInStock = item.QuantityInStock;
    }
}

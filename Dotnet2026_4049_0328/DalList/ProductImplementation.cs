using DO;
using DalApi;
using static Dal.DataSource;

namespace Dal;

internal class ProductImplementation : IProduct
{
    public int Create(Product item)
    {
           
      Product p = item with { ProductId = Config.GetNextProductId() };
        if (DataSource.Products.Any(p => p.ProductId == item.ProductId))
            throw new ItemApperException($"Product with ID {item.ProductId} already exists.");

        Products.Add(p);
        return p.ProductId;
    
   

    }

    public void Delete(int id)
    {
        var product = Products.FirstOrDefault(s => s.ProductId == id);
        if (product == null)
            throw new ItemNotFoundException($"Sale with ID {id} not found.");

        Products.Remove(product);
    }

    public Product? Read(int id)
    {
        var product = Products.FirstOrDefault(p => p.ProductId == id);
      

        return product;
    }

    public List<Product> ReadAll()
    {
        return Products.ToList();
    }

    public void Update(Product item)
    {

        int itemIndex = Products.FindIndex(p => p?.ProductId == item.ProductId);
        if (itemIndex == -1)
        {
            throw new ItemNotFoundException("item not found");

        }
        Products[itemIndex] = item;

    }
}

using DO;
using DalApi;

namespace Dal;

internal class ProductImplementation : IProduct
{
    public int Create(int ProductId,
    String ProductName,
    Categories Category,
    int QuantityInStock,
    double Price)
    {
        Product item = new Product()
        {
            ProductId = ProductId,
            ProductName = ProductName,
            Category = Category,
            QuantityInStock = QuantityInStock,
            Price = Price
        };
        DataSource.Products.Add(item);
        //if (DataSource.Products.Any(p => p.ProductId == item.ProductId))
        //    throw new DalListException($"Product with ID {item.ProductId} already exists.");

        //DataSource.Products.Add(item);
        //return item.ProductId;

    }

    public void Delete(int id)
    {
        foreach (var product in DataSource.Products)
        {
            if (product.ProductId == id)
            {
                DataSource.Products.Remove(product);
                return;
            }
        }


    }

    public Product? Read(int id)
    {
        var product = DataSource.Products.FirstOrDefault(p => p.ProductId == id);
        if (product == null)
            throw new DalListException($"Product with ID {id} not found.");

        return product;
    }

    public List<Product> ReadAll()
    {
        return DataSource.Products.ToList();
    }

    public void Update(Product item)
    {
        var product = DataSource.Products.FirstOrDefault(p => p.ProductId == item.ProductId);
        if (product == null)
            throw new DalListException($"Product with ID {item.ProductId} not found.");

        product.ProductName = item.ProductName;
        product.Price = item.Price;
        product.Stock = item.Stock;
    }
}

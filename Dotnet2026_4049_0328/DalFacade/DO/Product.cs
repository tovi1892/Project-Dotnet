

namespace DO;

public record Product(
    int ProductId,
    string ProductName,
    Categories Category,
    int QuantityInStock,
    double Price
  
    )
{
    public Product() : this(1,"", Categories.Watches,100,20)
    {
        
    }
}

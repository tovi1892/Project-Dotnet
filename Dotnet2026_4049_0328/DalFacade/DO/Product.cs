

namespace DO;

public record Product(
    int ProductId,
    String ProductName,
    Categories Category,
    int QuantityInStock,
    double Price
  
    )
{
    public Product() : this(1,"", Categories.Watches,100,20)
    {
        
    }
}

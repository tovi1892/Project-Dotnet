




namespace DO;

public record Sale(
    int SaleId,
    int ProductId,
    int QuantityToSale,
    int TotalPrice,
    bool IsClube,
    DateTime StartSale,
    DateTime EndSale
    )
{
    public Sale() : this(1, 1, 1, 20, false, DateTime.Now, DateTime.Now.AddDays(7))
    {

    }
}

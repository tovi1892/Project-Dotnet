
namespace BO;

public class SaleInProduct
{
    public int SaleId { get; init; }
    public int Amount_to_sale { get; init; }
    public double Price_per_one { get; init; }
    public bool IsForAllClients { get; init; }
    public int ProductId { get; internal set; }
    public int Quantity { get; internal set; }
    public double TotalPrice { get; internal set; }
    public bool IsClub { get; internal set; }
    public DateTime SaleStartDate { get; internal set; }
    public DateTime SaleEndDate { get; internal set; }

    public override string ToString() => this.ToStringProperty();

}

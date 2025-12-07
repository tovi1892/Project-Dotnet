

namespace DO;

public record Customer(
    string CustomerId,
    String CustomerName,
    String CustomerAddress,
    String CustomerPhone)
{
    public Customer() : this("","","","0555555555")
    {

    }
}

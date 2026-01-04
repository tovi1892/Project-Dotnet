

namespace DO;

public record Customer(
    int CustomerId,
    string CustomerName,
    string CustomerAddress,
    string CustomerPhone)
{
    public Customer() : this(1,"","","0555555555")
    {

    }
}

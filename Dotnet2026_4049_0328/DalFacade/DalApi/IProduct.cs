
using DO;
namespace DalApi;


public interface IProduct : ICrudcs<Product>
{
    string Name { get; set; }

}

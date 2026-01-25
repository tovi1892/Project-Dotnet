
using DalApi;
using DO;
 
using static Dal.DataSource;
namespace Dal;

internal class CustomerImplementation : ICustomer
{

    public int Create(Customer customer)
    {
        var q = from c in Customers
                where c.CustomerId == customer.CustomerId
                select c;
        if (q.FirstOrDefault() !=null)
            throw new ItemApperException("customer apper");
        Customers.Add(customer);
        ;



        //int itemIndex = Customers.FindIndex(p => p?.CustomerId == customer.CustomerId);
        //if (itemIndex != -1)
        //{
        //    throw new ItemApperException("customer apper");
        //}
        //Customers.Add(customer);
        return q;
    }
    public Customer? Read(int id)
    {
        int itemIndex = Customers.FindIndex(p => p?.CustomerId == id);
       
        return Customers[itemIndex];
    }



    public List<Customer> ReadAll()
    {
        return Customers;
    }
    public void Update(Customer item)
    {
        int itemIndex = Customers.FindIndex(p => p?.CustomerId == item.CustomerId);
        if (itemIndex == -1)
        {
            throw new ItemNotFoundException("customer not found");
        }
        Customers[itemIndex] = item;

    }

    public void Delete(int id)
    {
        int itemIndex = Customers.FindIndex(p => p?.CustomerId == id);
        if (itemIndex == -1)
        {
            throw new ItemNotFoundException("customer not found");
        }
        Customers.RemoveAt(itemIndex);
    }

}


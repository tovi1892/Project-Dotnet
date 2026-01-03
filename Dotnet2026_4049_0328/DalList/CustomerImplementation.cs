
using DalApi;
using DO;

internal class ImplementationCustomer : ICustomer
{

    public int Create(Customer customer)
    {
        int itemIndex = Customers.FindIndex(p => p?.CustomerId == customer.CustomerId);
        if (itemIndex != -1)
        {
            throw new CustomerApperException("customer apper");
        }
        Customers.Add(customer);
        return customer.CustomerId;
    }
    public Customer? Read(int id)
    {
        int itemIndex = Customers.FindIndex(p => p?.CustomerId == id);
        if (itemIndex == -1)
        {
            throw new ItemNotFoundException("customer not found");
        }
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


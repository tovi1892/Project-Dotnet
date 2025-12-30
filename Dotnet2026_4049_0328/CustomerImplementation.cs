using DO;
using DalApi;

namespace Dal;

internal class CustomerImplementation : ICustomer
{
    public int Creat(Customer item)
    {
        // בדיקה אם לקוח עם אותו מזהה כבר קיים
        if (DataSource.Customers.Any(c => c.CustomerId == item.CustomerId))
            throw new DalListException($"Customer with ID {item.CustomerId} already exists.");

        DataSource.Customers.Add(item);
        return item.CustomerId;
    }

    public void Delete(int id)
    {
        var customer = DataSource.Customers.FirstOrDefault(c => c.CustomerId == id);
        if (customer == null)
            throw new DalListException($"Customer with ID {id} not found.");

        DataSource.Customers.Remove(customer);
    }

    public Customer? Read(int id)
    {
        var customer = DataSource.Customers.FirstOrDefault(c => c.CustomerId == id);
        if (customer == null)
            throw new DalListException($"Customer with ID {id} not found.");

        return customer;
    }

    public List<Customer> ReadAll()
    {
        return DataSource.Customers.ToList();
    }

    public void Update(Customer item)
    {
        var customer = DataSource.Customers.FirstOrDefault(c => c.CustomerId == item.CustomerId);
        if (customer == null)
            throw new DalListException($"Customer with ID {item.CustomerId} not found.");

        customer.CustomerName = item.CustomerName;
        customer.CustomerAddress = item.CustomerAddress;
        customer.CustomerPhone = item.CustomerPhone;
    }
}

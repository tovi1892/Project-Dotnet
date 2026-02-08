



using DalApi;
using DO;
using System.Linq;

using static Dal.DataSource;
namespace Dal;

internal class CustomerImplementation : ICustomer
{
    public int Create(Customer customer)
    {
        // אם הספיקה id = 0 -> DAL מקצה id אוטומטי (Max+1), אחרת בודק קיום ומקפיץ חריגה
        if (customer.CustomerId == 0)
        {
            int nextId = Customers.Any() ? Customers.Max(c => c.CustomerId) + 1 : 1;
            customer = customer with { CustomerId = nextId };
            Customers.Add(customer);
            return customer.CustomerId;
        }

        var q = from c in Customers
                where c.CustomerId == customer.CustomerId
                select c;
        if (q.FirstOrDefault() != null)
            throw new DalItemAlreadyExistsException($"Customer with ID {customer.CustomerId} already exists.");

        Customers.Add(customer);
        return customer.CustomerId;
    }

public Customer? Read(Func<Customer, bool> filter)
    {
        var q = from c in Customers
                where filter(c)
                select c;
        Customer? cus = q.FirstOrDefault();
        if (cus == null)
            throw new DalItemNotFoundException($"Customer not found.");
        return cus;
    }


    public List<Customer?> ReadAll(Func<Customer, bool>? filter=null )    {

        if (filter == null)
            return Customers.ToList();

        var q = from c in Customers
                where filter(c)
                select c;
        return q.ToList();
    }


    public void Update(Customer item)
    {
        var q = from c in Customers
                where c.CustomerId == item.CustomerId
                select c;

        Customer? cus = q.FirstOrDefault();
        if (cus == null)
            throw new DalItemNotFoundException($"Customer with ID {item.CustomerId} not found.");

        int idx = Customers.IndexOf(cus);
        if (idx == -1)
            throw new DalItemNotFoundException($"Customer with ID {item.CustomerId} not found."); // בטיחות נוספת

        Customers[idx] = item;
    }

    public void Delete(int id)
    {
        var q = from c in Customers
                where c.CustomerId == id
                select c;

        Customer? cus = q.FirstOrDefault();
        if (cus == null)
            throw new DalItemNotFoundException($"Customer with ID {id} not found.");

        int idx = Customers.IndexOf(cus);
        if (idx == -1)
            throw new DalItemNotFoundException($"Customer with ID {id} not found."); // בטיחות נוספת

        Customers.RemoveAt(idx);
    }

  
}
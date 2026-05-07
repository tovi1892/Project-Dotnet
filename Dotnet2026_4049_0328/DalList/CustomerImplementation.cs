



using DalApi;
using DO;
using System.Linq;
using System.Reflection;
using Tool;

using static Dal.DataSource;
namespace Dal;

internal class CustomerImplementation : ICustomer
{
    public int Create(Customer customer)
    {
        try
        {
            if (customer.CustomerId == 0)
            {
                int nextId = Customers.Any() ? Customers.Max(c => c.CustomerId) + 1 : 1;
                customer = customer with { CustomerId = nextId };
            }
            else
            {
                // בדיקה אם קיים
                if (Customers.Any(c => c.CustomerId == customer.CustomerId))
                    throw new DalItemAlreadyExistsException($"Customer with ID {customer.CustomerId} already exists.");
            }

            Customers.Add(customer);

            // כאן הלוג יתבצע בכל מקרה של הצלחה!
            LogManager.WriteLog(
                MethodBase.GetCurrentMethod().DeclaringType.Name,
                MethodBase.GetCurrentMethod().Name,
                $"Created new customer with ID: {customer.CustomerId}"
            );

            return customer.CustomerId;
        }
        catch (Exception ex)
        {
            LogManager.WriteLog(
                MethodBase.GetCurrentMethod().DeclaringType.Name,
                MethodBase.GetCurrentMethod().Name,
                $"ERROR: {ex.Message}"
            );
            throw; // זורקים את השגיאה הלאה
        }
    }

    public Customer? Read(Func<Customer, bool> filter)
    {
        try
        {
            var q = from c in Customers
                    where filter(c)
                    select c;
            Customer? cus = q.FirstOrDefault();
            if (cus == null)
            {
                LogManager.WriteLog(
                    MethodBase.GetCurrentMethod().DeclaringType.Name,
                    MethodBase.GetCurrentMethod().Name,
                    $"ERROR: Customer not found."
                );
                throw new DalItemNotFoundException($"Customer not found.");
            }
            LogManager.WriteLog(
                MethodBase.GetCurrentMethod().DeclaringType.Name,
                MethodBase.GetCurrentMethod().Name,
                $"Read customer with ID: {cus.CustomerId}"
            );
            return cus;
        }
        catch (Exception ex)
        {
            LogManager.WriteLog(
                MethodBase.GetCurrentMethod().DeclaringType.Name,
                MethodBase.GetCurrentMethod().Name,
                $"ERROR: {ex.Message}"
            );
            throw;
        }
    }


    public List<Customer?> ReadAll(Func<Customer, bool>? filter = null)
    {
        try
        {
            List<Customer?> result;
            if (filter == null)
                result = Customers.ToList();
            else
            {
                var q = from c in Customers
                        where filter(c)
                        select c;
                result = q.ToList();
            }
            LogManager.WriteLog(
                MethodBase.GetCurrentMethod().DeclaringType.Name,
                MethodBase.GetCurrentMethod().Name,
                $"ReadAll customers, count: {result.Count}"
            );
            return result;
        }
        catch (Exception ex)
        {
            LogManager.WriteLog(
                MethodBase.GetCurrentMethod().DeclaringType.Name,
                MethodBase.GetCurrentMethod().Name,
                $"ERROR: {ex.Message}"
            );
            throw;
        }
    }


    public void Update(Customer item)
    {
        try
        {
            var q = from c in Customers
                    where c.CustomerId == item.CustomerId
                    select c;

            Customer? cus = q.FirstOrDefault();
            if (cus == null)
            {
                LogManager.WriteLog(
                    MethodBase.GetCurrentMethod().DeclaringType.Name,
                    MethodBase.GetCurrentMethod().Name,
                    $"ERROR: Customer with ID {item.CustomerId} not found."
                );
                throw new DalItemNotFoundException($"Customer with ID {item.CustomerId} not found.");
            }

            int idx = Customers.IndexOf(cus);
            if (idx == -1)
            {
                LogManager.WriteLog(
                    MethodBase.GetCurrentMethod().DeclaringType.Name,
                    MethodBase.GetCurrentMethod().Name,
                    $"ERROR: Customer with ID {item.CustomerId} not found."
                );
                throw new DalItemNotFoundException($"Customer with ID {item.CustomerId} not found.");
            }

            Customers[idx] = item;
            LogManager.WriteLog(
                MethodBase.GetCurrentMethod().DeclaringType.Name,
                MethodBase.GetCurrentMethod().Name,
                $"Updated customer with ID: {item.CustomerId}"
            );
        }
        catch (Exception ex)
        {
            LogManager.WriteLog(
                MethodBase.GetCurrentMethod().DeclaringType.Name,
                MethodBase.GetCurrentMethod().Name,
                $"ERROR: {ex.Message}"
            );
            throw;
        }
    }

    public void Delete(int id)
    {
        try
        {
            var q = from c in Customers
                    where c.CustomerId == id
                    select c;

            Customer? cus = q.FirstOrDefault();
            if (cus == null)
            {
                LogManager.WriteLog(
                    MethodBase.GetCurrentMethod().DeclaringType.Name,
                    MethodBase.GetCurrentMethod().Name,
                    $"ERROR: Customer with ID {id} not found."
                );
                throw new DalItemNotFoundException($"Customer with ID {id} not found.");
            }

            int idx = Customers.IndexOf(cus);
            if (idx == -1)
            {
                LogManager.WriteLog(
                    MethodBase.GetCurrentMethod().DeclaringType.Name,
                    MethodBase.GetCurrentMethod().Name,
                    $"ERROR: Customer with ID {id} not found."
                );
                throw new DalItemNotFoundException($"Customer with ID {id} not found.");
            }

            Customers.RemoveAt(idx);
            LogManager.WriteLog(
                MethodBase.GetCurrentMethod().DeclaringType.Name,
                MethodBase.GetCurrentMethod().Name,
                $"Deleted customer with ID: {id}"
            );
        }
        catch (Exception ex)
        {
            LogManager.WriteLog(
                MethodBase.GetCurrentMethod().DeclaringType.Name,
                MethodBase.GetCurrentMethod().Name,
                $"ERROR: {ex.Message}"
            );
            throw;
        }
    }

    public Customer? Read(int id)
    {
        LogManager.WriteLog(MethodBase.GetCurrentMethod().DeclaringType.FullName,
    MethodBase.GetCurrentMethod().Name, "start func");
        var q = from c in Customers where c.CustomerId == id select c;
        Customer? cu = q.FirstOrDefault();

        if (cu == null)
            throw new DalItemNotFoundException("notContainThisIdException");
        LogManager.WriteLog(MethodBase.GetCurrentMethod().DeclaringType.FullName,
    MethodBase.GetCurrentMethod().Name, "finish func");
        return cu;
    }
}
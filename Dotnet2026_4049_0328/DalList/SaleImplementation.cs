
using DalApi;
using DO;
using System.Reflection;
using Tool;

using System.Linq;

using static Dal.DataSource;
namespace Dal;

internal class SaleImplementation : ISale
{
    public int Create(Sale item)
    {
        try
        {
            if (item.SaleId == 0)
            {
                int nextId = Sales.Any() ? Sales.Max(s => s.SaleId) + 1 : 1;
                item = item with { SaleId = nextId };
            }
            else
            {
                var q = from s in Sales
                        where s.SaleId == item.SaleId
                        select s;
                if (q.FirstOrDefault() != null)
                    throw new DalItemAlreadyExistsException($"Sale with ID {item.SaleId} already exists.");
            }

            Sales.Add(item);

            LogManager.WriteLog(
                MethodBase.GetCurrentMethod().DeclaringType.Name,
                MethodBase.GetCurrentMethod().Name,
                $"Created new sale with ID: {item.SaleId}"
            );

            return item.SaleId;
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
            var q = from s in Sales
                    where s.SaleId == id
                    select s;

            Sale? sale = q.FirstOrDefault();
            if (sale == null)
            {
                LogManager.WriteLog(
                    MethodBase.GetCurrentMethod().DeclaringType.Name,
                    MethodBase.GetCurrentMethod().Name,
                    $"ERROR: Sale with ID {id} not found."
                );
                throw new DalItemNotFoundException($"Sale with ID {id} not found.");
            }

            int idx = Sales.IndexOf(sale);
            if (idx == -1)
            {
                LogManager.WriteLog(
                    MethodBase.GetCurrentMethod().DeclaringType.Name,
                    MethodBase.GetCurrentMethod().Name,
                    $"ERROR: Sale with ID {id} not found."
                );
                throw new DalItemNotFoundException($"Sale with ID {id} not found.");
            }

            Sales.RemoveAt(idx);
            LogManager.WriteLog(
                MethodBase.GetCurrentMethod().DeclaringType.Name,
                MethodBase.GetCurrentMethod().Name,
                $"Deleted sale with ID: {id}"
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

    public Sale? Read(Func<Sale, bool> filter)
    {
        try
        {
            var q = from s in Sales
                    where filter(s)
                    select s;

            Sale? sale = q.FirstOrDefault();
            if (sale == null)
            {
                LogManager.WriteLog(
                    MethodBase.GetCurrentMethod().DeclaringType.Name,
                    MethodBase.GetCurrentMethod().Name,
                    $"ERROR: Sale not found."
                );
                throw new DalItemNotFoundException($"Sale not found.");
            }
            LogManager.WriteLog(
                MethodBase.GetCurrentMethod().DeclaringType.Name,
                MethodBase.GetCurrentMethod().Name,
                $"Read sale with ID: {sale.SaleId}"
            );
            return sale;
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

    public Sale? Read(int id)
    {
        LogManager.WriteLog(MethodBase.GetCurrentMethod().DeclaringType.FullName,
    MethodBase.GetCurrentMethod().Name, "start func");
        var q = from s in Sales
                where s.SaleId == id
               
                select s;
        Sale? sale = q.FirstOrDefault();

        if (sale == null)
            throw new DalItemNotFoundException("notContainThisIdException");
        LogManager.WriteLog(MethodBase.GetCurrentMethod().DeclaringType.FullName,
    MethodBase.GetCurrentMethod().Name, "finish func");
        return sale;
    }

    public List<Sale?> ReadAll(Func<Sale, bool>? filter = null)
    {
        try
        {
            List<Sale?> result;
            if (filter == null)
                result = Sales.ToList();
            else
            {
                var q = from s in Sales
                        where filter(s)
                        select s;
                result = q.ToList();
            }
            LogManager.WriteLog(
                MethodBase.GetCurrentMethod().DeclaringType.Name,
                MethodBase.GetCurrentMethod().Name,
                $"ReadAll sales, count: {result.Count}"
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

    public void Update(Sale item)
    {
        try
        {
            var q = from s in Sales
                    where s.SaleId == item.SaleId
                    select s;

            Sale? sale = q.FirstOrDefault();
            if (sale == null)
            {
                LogManager.WriteLog(
                    MethodBase.GetCurrentMethod().DeclaringType.Name,
                    MethodBase.GetCurrentMethod().Name,
                    $"ERROR: Sale with ID {item.SaleId} not found."
                );
                throw new DalItemNotFoundException($"Sale with ID {item.SaleId} not found.");
            }

            int idx = Sales.IndexOf(sale);
            if (idx == -1)
            {
                LogManager.WriteLog(
                    MethodBase.GetCurrentMethod().DeclaringType.Name,
                    MethodBase.GetCurrentMethod().Name,
                    $"ERROR: Sale with ID {item.SaleId} not found."
                );
                throw new DalItemNotFoundException($"Sale with ID {item.SaleId} not found.");
            }

            Sales[idx] = item;
            LogManager.WriteLog(
                MethodBase.GetCurrentMethod().DeclaringType.Name,
                MethodBase.GetCurrentMethod().Name,
                $"Updated sale with ID: {item.SaleId}"
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
}

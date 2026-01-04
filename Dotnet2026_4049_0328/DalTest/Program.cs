using Dal;
using DalApi;
using DO;

namespace DalTest;

class Program
{
    private static IDal s_dal = new Dal.DalList();

    static void Main()
    {
        try
        {
            Initialization.Initialize(s_dal);

            RunMenuLoop();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Unhandled exception: " + ex);
        }
    }

    private static void RunMenuLoop()
    {
        bool exit = false;
        while (!exit)
        {
            try
            {
                int choice = ShowMainMenu();
                switch (choice)
                {
                    case 1: CrudEntity("Customer"); break;
                    case 2: CrudEntity("Product"); break;
                    case 3: CrudEntity("Sale"); break;
                    case 4: exit = true; break;
                    default: Console.WriteLine("Unknown choice."); break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);
            }
        }
    }

    private static int ShowMainMenu()

    {
        Console.WriteLine();
        Console.WriteLine("Main menu:");
        Console.WriteLine("1. Customer");
        Console.WriteLine("2. Product");
        Console.WriteLine("3. Sale");
        Console.WriteLine("4. Exit");
        Console.Write("Select entity: ");
        var s = Console.ReadLine();
        if (int.TryParse(s, out int c)) return c;
        return -1;
    }

    private static void CrudEntity(string entity)
    {
        bool back = false;
        while (!back)
        {
            int choice = ShowCrudMenu(entity);
            switch (choice)
            {
                case 1: Create(entity); break;
                case 2:
                    if (entity == "Customer") Read();
                    else if (entity == "Product") Read(s_dal.Product);
                    else if (entity == "Sale") Read(s_dal.Sale);
                    break;
                case 3:
                    if (entity == "Customer") ReadAll(s_dal.Customer);
                    else if (entity == "Product") ReadAll(s_dal.Product);
                    else if (entity == "Sale") ReadAll(s_dal.Sale);
                    break;
                case 4: Update(entity); break;
                case 5:
                    if (entity == "Customer") Delete(s_dal.Customer);
                    else if (entity == "Product") Delete(s_dal.Product);
                    else if (entity == "Sale") Delete(s_dal.Sale);
                    break;
                case 6: back = true; break;
                default: Console.WriteLine("Unknown choice."); break;
            }
        }
    }

    private static int ShowCrudMenu(string entity)
    {
        Console.WriteLine();
        Console.WriteLine($"CRUD menu for {entity}:");
        Console.WriteLine("1. Create");
        Console.WriteLine("2. Read by id");
        Console.WriteLine("3. Read all");
        Console.WriteLine("4. Update");
        Console.WriteLine("5. Delete");
        Console.WriteLine("6. Back");
        Console.Write("Select operation: ");
        var s = Console.ReadLine();
        if (int.TryParse(s, out int c)) return c;
        return -1;
    }

   
    
}


       

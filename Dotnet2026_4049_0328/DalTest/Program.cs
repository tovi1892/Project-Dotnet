using Dal;
using DalApi;
using DO;

namespace DalTest;

class Program
{
    private static readonly IDal s_dal = new Dal.DalList();



    static void Main()
    {
        try
        {
            Initialization.Initialize(s_dal);
            RunMenuLoop();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
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
                    case 1: CrudCustomer(); break;
                    case 2: CrudProduct(); break;
                    case 3: CrudSale(); break;
                    case 4: exit = true; break;
                    default: Console.WriteLine("Invalid choice"); break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }

    private static int ShowMainMenu()
    {
        Console.WriteLine();
        Console.WriteLine("Main Menu");
        Console.WriteLine("1. Customer");
        Console.WriteLine("2. Product");
        Console.WriteLine("3. Sale");
        Console.WriteLine("4. Exit");
        Console.Write("Choice: ");
        return int.TryParse(Console.ReadLine(), out int c) ? c : -1;
    }

    private static int ShowCrudMenu(string entity)
    {
        Console.WriteLine();
        Console.WriteLine($"{entity} CRUD");
        Console.WriteLine("1. Create");
        Console.WriteLine("2. Read");
        Console.WriteLine("3. Read All");
        Console.WriteLine("4. Update");
        Console.WriteLine("5. Delete");
        Console.WriteLine("6. Back");
        Console.Write("Choice: ");
        return int.TryParse(Console.ReadLine(), out int c) ? c : -1;
    }


    private static void Read<T>(ICrud<T> repo)
    {
        Console.Write("Enter id: ");
        if (int.TryParse(Console.ReadLine(), out int id))
            Console.WriteLine(repo.Read(id));
    }

    private static void ReadAll<T>(ICrud<T> repo)
    {
        foreach (var item in repo.ReadAll())
            Console.WriteLine(item);
    }

    private static void Delete<T>(ICrud<T> repo)
    {
        Console.Write("Enter id: ");
        if (int.TryParse(Console.ReadLine(), out int id))
            repo.Delete(id);
    }


    private static void CrudCustomer()
    {
        bool back = false;
        while (!back)
        {
            int choice = ShowCrudMenu("Customer");
            switch (choice)
            {
                case 1: CreateCustomer(); break;
                case 2: Read(s_dal.Customer); break;
                case 3: ReadAll(s_dal.Customer); break;
                case 4: UpdateCustomer(); break;
                case 5: Delete(s_dal.Customer); break;
                case 6: back = true; break;
            }
        }
    }

    private static void CreateCustomer()
    {
        
        Console.Write("Name: ");
        string name = Console.ReadLine()!;
        Console.Write("Address: ");
        string address = Console.ReadLine()!;

        Customer c = new Customer {  CustomerName = name, CustomerAddress = address };
        s_dal.Customer.Create(c);
        Console.WriteLine(   s_dal.Customer.Read(c.CustomerId)); 

    }

    private static void UpdateCustomer()
    {
        Console.Write("Id: ");
        int.TryParse(Console.ReadLine(), out int id);
        Console.Write("New Name: ");
        string name = Console.ReadLine()!;
        Console.Write("New Address: ");
        string address = Console.ReadLine()!;

        Customer c = new Customer { CustomerId = id, CustomerName = name, CustomerAddress = address };
        s_dal.Customer.Update(c);
        s_dal.Customer.Read(c.CustomerId);

    }


    private static void CrudProduct()
    {
        bool back = false;
        while (!back)
        {
            int choice = ShowCrudMenu("Product");
            switch (choice)
            {
                case 1: CreateProduct(); break;
                case 2: Read(s_dal.Product); break;
                case 3: ReadAll(s_dal.Product); break;
                case 4: UpdateProduct(); break;
                case 5: Delete(s_dal.Product); break;
                case 6: back = true; break;
            }
        }
    }

    private static void CreateProduct()
    {
        //Console.Write("Id: ");
        //int.TryParse(Console.ReadLine(), out int id);
        Console.Write("Name: ");
        string name = Console.ReadLine()!;
        Console.Write("Price: ");
        double.TryParse(Console.ReadLine(), out double price);

        Product p = new Product { ProductName = name, Price = price };
        s_dal.Product.Create(p);
    }

    private static void UpdateProduct()
    {
        Console.Write("Id: ");
        int.TryParse(Console.ReadLine(), out int id);
        Console.Write("New Name: ");
        string name = Console.ReadLine()!;
        Console.Write("New Price: ");
        double.TryParse(Console.ReadLine(), out double price);

        Product p = new Product { ProductId = id, ProductName = name, Price = price };
        s_dal.Product.Update(p);
    }


    private static void CrudSale()
    {
        bool back = false;
        while (!back)
        {
            int choice = ShowCrudMenu("Sale");
            switch (choice)
            {
                case 1: CreateSale(); break;
                case 2: Read(s_dal.Sale); break;
                case 3: ReadAll(s_dal.Sale); break;
                case 4: UpdateSale(); break;
                case 5: Delete(s_dal.Sale); break;
                case 6: back = true; break;
            }
        }
    }

    private static void CreateSale()
    {
        //Console.Write("Id: ");
        //int.TryParse(Console.ReadLine(), out int id);
        Console.Write("Product Id: ");
        int.TryParse(Console.ReadLine(), out int productId);
        Console.Write("Price: ");
        double.TryParse(Console.ReadLine(), out double price);

        Sale s = new Sale {  ProductId = productId, TotalPrice = price };
        s_dal.Sale.Create(s);
    }

    private static void UpdateSale()
    {
        Console.Write("Id: ");
        int.TryParse(Console.ReadLine(), out int id);
        Console.Write("Product Id: ");
        int.TryParse(Console.ReadLine(), out int productId);
        Console.Write("Price: ");
        double.TryParse(Console.ReadLine(), out double price);

        Sale s = new Sale { SaleId = id, ProductId = productId, TotalPrice = price };
        s_dal.Sale.Update(s);
    }
}


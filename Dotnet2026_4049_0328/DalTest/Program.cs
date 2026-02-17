//using Dal;
//using DalApi;
//using DO;

//namespace DalTest;

//class Program
//{
//    public delegate bool FilterDel<T>(T x);
//    private static readonly IDal s_dal = new Dal.DalList();


//    public static bool CustomerFilter(Customer c) => c.CustomerName == "tovi";
//    public static bool ProductFilter(Product p) => p.Price > 2;
//    public static bool SaleFilter(Sale s) => s.TotalPrice > 1;



//    static void Main()
//    {
//        try
//        {
//            Initialization.Initialize(s_dal);
//            RunMenuLoop();
//        }
//        catch (Exception ex)
//        {
//            Console.WriteLine(ex);
//        }
//    }

//    private static void RunMenuLoop()
//    {
//        bool exit = false;
//        while (!exit)
//        {
//            try
//            {
//                int choice = ShowMainMenu();
//                switch (choice)
//                {
//                    case 1: CrudCustomer(); break;
//                    case 2: CrudProduct(); break;
//                    case 3: CrudSale(); break;
//                    case 4: exit = true; break;
//                    default: Console.WriteLine("Invalid choice"); break;
//                }
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine(ex);
//            }
//        }
//    }

//    private static int ShowMainMenu()
//    {
//        Console.WriteLine();
//        Console.WriteLine("Main Menu");
//        Console.WriteLine("1. Customer");
//        Console.WriteLine("2. Product");
//        Console.WriteLine("3. Sale");
//        Console.WriteLine("4. Exit");
//        Console.Write("Choice: ");
//        return int.TryParse(Console.ReadLine(), out int c) ? c : -1;
//    }

//    private static int ShowCrudMenu(string entity)
//    {
//        Console.WriteLine();
//        Console.WriteLine($"{entity} CRUD");
//        Console.WriteLine("1. Create");
//        Console.WriteLine("2. Read");
//        Console.WriteLine("3. Read All");
//        Console.WriteLine("4. Update");
//        Console.WriteLine("5. Delete");
//        Console.WriteLine("6. Back");
//        Console.Write("Choice: ");
//        return int.TryParse(Console.ReadLine(), out int c) ? c : -1;
//    }


//    private static void Read<T>(ICrud<T> repo)
//    {
//        FilterDel<T>? del = null;

//        if (typeof(T) == typeof(Customer))
//            del = (FilterDel<T>)(object)new FilterDel<Customer>(CustomerFilter);
//        else if (typeof(T) == typeof(Product))
//            del = (FilterDel<T>)(object)new FilterDel<Product>(ProductFilter);
//        else if (typeof(T) == typeof(Sale))
//            del = (FilterDel<T>)(object)new FilterDel<Sale>(SaleFilter);

//        if (del != null)
//            Console.WriteLine(repo.Read(x => del(x)));
//        else
//            Console.WriteLine(repo.Read(x => true));
//    }



//    private static void ReadAll<T>(ICrud<T> repo)
//    {
//        foreach (var item in repo.ReadAll())
//            Console.WriteLine(item);
//    }

//    private static void Delete<T>(ICrud<T> repo)
//    {
//        Console.Write("Enter id: ");
//        if (int.TryParse(Console.ReadLine(), out int id))
//            repo.Delete(id);
//    }


//    private static void CrudCustomer()
//    {
//        bool back = false;
//        while (!back)
//        {
//            int choice = ShowCrudMenu("Customer");
//            switch (choice)
//            {
//                case 1: CreateCustomer(); break;
//                case 2: Read(s_dal.Customer); break;
//                case 3: ReadAll(s_dal.Customer); break;
//                case 4: UpdateCustomer(); break;
//                case 5: Delete(s_dal.Customer); break;
//                case 6: back = true; break;
//            }
//        }
//    }

//    private static void CreateCustomer()
//    {
//        Console.Write("Id: ");
//        int id= Console.Read();
//        Console.ReadLine();
//        Console.Write("Name: ");
//        string name = Console.ReadLine()!;
//        Console.Write("Address: ");
//        string address = Console.ReadLine()!;

//        Customer c = new Customer { CustomerId=id, CustomerName = name, CustomerAddress = address };
//        s_dal.Customer.Create(c);
//        //Console.WriteLine(s_dal.Customer.Read(c.CustomerId)); 
//    }

//    private static void UpdateCustomer()
//    {
//        Console.Write("Id: ");
//        int.TryParse(Console.ReadLine(), out int id);
//        Console.Write("New Name: ");
//        string name = Console.ReadLine()!;
//        Console.Write("New Address: ");
//        string address = Console.ReadLine()!;

//        Customer c = new Customer { CustomerId = id, CustomerName = name, CustomerAddress = address };
//        s_dal.Customer.Update(c);

//        Console.WriteLine(s_dal.Customer.Read(c => c.CustomerName == "tovi"));

//    }


//    private static void CrudProduct()
//    {
//        bool back = false;
//        while (!back)
//        {
//            int choice = ShowCrudMenu("Product");
//            switch (choice)
//            {
//                case 1: CreateProduct(); break;
//                case 2: Read(s_dal.Product); break;
//                case 3: ReadAll(s_dal.Product); break;
//                case 4: UpdateProduct(); break;
//                case 5: Delete(s_dal.Product); break;
//                case 6: back = true; break;
//            }
//        }
//    }

//    private static void CreateProduct()
//    {

//        Console.Write("Name: ");
//        string name = Console.ReadLine()!;
//        Console.Write("Price: ");
//        double.TryParse(Console.ReadLine(), out double price);
//        Console.Write("Bracelets-0, Earrings-1, Necklaces-2, Rings-3, Watches-4");
//        Categories c=(Categories)int.Parse(Console.ReadLine()??"0");
//        Console.Write("QuantityInStock: ");
//        int QuantityInStock = Console.Read()!;

//        Product p = new Product { ProductName = name, Category = c, QuantityInStock= QuantityInStock, Price = price };
//        s_dal.Product.Create(p);
//        Console.WriteLine(s_dal.Product.Read(p => p.Price>20));


//    }

//    private static void UpdateProduct()
//    {
//        Console.Write("Id: ");
//        int.TryParse(Console.ReadLine(), out int id);
//        Console.Write("New Name: ");
//        string name = Console.ReadLine()!;
//        Console.Write("New Price: ");
//        double.TryParse(Console.ReadLine(), out double price);

//        Product p = new Product { ProductId = id, ProductName = name, Price = price };
//        s_dal.Product.Update(p);
//        Console.WriteLine(s_dal.Product.Read(p => p.Price > 20));
//    }


//    private static void CrudSale()
//    {
//        bool back = false;
//        while (!back)
//        {
//            int choice = ShowCrudMenu("Sale");
//            switch (choice)
//            {
//                case 1: CreateSale(); break;
//                case 2: Read(s_dal.Sale); break;
//                case 3: ReadAll(s_dal.Sale); break;
//                case 4: UpdateSale(); break;
//                case 5: Delete(s_dal.Sale); break;
//                case 6: back = true; break;
//            }
//        }
//    }

//    private static void CreateSale()
//    {

//        Console.Write("Product Id: ");
//        int.TryParse(Console.ReadLine(), out int productId);
//        Console.Write("Price: ");
//        double.TryParse(Console.ReadLine(), out double price);

//        Sale s = new Sale {  ProductId = productId, TotalPrice = price };
//        s_dal.Sale.Create(s);
//        //Console.WriteLine(s_dal.Customer.Read(s.SaleId));
//    }

//    private static void UpdateSale()
//    {
//        Console.Write("Id: ");
//        int.TryParse(Console.ReadLine(), out int id);
//        Console.Write("Product Id: ");
//        int.TryParse(Console.ReadLine(), out int productId);
//        Console.Write("Price: ");
//        double.TryParse(Console.ReadLine(), out double price);

//        Sale s = new Sale { SaleId = id, ProductId = productId, TotalPrice = price };

//        //s_dal.Sale.Update(s);
//        //Console.WriteLine(s_dal.Customer.Read(s.SaleId));

//    }
//}

using Dal;
using DalApi;
using DO;
using Tools__;
using System.Reflection;

namespace DalTest;

class Program
{
    public delegate bool FilterDel<T>(T x);
    private static readonly IDal s_dal = new Dal.DalList();

    public static bool CustomerFilter(Customer c) => c.CustomerName == "tovi";
    public static bool ProductFilter(Product p) => p.Price > 2;
    public static bool SaleFilter(Sale s) => s.TotalPrice > 1;

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
                    case 5: LogManager.cleanLogs(); break;
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
        Console.WriteLine("5.clean logs");
        Console.Write("Choice: ");
        return int.TryParse(Console.ReadLine(), out int c) ? c : -1;
    }

    private static int ShowCrudMenu(string entity)
    {
        Console.WriteLine();
        Console.WriteLine($"{entity} CRUD");
        Console.WriteLine("1. Create");
        Console.WriteLine("2. Read by Filter");
        Console.WriteLine("3. Read by ID");
        Console.WriteLine("4. Read All");
        Console.WriteLine("5. Update");
        Console.WriteLine("6. Delete");
        Console.WriteLine("7. Back");
        Console.Write("Choice: ");
        return int.TryParse(Console.ReadLine(), out int c) ? c : -1;
    }

    // Read by filter (delegate)
    private static void ReadByFilter<T>(ICrud<T> repo)
    {
        FilterDel<T>? del = null;

        if (typeof(T) == typeof(Customer))
            del = (FilterDel<T>)(object)new FilterDel<Customer>(CustomerFilter);
        else if (typeof(T) == typeof(Product))
            del = (FilterDel<T>)(object)new FilterDel<Product>(ProductFilter);
        else if (typeof(T) == typeof(Sale))
            del = (FilterDel<T>)(object)new FilterDel<Sale>(SaleFilter);

        if (del != null)
            Console.WriteLine(repo.Read(x => del(x)));
        else
            Console.WriteLine(repo.Read(x => true));
    }

    // Read by ID
    private static void ReadById<T>(ICrud<T> repo)
    {
        //Console.Write("Enter id: ");
        //if (int.TryParse(Console.ReadLine(), out int id))
        //{
        //    try
        //    {
        //        var result = repo.Read(id);
        //        Console.WriteLine(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Error: {ex.Message}");
        //    }
        //}
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
                case 2: ReadByFilter(s_dal.Customer); break;
                case 3: ReadById(s_dal.Customer); break;
                case 4: ReadAll(s_dal.Customer); break;
                case 5: UpdateCustomer(); break;
                case 6: Delete(s_dal.Customer); break;
                case 7: back = true; break;
            }
        }
    }

    private static void CreateCustomer()
    {
        Console.Write("Id: ");
        int.TryParse(Console.ReadLine(), out int id);
        Console.Write("Name: ");
        string name = Console.ReadLine()!;
        Console.Write("Address: ");
        string address = Console.ReadLine()!;

        Customer c = new Customer { CustomerId = id, CustomerName = name, CustomerAddress = address };
        s_dal.Customer.Create(c);
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

        Console.WriteLine(s_dal.Customer.Read(c => c.CustomerName == "tovi"));
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
                case 2: ReadByFilter(s_dal.Product); break;
                case 3: ReadById(s_dal.Product); break;
                case 4: ReadAll(s_dal.Product); break;
                case 5: UpdateProduct(); break;
                case 6: Delete(s_dal.Product); break;
                case 7: back = true; break;
            }
        }
    }

    private static void CreateProduct()
    {
        Console.Write("Name: ");
        string name = Console.ReadLine()!;
        Console.Write("Price: ");
        double.TryParse(Console.ReadLine(), out double price);
        Console.Write("Bracelets-0, Earrings-1, Necklaces-2, Rings-3, Watches-4: ");
        Categories c = (Categories)int.Parse(Console.ReadLine() ?? "0");
        Console.Write("QuantityInStock: ");
        int.TryParse(Console.ReadLine(), out int quantityInStock);

        Product p = new Product { ProductName = name, Category = c, QuantityInStock = quantityInStock, Price = price };
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
        Console.WriteLine(s_dal.Product.Read(prod => prod.Price > 20));
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
                case 2: ReadByFilter(s_dal.Sale); break;
                case 3: ReadById(s_dal.Sale); break;
                case 4: ReadAll(s_dal.Sale); break;
                case 5: UpdateSale(); break;
                case 6: Delete(s_dal.Sale); break;
                case 7: back = true; break;
            }
        }
    }

    private static void CreateSale()
    {
        Console.Write("Product Id: ");
        int.TryParse(Console.ReadLine(), out int productId);
        Console.Write("Price: ");
        double.TryParse(Console.ReadLine(), out double price);

        Sale s = new Sale { ProductId = productId, TotalPrice = price };
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
        // יש להשלים מימוש עדכון במידת הצורך
        // s_dal.Sale.Update(s);
    }
}

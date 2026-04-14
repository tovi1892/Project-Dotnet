using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using DalApi;
using DO;

namespace Dal
{
    internal class ProductDalXml : IProduct
    {
        readonly string s_path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "xml", "products.xml");

        // helper to convert XElement -> DO.Product
        static DO.Product CreateProductFromElement(XElement p) => new DO.Product(
            (int?)p.Element("ProductId") ?? 0,
            (string?)p.Element("ProductName") ?? string.Empty,
            Enum.TryParse<DO.Categories>((string?)p.Element("Category") ?? string.Empty, out var res) ? res : default,
            (int?)p.Element("QuantityInStock") ?? 0,
            (double?)p.Element("Price") ?? 0.0
        );

        public int Create(Product item)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(s_path) ?? ".");
            if (!File.Exists(s_path))
                new XElement("ArrayOfProduct").Save(s_path);

            XElement root = XElement.Load(s_path);
            int nextId = Config.ProductNum;

            var p = new XElement("Product",
                new XElement("ProductId", nextId),
                new XElement("ProductName", item.ProductName),
                new XElement("Category", item.Category.ToString()),
                new XElement("Price", item.Price),
                new XElement("QuantityInStock", item.QuantityInStock)
            );

            root.Add(p);
            root.Save(s_path);
            return nextId;
        }

        // ICrud<T> expects Read(Func<T,bool>) - keep also Read by id for convenience
        public Product? Read(Func<Product, bool> filter)
        {
            if (!File.Exists(s_path)) throw new Exception("Products XML not found.");
            var q = XElement.Load(s_path).Elements("Product")
                .Select(CreateProductFromElement)
                .FirstOrDefault(filter);
            return q;
        }

        // convenience overload used in some places
        public Product? Read(int id)
        {
            return Read(p => p.ProductId == id);
        }

        public List<Product?> ReadAll(Func<Product, bool>? filter = null)
        {
            if (!File.Exists(s_path)) return new List<Product?>();
            var list = XElement.Load(s_path).Elements("Product")
                       .Select(CreateProductFromElement);
            return filter == null ? list.Cast<Product?>().ToList() : list.Where(filter).Cast<Product?>().ToList();
        }

        public void Update(Product item)
        {
            if (!File.Exists(s_path)) throw new Exception("Products XML not found.");
            XElement root = XElement.Load(s_path);
            XElement? p = root.Elements("Product").FirstOrDefault(x => ((int?)x.Element("ProductId") ?? 0) == item.ProductId);

            if (p == null) throw new Exception("Product not found");

            p.Element("ProductName")!.Value = item.ProductName;
            p.Element("Category")!.Value = item.Category.ToString();
            p.Element("Price")!.Value = item.Price.ToString();
            p.Element("QuantityInStock")!.Value = item.QuantityInStock.ToString();

            root.Save(s_path);
        }

        public void Delete(int id)
        {
            if (!File.Exists(s_path)) throw new Exception("Products XML not found.");
            XElement root = XElement.Load(s_path);
            XElement? p = root.Elements("Product").FirstOrDefault(x => ((int?)x.Element("ProductId") ?? 0) == id);

            if (p == null) throw new Exception("Product not found");

            p.Remove();
            root.Save(s_path);
        }
    }
}
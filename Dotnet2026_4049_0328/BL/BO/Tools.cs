using System;
using System.Collections;
using System.Linq;
using System.Reflection;
using System.Text;
using DO;

namespace BO
{
    internal static class Tools
    {
        // Reflection-based stringification
        public static string ToStringProperty<T>(this T obj)
        {
            return ToStringPropertyInternal(obj, 0);
        }

        private static string ToStringPropertyInternal(object? obj, int depth)
        {
            if (obj is null) return "null";

            const int MaxDepth = 5;
            if (depth > MaxDepth) return "...(max depth reached)...";

            var type = obj.GetType();

            if (IsSimple(type))
            {
                return obj.ToString() ?? string.Empty;
            }

            if (obj is IEnumerable enumerable && !(obj is string))
            {
                var sbEnum = new StringBuilder();
                sbEnum.Append('[');
                bool first = true;
                foreach (var item in enumerable)
                {
                    if (!first) sbEnum.Append(", ");
                    sbEnum.Append(ToStringPropertyInternal(item, depth + 1));
                    first = false;
                }
                sbEnum.Append(']');
                return sbEnum.ToString();
            }

            var props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                            .OrderBy(p => p.Name);

            var sb = new StringBuilder();
            sb.Append(type.Name);
            sb.Append(" { ");

            foreach (var p in props)
            {
                object? value;
                try { value = p.GetValue(obj); }
                catch { value = null; }

                sb.Append(p.Name);
                sb.Append(" = ");
                sb.Append(value == null ? "null" : ToStringPropertyInternal(value, depth + 1));
                sb.Append("; ");
            }

            sb.Append(" }");
            return sb.ToString();
        }

        private static bool IsSimple(Type type)
        {
            return type.IsPrimitive
                || type.IsEnum
                || type == typeof(string)
                || type == typeof(decimal)
                || type == typeof(DateTime)
                || type == typeof(DateTimeOffset)
                || type == typeof(TimeSpan)
                || type == typeof(Guid);
        }

        // --- Conversion methods between DO and BO (extension methods) ---

        // Product conversions
        public static Product ToBo(this DO.Product d)
        {
            if (d is null) return null!;
            return new Product
            {
                Id = d.ProductId,
                Name = d.ProductName,
                Category = (Categories)d.Category,
                QuantityInStock = d.QuantityInStock,
                Price = d.Price
            };
        }

        public static DO.Product ToDo(this Product b)
        {
            if (b is null) return null!;
            return new DO.Product(
                b.Id,
                b.Name ?? string.Empty,
                (DO.Categories)b.Category,
                b.QuantityInStock,
                b.Price
            );
        }

        // Customer conversions
        public static Customer ToBo(this DO.Customer d)
        {
            if (d is null) return null!;
            return new Customer
            {
                Id = d.CustomerId,
                Name = d.CustomerName,
                Address = d.CustomerAddress,
                PhoneNumber = d.CustomerPhone
            };
        }

        public static DO.Customer ToDo(this Customer b)
        {
            if (b is null) return null!;
            return new DO.Customer(
                b.Id,
                b.Name ?? string.Empty,
                b.Address ?? string.Empty,
                b.PhoneNumber ?? string.Empty
            );
        }

        // Sale conversions
        public static Sale ToBo(this DO.Sale d)
        {
            if (d is null) return null!;
            return new Sale
            {
                Id = d.SaleId,
                ProductId = d.ProductId,
                Quantity = d.QuantityToSale,
                TotalPrice = d.TotalPrice,
                IsClub = d.IsClube,
                SaleStartDate = d.StartSale,
                SaleEndDate = d.EndSale
            };
        }

        public static DO.Sale ToDo(this Sale b)
        {
            if (b is null) return null!;
            return new DO.Sale(
                b.Id,
                b.ProductId,
                b.Quantity,
                b.TotalPrice,
                b.IsClub,
                b.SaleStartDate,
                b.SaleEndDate
            );
        }
    }
}
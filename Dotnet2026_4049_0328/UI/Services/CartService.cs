using System;
using System.ComponentModel;
using System.Linq;
using BO;

namespace UI.Services
{
    // שירות עגלה שיתופי בין טפסים (BindingList בשביל binding UI אוטומטי)
    public static class CartService
    {
        public static BindingList<CartLine> Cart { get; } = new();

        public static event EventHandler? CartChanged;

        public static void AddProduct(BO.Product? product, int quantity)
        {
            if (product is null) return;
            if (quantity <= 0) return;

            var existing = Find(product.Id);
            if (existing != null)
            {
                existing.Quantity += quantity;
                existing.LineTotal = existing.Quantity * existing.UnitPrice;
            }
            else
            {
                Cart.Add(new CartLine
                {
                    ProductId = product.Id,
                    Name = product.Name,
                    Quantity = quantity,
                    UnitPrice = product.Price,
                    LineTotal = quantity * product.Price
                });
            }

            CartChanged?.Invoke(null, EventArgs.Empty);
        }

        public static CartLine? Find(int productId) => Cart.FirstOrDefault(c => c.ProductId == productId);

        public static void Clear()
        {
            Cart.Clear();
            CartChanged?.Invoke(null, EventArgs.Empty);
        }
    }

    public class CartLine
    {
        public int ProductId { get; set; }
        public string? Name { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double LineTotal { get; set; }
    }
}
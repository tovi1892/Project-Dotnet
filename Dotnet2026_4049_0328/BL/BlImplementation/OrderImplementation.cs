using System;
using System.Collections.Generic;
using System.Linq;
using BO;
using BL.BlApi;

namespace BL.BlImplementation;

internal class OrderImplementation : IOrder
{
        private readonly ProductImplementation _prod = new ProductImplementation();
        private readonly SaleImplementation _sale = new SaleImplementation();

        public List<ProductInOrder> AddProductToOrder(Order order, int productId, int quantity)
        {
            if (order == null)
                order = new Order();

            var product = _prod.Read(productId);
            if (product == null)
                throw new Exception($"Product {productId} not found.");

            var pio = order.Products.FirstOrDefault(p => p.ProductId == productId);
            if (pio == null)
            {
                pio = new ProductInOrder
                {
                    ProductId = product.Id,
                    Name = product.Name ?? string.Empty,
                    BasePrice = product.Price,
                    Quantity_in_order = Math.Max(1, quantity)
                };
                order.Products.Add(pio);
            }
            else
            {
                pio.Quantity_in_order += Math.Max(1, quantity);
            }

            CalcTotalPriceForProduct(pio);
            SearchSaleForProduct(pio, order.IsPreferredClient);
            CalcTotalPrice(order);

            return order.Products;
        }

        public void CalcTotalPriceForProduct(BO.ProductInOrder productInOrder)
        {
            if (productInOrder == null) return;
            // Base calculation: base price * quantity
            productInOrder.FinalPrice_in_total = productInOrder.BasePrice * productInOrder.Quantity_in_order;

            // If there are sales attached, choose the best price (lower)
            if (productInOrder.Sales != null && productInOrder.Sales.Any())
            {
                // Example: if sale.TotalPrice denotes price for quantity, compute discounted unit price
                var bestUnit = productInOrder.BasePrice;
                foreach (var s in productInOrder.Sales)
                {
                    if (s.Quantity > 0)
                    {
                        var unit = s.TotalPrice / Math.Max(s.Quantity, 1);
                        if (unit < bestUnit) bestUnit = unit;
                    }
                    else if (s.TotalPrice > 0 && s.TotalPrice < bestUnit)
                    {
                        bestUnit = s.TotalPrice;
                    }
                }

                productInOrder.FinalPrice_in_total = bestUnit * productInOrder.Quantity_in_order;
            }
        }

        public void CalcTotalPrice(Order order)
        {
            if (order == null) return;
            double sum = 0.0;
            foreach (var p in order.Products)
            {
                CalcTotalPriceForProduct(p);
                sum += p.FinalPrice_in_total;
            }
            order.FinalPrice = sum;
        }

        public void DoOrder(Order order)
        {
            if (order == null) throw new ArgumentNullException(nameof(order));
            // Minimal behaviour: compute final price (real implementation would persist sale records, adjust stock etc.)
            CalcTotalPrice(order);
            // If further persistence needed, extend here by calling other BL methods (Sale.Create, Product.Update, etc.)
        }

        public void SearchSaleForProduct(BO.ProductInOrder productInOrder, bool isPreferredClient)
        {
            if (productInOrder == null) return;
            productInOrder.Sales.Clear();

            List<BO.Sale> allSales;
            try
            {
                allSales = _sale.ReadAll() ?? new List<BO.Sale>();
            }
            catch
            {
                allSales = new List<BO.Sale>();
            }

            var now = DateTime.Now;
            foreach (var s in allSales)
            {
                if (s == null) continue;
                if (s.ProductId != productInOrder.ProductId) continue;
                if (now < s.SaleStartDate || now > s.SaleEndDate) continue;
                if (s.IsClub && !isPreferredClient) continue;

                productInOrder.Sales.Add(new SaleInProduct
                {
                    SaleId = s.Id,
                    ProductId = s.ProductId,
                    Quantity = s.Quantity,
                    TotalPrice = s.TotalPrice,
                    IsClub = s.IsClub,
                    SaleStartDate = s.SaleStartDate,
                    SaleEndDate = s.SaleEndDate
                });
            }

            CalcTotalPriceForProduct(productInOrder);
        }
    }

    //public class ProductInOrder
    //{
    //    public int ProductId { get; set; }
    //    public string? Name { get; set; }
    //    public double BasePrice { get; set; }
    //    public int Quantity_in_order { get; set; }
    //    public double FinalPrice_in_total { get; set; }
    //    public List<SaleInProduct> Sales { get; set; } = new();
    //    public override string ToString()
    //    {
    //        return $"{Name} - {Quantity_in_order} x {BasePrice:C} = {FinalPrice_in_total:C}";
    //    }
    //}

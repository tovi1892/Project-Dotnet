using System;
using System.Collections.Generic;

namespace BO
{
    public class Order
    {
        public List<ProductInOrder> Products { get; set; } = new List<ProductInOrder>();
        public double FinalPrice { get; set; }
        public bool IsPreferredClient { get; set; }
    }

    //public class ProductInOrder
    //{
    //    public int ProductId { get; set; }
    //    public string? Name { get; set; }
    //    public double BasePrice { get; set; }
    //    public int Quantity_in_order { get; set; }
    //    public double FinalPrice_in_total { get; set; }
    //    public List<SaleInProduct> Sales { get; set; } = new List<SaleInProduct>();
    //}

    //public class SaleInProduct
    //{
    //    public int SaleId { get; set; }
    //    public int ProductId { get; set; }
    //    public int Quantity { get; set; }         // quantity covered by sale
    //    public double TotalPrice { get; set; }   // total price for the sale package (if provided)
    //    public bool IsClub { get; set; }
    //    public DateTime SaleStartDate { get; set; }
    //    public DateTime SaleEndDate { get; set; }
    //}
}
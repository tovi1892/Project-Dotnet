using System;

namespace BO
{
    public class Sale
    {
        public int Id { get; init; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public double TotalPrice { get; set; }
        public bool IsClub { get; set; }
        public DateTime SaleStartDate { get; set; }
        public DateTime SaleEndDate { get; set; }

        // fixed recursion -> use reflection-based printer
        public override string ToString() => this.ToStringProperty();
    }
}

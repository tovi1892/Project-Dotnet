using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Product
    {
        public int Id { get; init; }
        public string? Name { get; set; }
        public Categories Category { get; set; }
        public int QuantityInStock { get; set; }
        public double Price { get; set; }

        public override string ToString() => this.ToStringProperty();
    }
}

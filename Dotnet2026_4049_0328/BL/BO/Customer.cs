using System;

namespace BO
{
    public class Customer
    {
        public int Id { get; init; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }

        public override string ToString() => this.ToStringProperty();
    }
}

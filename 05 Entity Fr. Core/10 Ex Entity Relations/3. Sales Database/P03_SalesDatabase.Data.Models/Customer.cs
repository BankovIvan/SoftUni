namespace P03_SalesDatabase.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Customer
    {
        public Customer()
        {
            this.Sales = new HashSet<Sale>();
        }

        public int CustomerId { get; set; }

        public string Name { get; set; } = null!;

        public string Email  { get; set; } = null!;

        public string CreditCardNumber { get; set; } = null!;

        public virtual ICollection<Sale> Sales { get; set; }

    }
}

namespace P03_SalesDatabase.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Store
    {
        public Store()
        {
            this.Sales = new HashSet<Sale>();
        }

        public int StoreId { get; set; }

        public string Name { get; set; } = null!;

        public virtual ICollection<Sale> Sales { get; set; }

    }
}

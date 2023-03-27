namespace Trucks.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Despatcher
    {
        public Despatcher()
        {
            this.Trucks = new HashSet<Truck>();
        }

        public int Id { get; set; }

        public string Name { get; set; } = null!;
        
        public string? Position  { get; set; }

        public virtual ICollection<Truck> Trucks { get; set; }

    }
}

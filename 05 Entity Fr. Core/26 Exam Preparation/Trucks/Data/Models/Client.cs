namespace Trucks.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Client
    {
        public Client()
        {
            this.ClientsTrucks = new HashSet<ClientTruck>();
        }

        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Nationality  { get; set; } = null!;

        public string Type { get; set; } = null!;

        public virtual ICollection<ClientTruck> ClientsTrucks { get; set; }

    }
}

namespace Trucks.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Trucks.Data.Models.Enums;

    public class Truck
    {
        public Truck()
        {
            this.ClientsTrucks = new HashSet<ClientTruck>();
        }

        public int Id { get; set; }

        public string RegistrationNumber { get; set; } = null!;

        public string VinNumber { get; set; } = null!;

        public int TankCapacity { get; set; }

        public int CargoCapacity { get; set; }

        public CategoryType CategoryType { get; set; }

        public MakeType MakeType { get; set; }

        public int DespatcherId { get; set; }

        public virtual Despatcher Despatcher { get; set; } = null!;

        public virtual ICollection<ClientTruck> ClientsTrucks { get; set; }
         

    }
}

namespace Trucks.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ClientTruck
    {
        public int ClientId  { get; set; }

        public virtual Client Client { get; set; } = null!;

        public int TruckId { get; set; }

        public virtual Truck Truck { get; set; } = null!;

    }
}

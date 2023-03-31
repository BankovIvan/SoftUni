namespace Artillery.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Manufacturer
    {
        public Manufacturer()
        {
            this.Guns = new HashSet<Gun>();
        }

        public int Id { get; set; }

        public string ManufacturerName { get; set; } = null!;

        public string Founded { get; set; } = null!;

        public virtual ICollection<Gun> Guns { get; set; } = null!;

    }
}

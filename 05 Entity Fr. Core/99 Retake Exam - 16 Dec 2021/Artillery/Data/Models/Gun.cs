namespace Artillery.Data.Models
{
    using Artillery.Data.Models.Enums;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Gun
    {
        public Gun()
        {
            this.CountriesGuns = new HashSet<CountryGun>();
        }


        public int Id { get; set; }

        public int ManufacturerId { get; set; }
        public virtual Manufacturer Manufacturer { get; set; } = null!;

        public int GunWeight { get; set; }

        public double BarrelLength { get; set; }

        public int? NumberBuild { get; set; }

        public int Range { get; set; }

        public GunType GunType { get; set; }

        public int ShellId { get; set; }
        public Shell Shell { get; set; } = null!;

        public virtual ICollection<CountryGun> CountriesGuns { get; set; } = null!;


    }
}

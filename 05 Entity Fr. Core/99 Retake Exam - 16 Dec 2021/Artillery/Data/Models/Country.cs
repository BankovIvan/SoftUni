namespace Artillery.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Country
    {
        public Country()
        {
                this.CountriesGuns = new HashSet<CountryGun>();
        }

        public int Id { get; set; }

        public string CountryName { get; set; } = null!;

        public int ArmySize { get; set; }

        public virtual ICollection<CountryGun> CountriesGuns { get; set; } = null!;

    }
}

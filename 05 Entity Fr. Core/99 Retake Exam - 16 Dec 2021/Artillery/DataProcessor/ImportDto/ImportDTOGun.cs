namespace Artillery.DataProcessor.ImportDto
{
    using Artillery.Data.Models.Enums;
    using Artillery.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ImportDTOGun
    {
        public ImportDTOGun()
        {
            this.Countries = new List<ImportDTOGunCountry>();
        }

        public int ManufacturerId { get; set; }

        public int GunWeight { get; set; }

        public double BarrelLength { get; set; }

        public int? NumberBuild { get; set; }

        public int Range { get; set; }

        public string GunType { get; set; } = null!;

        public int ShellId { get; set; }

        public List<ImportDTOGunCountry> Countries { get; set; }
    }
}

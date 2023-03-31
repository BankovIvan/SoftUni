namespace Artillery.DataProcessor.ExportDto
{
    using Artillery.Data.Models.Enums;
    using Artillery.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ExportDTOShellGun
    {
        public string GunType { get; set; } = null!;

        public int GunWeight { get; set; }

        public double BarrelLength { get; set; }

        public string Range { get; set; } = null!;

    }
}

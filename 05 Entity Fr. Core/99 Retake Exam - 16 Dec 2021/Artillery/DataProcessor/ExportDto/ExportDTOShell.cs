namespace Artillery.DataProcessor.ExportDto
{
    using Artillery.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ExportDTOShell
    {
        public ExportDTOShell()
        {
            this.Guns = new List<ExportDTOShellGun>();
        }

        public string GunType { get; set; } = null!;

        public double ShellWeight { get; set; }

        public string Caliber { get; set; } = null!;

        public List<ExportDTOShellGun> Guns { get; set; } = null!;

    }
}

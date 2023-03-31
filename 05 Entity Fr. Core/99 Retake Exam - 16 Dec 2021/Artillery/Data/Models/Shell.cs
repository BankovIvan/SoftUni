namespace Artillery.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Shell
    {
        public Shell()
        {
            this.Guns = new HashSet<Gun>();
        }


        public int Id { get; set; }

        public double ShellWeight { get; set; } 

        public string Caliber { get; set; } = null!;

        public virtual ICollection<Gun> Guns { get; set; } = null!;

    }
}

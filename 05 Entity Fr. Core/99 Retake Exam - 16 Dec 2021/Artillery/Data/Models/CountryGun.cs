namespace Artillery.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CountryGun
    {
        public int CountryId { get; set; }
        public virtual Country Country { get; set; } = null!;

        public int GunId { get; set; }
        public virtual Gun Gun { get; set; } = null!;

    }
}

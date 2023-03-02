namespace P02_FootballBetting.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Town
    {
        public Town() 
        {
            this.Teams = new HashSet<Team>();
        }

        public int TownId { get; set; }

        public string Name { get; set; } = null!;   

        public int CountryId { get; set; }
        public virtual Country Country { get; set; } = null!;

        public virtual ICollection<Team> Teams { get; set; }

    }
}

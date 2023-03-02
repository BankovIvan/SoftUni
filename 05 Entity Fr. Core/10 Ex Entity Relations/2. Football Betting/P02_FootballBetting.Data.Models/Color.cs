namespace P02_FootballBetting.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Color
    {
        public Color() 
        {
            this.PrimaryKitTeams = new HashSet<Team>();
            this.SecondaryKitTeams = new HashSet<Team>();
        }

        public int ColorId { get; set; }

        public string Name { get; set; } = null!;

        //[InverseProperty(nameof(Team.PrimaryKitColor))]
        public virtual ICollection<Team> PrimaryKitTeams { get; set; }

        //[InverseProperty(nameof(Team.SecondaryKitColor))]
        public virtual ICollection<Team> SecondaryKitTeams { get; set; }

    }
}

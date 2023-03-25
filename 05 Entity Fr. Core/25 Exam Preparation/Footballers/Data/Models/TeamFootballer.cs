namespace Footballers.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class TeamFootballer
    {
        public int TeamId { get; set; }

        public virtual Team Team { get; set; } = null!;

        public int FootballerId { get; set; }

        public virtual Footballer Footballer { get; set; } = null!;

    }
}

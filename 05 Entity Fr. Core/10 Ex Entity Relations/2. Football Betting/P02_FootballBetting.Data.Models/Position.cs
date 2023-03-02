namespace P02_FootballBetting.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Position
    {
        public Position()
        {
            this.Players = new HashSet<Player>();
        }

        public int PositionId { get; set; }

        public string Name { get; set; } = null!;

        public virtual ICollection<Player> Players { get; set; }

    }
}

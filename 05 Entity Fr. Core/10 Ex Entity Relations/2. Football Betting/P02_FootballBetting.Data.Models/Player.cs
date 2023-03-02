namespace P02_FootballBetting.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Player
    {
        public Player()
        {
            this.PlayersStatistics = new HashSet<PlayerStatistic>();
        }

        public int PlayerId { get; set; }

        public string Name { get; set; } = null!;

        public int SquadNumber { get; set; }

        /// <summary>
        /// May not work with nullable property!
        /// </summary>
        public int TeamId { get; set; }
        public virtual Team Team { get; set; } = null!;

        public int PositionId { get; set;}
        public virtual Position Position { get; set; } = null!;

        public bool IsInjured { get; set; }

        public virtual ICollection<PlayerStatistic> PlayersStatistics { get; set; }

    }
}

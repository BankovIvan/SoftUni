namespace P02_FootballBetting.Data.Models
{
    using P02_FootballBetting.Data.Models.Enums;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Bet
    {
        public int BetId { get; set; }

        public decimal Amount { get; set; }

        // ENUM = INT NOT NULL
        public Prediction Prediction { get; set; }

        public DateTime DateTime { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; } = null!;

        public int GameId { get; set; }
        public virtual Game Game { get; set; } = null!;

    }
}

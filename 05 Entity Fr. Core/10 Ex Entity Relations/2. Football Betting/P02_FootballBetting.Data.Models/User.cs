namespace P02_FootballBetting.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class User
    {
        public User()
        {
            this.Bets = new HashSet<Bet>();
        }

        public int UserId { get; set; }

        public string Username { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Name { get; set; } = null!;

        public decimal Balance { get; set; }

        public virtual ICollection<Bet> Bets { get; set; }  
    }
}

namespace Boardgames.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Seller
    {
        public Seller()
        {
            this.BoardgamesSellers = new HashSet<BoardgameSeller>();
        }

        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Address { get; set; } = null!;

        public string Country { get; set; } = null!;

        public string Website { get; set; } = null!;

        public virtual ICollection<BoardgameSeller> BoardgamesSellers { get; set; }

    }
}

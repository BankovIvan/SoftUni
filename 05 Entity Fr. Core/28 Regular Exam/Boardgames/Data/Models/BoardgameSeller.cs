namespace Boardgames.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class BoardgameSeller
    {
        public int BoardgameId { get; set; }
        public virtual Boardgame Boardgame { get; set; } = null!;

        public int SellerId { get; set; }
        public virtual Seller Seller { get; set; } = null!;

    }
}

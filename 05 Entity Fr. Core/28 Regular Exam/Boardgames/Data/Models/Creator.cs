namespace Boardgames.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Creator
    {
        public Creator()
        {
            this.Boardgames = new HashSet<Boardgame>();
        }

        public int Id { get; set; }

        public string FirstName { get; set; } = null!;
        
        public string LastName { get; set; } = null!;

        public virtual ICollection<Boardgame> Boardgames { get; set; }

    }
}

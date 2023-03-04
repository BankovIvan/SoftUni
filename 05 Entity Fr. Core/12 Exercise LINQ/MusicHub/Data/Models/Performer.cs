namespace MusicHub.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Performer
    {
        public Performer()
        {
            this.PerformerSongs = new HashSet<SongPerformer>();
        }

        public int Id { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public int Age { get; set; }

        public decimal NetWorth { get; set; }

        public virtual ICollection<SongPerformer> PerformerSongs { get; set; }

    }
}

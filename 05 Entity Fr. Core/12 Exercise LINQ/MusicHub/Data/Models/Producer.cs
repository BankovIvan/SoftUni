namespace MusicHub.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Producer
    {
        public Producer()
        {
            this.Albums = new HashSet<Album>();
        }

        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Pseudonym  { get; set; }

        public string? PhoneNumber { get; set; }

        public virtual ICollection<Album> Albums { get; set; }

    }
}

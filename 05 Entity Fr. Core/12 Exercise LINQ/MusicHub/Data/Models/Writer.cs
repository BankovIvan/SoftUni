namespace MusicHub.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Writer
    {
        public Writer()
        {
            this.Songs = new HashSet<Song>();
        }

        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Pseudonym { get; set; }

        public virtual ICollection<Song> Songs { get; set;}
    }
}

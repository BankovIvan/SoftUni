namespace MusicHub.Data.Models
{
    using System;
    using System.Collections.Generic;
    //using System.ComponentModel.DataAnnotations;
    //using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Album
    {
        public Album()
        {
            this.Songs = new HashSet<Song>();
        }

        //[Key]
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public DateTime ReleaseDate { get; set; }

        //[NotMapped]
        public decimal Price
        {
            get { return this.Songs.Sum(s => s.Price); }
        }

        public int? ProducerId  { get; set; }    
        public virtual Producer? Producer { get; set; }

        public virtual ICollection<Song> Songs { get; set; }

    }
}

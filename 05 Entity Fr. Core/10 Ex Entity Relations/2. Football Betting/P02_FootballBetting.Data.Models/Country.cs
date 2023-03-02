namespace P02_FootballBetting.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Country
    {
        public Country() 
        {
            this.Towns = new HashSet<Town>();
        }    

        public int CountryId { get; set; }

        public string Name { get; set; } = null!;

        public virtual ICollection<Town> Towns { get; set; }
    }
}

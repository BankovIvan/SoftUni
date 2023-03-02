namespace P01_HospitalDatabase.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Doctor
    {
        public Doctor()
        {
            this.Visitations = new HashSet<Visitation>();   
        }

        public int DoctorId { get; set; }

        public string Name { get; set; } = null!;

        public string Specialty { get; set; } = null!;

        public virtual ICollection<Visitation> Visitations { get; set; }


    }
}

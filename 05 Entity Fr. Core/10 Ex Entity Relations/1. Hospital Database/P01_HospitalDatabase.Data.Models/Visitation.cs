namespace P01_HospitalDatabase.Data.Models
{
    //using P01_HospitalDatabase.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Visitation
    {
        public int VisitationId { get; set; }

        public DateTime Date { get; set; }

        public string Comments { get; set; } = null!;

        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; } = null!;

        public int DoctorId { get; set; }
        public virtual Doctor? Doctor { get; set; } = null!;

    }
}

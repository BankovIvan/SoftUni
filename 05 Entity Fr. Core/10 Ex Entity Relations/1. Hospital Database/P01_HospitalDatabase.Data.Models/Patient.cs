namespace P01_HospitalDatabase.Data.Models
{
    public class Patient
    {
        public Patient()
        {
            this.Prescriptions = new HashSet<PatientMedicament>();
            this.Diagnoses = new HashSet<Diagnose>();
            this.Visitations = new HashSet<Visitation>();

        }

        public int PatientId { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Address { get; set; } = null!;

        public string Email  { get; set; } = null!;

        public bool HasInsurance { get; set; }  

        public virtual ICollection<PatientMedicament> Prescriptions { get; set; }

        public virtual ICollection<Diagnose> Diagnoses { get; set; }

        public virtual ICollection<Visitation> Visitations { get; set; }

    }
}
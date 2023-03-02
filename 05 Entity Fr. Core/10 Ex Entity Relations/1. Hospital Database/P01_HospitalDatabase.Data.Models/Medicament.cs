﻿namespace P01_HospitalDatabase.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Medicament
    {
        public Medicament()
        {
            this.Prescriptions = new HashSet<PatientMedicament>();
        }

        public int MedicamentId { get; set; }

        public string Name { get; set; } = null!;

        public virtual ICollection<PatientMedicament> Prescriptions { get; set; }

    }
}

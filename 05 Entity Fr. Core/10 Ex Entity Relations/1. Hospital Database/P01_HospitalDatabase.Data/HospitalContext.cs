namespace P01_HospitalDatabase.Data
{
    using Microsoft.EntityFrameworkCore;

    using Common;
    using Models;

    //using Common;
    //using Models;

    public class HospitalContext : DbContext
    {

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Visitation> Visitations { get; set; }
        public DbSet<Diagnose> Diagnoses { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<PatientMedicament> PatientsMedicaments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }

        /// <summary>
        /// For testing and development.
        /// </summary>
        public HospitalContext()
        {

        }

        /// <summary>
        /// Used by Judge !!!
        /// </summary>
        /// <param name="options"></param>
        public HospitalContext(DbContextOptions options)
            : base(options)
        {

        }

        /// <summary>
        /// Connection configuration.
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Set default connection string;
                // Note that Judge will replace that!
                optionsBuilder.UseSqlServer(DbConfig.ConnectionString);
            }

            base.OnConfiguring(optionsBuilder);
        }

        /// <summary>
        /// Fluent API configuration.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>(e =>
            {
                e.HasKey(p => p.PatientId);
                e.Property(p => p.FirstName)
                    .IsRequired()
                    .HasColumnType("NVARCHAR")
                    .HasMaxLength(ValidationConstants.MaxLengthPatientFirstName);
                e.Property(p => p.LastName)
                    .IsRequired()
                    .HasColumnType("NVARCHAR")
                    .HasMaxLength(ValidationConstants.MaxLengthPatientLastName);
                e.Property(p => p.Address)
                    .IsRequired()
                    .HasColumnType("NVARCHAR")
                    .HasMaxLength(ValidationConstants.MaxLengthPatientAddress);
                e.Property(p => p.Email)
                    .IsRequired()
                    .HasColumnType("VARCHAR")
                    .HasMaxLength(ValidationConstants.MaxLengthPatientEmail);
                e.HasMany(p => p.Visitations)
                    .WithOne(v => v.Patient)
                    .HasForeignKey(v => v.PatientId);
                //.OnDelete(DeleteBehavior.NoAction);
                e.HasMany(p => p.Diagnoses)
                    .WithOne(d => d.Patient)
                    .HasForeignKey(d => d.PatientId);
                e.HasMany(p => p.Prescriptions)
                    .WithOne(pm => pm.Patient)
                    .HasForeignKey(pm => pm.PatientId);

            });

            modelBuilder.Entity<Visitation>(e =>
            {
                e.HasKey(v => v.VisitationId);
                e.Property(v => v.Comments)
                    .IsRequired()
                    .HasColumnType("NVARCHAR")
                    .HasMaxLength(ValidationConstants.MaxLengthVisitationComments);
                e.HasOne(v => v.Patient)
                    .WithMany(p => p.Visitations)
                    .HasForeignKey(v => v.PatientId);
                //.OnDelete(DeleteBehavior.NoAction);
                e.HasOne(v => v.Doctor)
                    .WithMany(doc => doc.Visitations)
                    .HasForeignKey(v => v.DoctorId);

            });

            modelBuilder.Entity<Diagnose>(e =>
            {
                e.HasKey(d => d.DiagnoseId);
                e.Property(d => d.Name)
                    .IsRequired()
                    .HasColumnType("NVARCHAR")
                    .HasMaxLength(ValidationConstants.MaxLengthDiagnoseName);
                e.Property(d => d.Comments)
                    .IsRequired()
                    .HasColumnType("NVARCHAR")
                    .HasMaxLength(ValidationConstants.MaxLengthDiagnoseComments);
                e.HasOne(d => d.Patient)
                    .WithMany(p => p.Diagnoses)
                    .HasForeignKey(d => d.PatientId);
                //.OnDelete(DeleteBehavior.NoAction);

            });

            modelBuilder.Entity<Medicament>(e =>
            {
                e.HasKey(m => m.MedicamentId);
                e.Property(d => d.Name)
                    .IsRequired()
                    .HasColumnType("NVARCHAR")
                    .HasMaxLength(ValidationConstants.MaxLengthMedicamentName);
                e.HasMany(m => m.Prescriptions)
                    .WithOne(pm => pm.Medicament)
                    .HasForeignKey(pm => pm.MedicamentId);
                //.OnDelete(DeleteBehavior.NoAction);

            });

            modelBuilder.Entity<PatientMedicament>(e =>
            {
                e.HasKey(pm => new { pm.PatientId, pm.MedicamentId });
                e.HasOne(pm => pm.Patient)
                    .WithMany(p => p.Prescriptions)
                    .HasForeignKey(pm => pm.PatientId);
                //.OnDelete(DeleteBehavior.NoAction);
                e.HasOne(pm => pm.Medicament)
                    .WithMany(m => m.Prescriptions)
                    .HasForeignKey(pm => pm.MedicamentId);
                //.OnDelete(DeleteBehavior.NoAction);

            });

            modelBuilder.Entity<Doctor>(e =>
            {
                e.HasKey(doc => doc.DoctorId);
                e.Property(doc => doc.Name)
                    .IsRequired()
                    .HasColumnType("NVARCHAR")
                    .HasMaxLength(ValidationConstants.MaxLengthDoctorName);
                e.Property(doc => doc.Specialty)
                    .IsRequired()
                    .HasColumnType("NVARCHAR")
                    .HasMaxLength(ValidationConstants.MaxLengthDoctorSpeciality);
                e.HasMany(doc => doc.Visitations)
                    .WithOne(v => v.Doctor)
                    .HasForeignKey(v => v.DoctorId);
                //.OnDelete(DeleteBehavior.NoAction);

            });

            base.OnModelCreating(modelBuilder);
        }


    }
}
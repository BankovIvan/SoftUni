namespace P01_StudentSystem.Data
{
    using Microsoft.EntityFrameworkCore;
    //using P01_StudentSystem.Data.Common;
    //using P01_StudentSystem.Data.Models;
    using System.Diagnostics.Metrics;
    using System.Drawing;
    using System.Numerics;

    using Common;
    using Models;

    public class StudentSystemContext : DbContext
    {

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Homework> Homeworks { get; set; }
        public DbSet<StudentCourse> StudentsCourses { get; set; }

        /// <summary>
        /// For testing and development.
        /// </summary>
        public StudentSystemContext()
        {

        }

        /// <summary>
        /// Used by Judge !!!
        /// </summary>
        /// <param name="options"></param>
        public StudentSystemContext(DbContextOptions options)
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
            modelBuilder.Entity<Student>(e =>
            {
                e.HasKey(s => s.StudentId);
                e.Property(s => s.Name)
                    .IsRequired()
                    .HasColumnType("NVARCHAR")
                    .HasMaxLength(ValidationConstants.MaxLengthStudentName);      
                e.Property(s => s.PhoneNumber)
                    .IsRequired(false)
                    .HasColumnType("VARCHAR")
                    .HasMaxLength(ValidationConstants.LengthStudentPhoneNumber);
                e.Property(s => s.Birthday)
                    .IsRequired(false);
                e.HasMany(s => s.StudentsCourses)
                    .WithOne(sc => sc.Student)
                    .HasForeignKey(sc => sc.StudentId);
                    //.OnDelete(DeleteBehavior.NoAction);
                e.HasMany(s => s.Homeworks)
                    .WithOne(h => h.Student)
                    .HasForeignKey(h => h.StudentId);

            });

            modelBuilder.Entity<Course>(e =>
            {
                e.HasKey(c => c.CourseId);
                e.Property(c => c.Name)
                    .IsRequired()
                    .HasColumnType("NVARCHAR")
                    .HasMaxLength(ValidationConstants.MaxLengthCourseName);
                e.Property(c => c.Description)
                    .IsRequired(false)
                    .HasColumnType("NVARCHAR")
                    .HasMaxLength(ValidationConstants.MaxLengthCourseDescription);
                e.HasMany(c => c.StudentsCourses)
                    .WithOne(sc => sc.Course)
                    .HasForeignKey(sc => sc.CourseId);
                e.HasMany(c => c.Homeworks)
                    .WithOne(h => h.Course)
                    .HasForeignKey(h => h.CourseId);
                e.HasMany(c => c.Resources)
                    .WithOne(r => r.Course)
                    .HasForeignKey(r => r.CourseId);

            });

            modelBuilder.Entity<Resource>(e =>
            {
                e.HasKey(r => r.ResourceId);
                e.Property(r => r.Name)
                    .IsRequired()
                    .HasColumnType("NVARCHAR")
                    .HasMaxLength(ValidationConstants.MaxLengthResourceName);
                e.Property(r => r.Url)
                    .IsRequired()
                    .HasColumnType("VARCHAR")
                    .HasMaxLength(ValidationConstants.MaxLengthResourceUrl);
                e.HasOne(r => r.Course)
                    .WithMany(c => c.Resources)
                    .HasForeignKey(r => r.CourseId);

            });

            modelBuilder.Entity<Homework>(e =>
            {
                e.HasKey(h => h.HomeworkId);
                e.Property(h => h.Content)
                    .IsRequired()
                    .HasColumnType("VARCHAR")
                    .HasMaxLength(ValidationConstants.MaxLengthHomeworkContent);
                e.HasOne(h => h.Student)
                    .WithMany(s => s.Homeworks)
                    .HasForeignKey(h => h.StudentId);
                e.HasOne(h => h.Course)
                    .WithMany(c => c.Homeworks)
                    .HasForeignKey(h => h.CourseId);

            });

            modelBuilder.Entity<StudentCourse>(e =>
            {
                e.HasKey(sc => new { sc.StudentId, sc.CourseId });
                e.HasOne(sc => sc.Student)
                    .WithMany(s => s.StudentsCourses)
                    .HasForeignKey(sc => sc.StudentId);
                e.HasOne(sc => sc.Course)
                    .WithMany(c => c.StudentsCourses)
                    .HasForeignKey(sc => sc.CourseId);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
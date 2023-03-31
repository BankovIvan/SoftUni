namespace Artillery.Data
{
    using Artillery.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Reflection.Emit;

    public class ArtilleryContext : DbContext
    {
        public DbSet<Country> Countries { get; set; } = null!;
        public DbSet<Manufacturer> Manufacturers { get; set; } = null!;
        public DbSet<Shell> Shells { get; set; } = null!;
        public DbSet<Gun> Guns { get; set; } = null!;
        public DbSet<CountryGun> CountriesGuns { get; set; } = null!;

        public ArtilleryContext() 
        { 
        }

        public ArtilleryContext(DbContextOptions options)
            : base(options) 
        { 
        }

         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>(e =>
            {
                e.HasKey(c => c.Id);
                e.Property(c => c.CountryName)
                    .IsRequired()
                    .HasColumnType("NVARCHAR")
                    .HasMaxLength(ValidationConstants.MaxLengthCountryName);
                e.HasMany(c => c.CountriesGuns)
                    .WithOne(cg => cg.Country)
                    .HasForeignKey(cg => cg.CountryId);
            });

            modelBuilder.Entity<Manufacturer>(e =>
            {
                e.HasKey(m => m.Id);
                e.Property(m => m.ManufacturerName)
                    .IsRequired()
                    .HasColumnType("NVARCHAR")
                    .HasMaxLength(ValidationConstants.MaxLengthManufacturerManufacturerName);
                e.HasIndex(m => m.ManufacturerName).IsUnique();
                e.Property(m => m.Founded)
                    .IsRequired()
                    .HasColumnType("NVARCHAR")
                    .HasMaxLength(ValidationConstants.MaxLengthManufacturerFounded);
                e.HasMany(m => m.Guns)
                    .WithOne(g => g.Manufacturer)
                    .HasForeignKey(g => g.ManufacturerId);
            });

            modelBuilder.Entity<Shell>(e =>
            {
                e.HasKey(s => s.Id);
                e.Property(s => s.Caliber)
                    .IsRequired()
                    .HasColumnType("NVARCHAR")
                    .HasMaxLength(ValidationConstants.MaxLengthShellCaliber);
                e.HasMany(s => s.Guns)
                    .WithOne(g => g.Shell)
                    .HasForeignKey(g => g.ShellId);
            });

            modelBuilder.Entity<Gun>(e =>
            {
                e.HasKey(g => g.Id);
                e.HasOne(g => g.Shell)
                    .WithMany(s => s.Guns)
                    .HasForeignKey(g => g.ShellId);
                e.HasMany(g => g.CountriesGuns)
                    .WithOne(cg => cg.Gun)
                    .HasForeignKey(cg => cg.GunId);
            });

            modelBuilder.Entity<CountryGun>(e =>
            {
                e.HasKey(cg => new { cg.CountryId, cg.GunId });
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}

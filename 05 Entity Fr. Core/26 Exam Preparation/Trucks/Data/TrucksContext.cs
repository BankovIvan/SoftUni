namespace Trucks.Data
{
    using Microsoft.EntityFrameworkCore;
    using Trucks.Data.Models;

    public class TrucksContext : DbContext
    {
        public DbSet<Truck> Trucks { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Despatcher> Despatchers { get; set; }
        public DbSet<ClientTruck> ClientsTrucks { get; set; }

        public TrucksContext()
        { 
        }

        public TrucksContext(DbContextOptions options)
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
            modelBuilder.Entity<Truck>(e =>
            {
                e.HasKey(t => t.Id);
                e.Property(t => t.RegistrationNumber)
                    .IsRequired()
                    .HasColumnType("NVARCHAR")
                    .HasMaxLength(ValidationConstants.ExactLengthTrucksRegistrationNumber);
                e.Property(t => t.VinNumber)
                    .IsRequired()
                    .HasColumnType("NVARCHAR")
                    .HasMaxLength(ValidationConstants.ExactLengthTrucksVinNumber);
                e.HasOne(t => t.Despatcher)
                    .WithMany(d => d.Trucks)
                    .HasForeignKey(t => t.DespatcherId);
                e.HasMany(t => t.ClientsTrucks)
                    .WithOne(ct => ct.Truck)
                    .HasForeignKey(ct => ct.TruckId);
            });

            modelBuilder.Entity<Client>(e =>
            {
                e.HasKey(c => c.Id);
                e.Property(c => c.Name)
                    .IsRequired()
                    .HasColumnType("NVARCHAR")
                    .HasMaxLength(ValidationConstants.MaxLengthClientName);
                e.Property(c => c.Nationality)
                    .IsRequired()
                    .HasColumnType("NVARCHAR")
                    .HasMaxLength(ValidationConstants.MaxLengthClientNationality);
                e.HasMany(c => c.ClientsTrucks)
                    .WithOne(ct => ct.Client)
                    .HasForeignKey(ct => ct.ClientId);
            });

            modelBuilder.Entity<Despatcher>(e =>
            {
                e.HasKey(d => d.Id);
                e.Property(d => d.Name)
                    .IsRequired()
                    .HasColumnType("NVARCHAR")
                    .HasMaxLength(ValidationConstants.MaxLengthDespatcherName);
                e.HasMany(d => d.Trucks)
                    .WithOne(t => t.Despatcher)
                    .HasForeignKey(t => t.DespatcherId);
            });

            modelBuilder.Entity<ClientTruck>(e =>
            {
                e.HasKey(ct => new { ct.ClientId, ct.TruckId });
                e.HasOne(ct => ct.Client)
                    .WithMany(c => c.ClientsTrucks)
                    .HasForeignKey(ct => ct.ClientId);
                e.HasOne(ct => ct.Truck)
                    .WithMany(t => t.ClientsTrucks)
                    .HasForeignKey(ct => ct.TruckId);
            });

            base.OnModelCreating(modelBuilder);

        }
    }
}

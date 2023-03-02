namespace P03_SalesDatabase.Data
{
    using Microsoft.EntityFrameworkCore;

    using P03_SalesDatabase.Data.Common;
    using P03_SalesDatabase.Data.Models;

    public class SalesContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Sale> Sales { get; set; }

        /// <summary>
        /// For testing and development.
        /// </summary>
        public SalesContext()
        {

        }

        /// <summary>
        /// Used by Judge !!!
        /// </summary>
        /// <param name="options"></param>
        public SalesContext(DbContextOptions options)
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
            modelBuilder.Entity<Product>(e =>
            {
                e.HasKey(p => p.ProductId);
                e.Property(p => p.Name)
                    .IsRequired()
                    .HasColumnType("NVARCHAR")
                    .HasMaxLength(ValidationConstants.MaxLengthProductName);
                e.Property(p => p.Price)
                    .HasPrecision(18, 2);
                e.HasMany(p => p.Sales)
                    .WithOne(s => s.Product)
                    .HasForeignKey(s => s.ProductId);
                //.OnDelete(DeleteBehavior.NoAction);

            });

            modelBuilder.Entity<Customer>(e =>
            {
                e.HasKey(c => c.CustomerId);
                e.Property(c => c.Name)
                    .IsRequired()
                    .HasColumnType("NVARCHAR")
                    .HasMaxLength(ValidationConstants.MaxLengthCustomerName);
                e.Property(c => c.Email)
                    .IsRequired()
                    .HasColumnType("VARCHAR")
                    .HasMaxLength(ValidationConstants.MaxLengthCustomerEmail);
                e.Property(c => c.CreditCardNumber)
                    .IsRequired()
                    .HasColumnType("VARCHAR")
                    .HasMaxLength(ValidationConstants.MaxLengthCustomerCreditCardNumber);
                e.HasMany(c => c.Sales)
                    .WithOne(s => s.Customer   )
                    .HasForeignKey(s => s.CustomerId);

            });

            modelBuilder.Entity<Store>(e =>
            {
                e.HasKey(st => st.StoreId);
                e.Property(st => st.Name)
                    .IsRequired()
                    .HasColumnType("NVARCHAR")
                    .HasMaxLength(ValidationConstants.MaxLengthStoreName);
                e.HasMany(st => st.Sales)
                    .WithOne(s => s.Store)
                    .HasForeignKey(s => s.StoreId);

            });

            modelBuilder.Entity<Sale>(e =>
            {
                e.HasKey(sl => sl.SaleId);
                e.HasOne(sl => sl.Product)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(sl => sl.ProductId);
                e.HasOne(sl => sl.Customer)
                    .WithMany(c => c.Sales)
                    .HasForeignKey(sl => sl.CustomerId);
                e.HasOne(sl => sl.Store)
                    .WithMany(st => st.Sales)
                    .HasForeignKey(sl => sl.StoreId);

            });

            base.OnModelCreating(modelBuilder);
        }



    }
}
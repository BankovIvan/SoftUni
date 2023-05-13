namespace Boardgames.Data
{
    using Boardgames.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Data;

    public class BoardgamesContext : DbContext
    {
        public DbSet<Boardgame> Boardgames { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Creator> Creators { get; set; }
        public DbSet<BoardgameSeller> BoardgamesSellers { get; set; }

        public BoardgamesContext()
        { 
        }

        public BoardgamesContext(DbContextOptions options)
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
            modelBuilder.Entity<Boardgame>(e =>
            {
                e.HasKey(b => b.Id);
                e.Property(b => b.Name)
                    .IsRequired()
                    .HasColumnType("NVARCHAR")
                    .HasMaxLength(ValidationConstants.MaxLengthBoardgameName);
                e.Property(b => b.Mechanics)
                    .IsRequired()
                    .HasColumnType("NVARCHAR")
                    .HasMaxLength(ValidationConstants.MaxLengthBoardgameMechanics);
                e.HasOne(b => b.Creator)
                    .WithMany(c => c.Boardgames)
                    .HasForeignKey(b => b.CreatorId);
                e.HasMany(b => b.BoardgamesSellers)
                    .WithOne(bs => bs.Boardgame)
                    .HasForeignKey(bs => bs.BoardgameId);
            });

            modelBuilder.Entity<Seller>(e =>
            {
                e.HasKey(s => s.Id);
                e.Property(s => s.Name)
                    .IsRequired()
                    .HasColumnType("NVARCHAR")
                    .HasMaxLength(ValidationConstants.MaxLengthSellerName);
                e.Property(s => s.Address)
                    .IsRequired()
                    .HasColumnType("NVARCHAR")
                    .HasMaxLength(ValidationConstants.MaxLengthSellerAddress);
                e.Property(s => s.Country)
                    .IsRequired()
                    .HasColumnType("NVARCHAR")
                    .HasMaxLength(ValidationConstants.MaxLengthSellerCountry);
                e.Property(s => s.Website)
                    .IsRequired()
                    .HasColumnType("NVARCHAR")
                    .HasMaxLength(ValidationConstants.MaxLengthSellerWebsite);
                e.HasMany(s => s.BoardgamesSellers)
                    .WithOne(bs => bs.Seller)
                    .HasForeignKey(bs => bs.SellerId);
            });

            modelBuilder.Entity<Creator>(e =>
            {
                e.HasKey(c => c.Id);
                e.Property(c => c.FirstName)
                    .IsRequired()
                    .HasColumnType("NVARCHAR")
                    .HasMaxLength(ValidationConstants.MaxLengthCreatorFirstName);
                e.Property(c => c.LastName)
                    .IsRequired()
                    .HasColumnType("NVARCHAR")
                    .HasMaxLength(ValidationConstants.MaxLengthCreatorLastName);
                e.HasMany(s => s.Boardgames)
                    .WithOne(b => b.Creator)
                    .HasForeignKey(b => b.CreatorId);
            });

            modelBuilder.Entity<BoardgameSeller>(e =>
            {
                e.HasKey(bs => new { bs.BoardgameId, bs.SellerId });
                e.HasOne(bs => bs.Boardgame)
                    .WithMany(b => b.BoardgamesSellers)
                    .HasForeignKey(bs => bs.BoardgameId);
                e.HasOne(bs => bs.Seller)
                    .WithMany(s => s.BoardgamesSellers)
                    .HasForeignKey(bs => bs.SellerId);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}

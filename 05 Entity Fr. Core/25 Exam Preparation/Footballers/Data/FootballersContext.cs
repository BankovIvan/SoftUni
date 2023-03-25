namespace Footballers.Data
{
    using Footballers.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Numerics;

    public class FootballersContext : DbContext
    {

        public DbSet<Footballer> Footballers { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Coach> Coaches { get; set; }
        public DbSet<TeamFootballer> TeamsFootballers { get; set; }

        public FootballersContext() { }

        public FootballersContext(DbContextOptions options)
            : base(options) { }


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
            modelBuilder.Entity<Footballer>(e =>
            {
                e.HasKey(f => f.Id);
                e.Property(f =>f.Name)
                    .IsRequired()
                    .HasColumnType("NVARCHAR")
                    .HasMaxLength(ValidationConstants.MaxSizeFootballerName);
                e.HasOne(f => f.Coach)
                    .WithMany(c => c.Footballers)
                    .HasForeignKey(f => f.CoachId);
                //.OnDelete(DeleteBehavior.NoAction);
                e.HasMany(f => f.TeamsFootballers)
                    .WithOne(tf => tf.Footballer)
                    .HasForeignKey(tf => tf.FootballerId);
            });

            modelBuilder.Entity<Team>(e =>
            {
                e.HasKey(t => t.Id);
                e.Property(t => t.Name)
                    .IsRequired()
                    .HasColumnType("NVARCHAR")
                    .HasMaxLength(ValidationConstants.MaxSizeTeamName);
                e.Property(t => t.Nationality)
                    .IsRequired()
                    .HasColumnType("NVARCHAR")
                    .HasMaxLength(ValidationConstants.MaxSizeTeamNationality);
                e.HasMany(f => f.TeamsFootballers)
                    .WithOne(tf => tf.Team)
                    .HasForeignKey(tf => tf.TeamId);
            });

            modelBuilder.Entity<Coach>(e =>
            {
                e.HasKey(c => c.Id);
                e.Property(c => c.Name)
                    .IsRequired()
                    .HasColumnType("NVARCHAR")
                    .HasMaxLength(ValidationConstants.MaxSizeCoachName);
                e.Property(c => c.Nationality)
                    .IsRequired()
                    .HasColumnType("NVARCHAR")
                    .HasMaxLength(ValidationConstants.MaxSizeCoachNationality);
                e.HasMany(c => c.Footballers)
                    .WithOne(f => f.Coach)
                    .HasForeignKey(f => f.CoachId);
            });

            modelBuilder.Entity<TeamFootballer>(e =>
            {
                e.HasKey(tf => new { tf.TeamId, tf.FootballerId });
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}

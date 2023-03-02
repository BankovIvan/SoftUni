namespace P02_FootballBetting.Data
{
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// User using directives.
    /// </summary>
    using Common;
    using Models;

    public class FootballBettingContext : DbContext
    {

        public DbSet<Team> Teams { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<PlayerStatistic> PlayersStatistics { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Bet> Bets { get; set; }
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// For testing and development.
        /// </summary>
        public FootballBettingContext()
        {

        }

        /// <summary>
        /// Used by Judge !!!
        /// </summary>
        /// <param name="options"></param>
        public FootballBettingContext(DbContextOptions options) 
            : base(options)
        {
            
        }

        /// <summary>
        /// Connection configuration.
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
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
            modelBuilder.Entity<Team>(e =>
            {
                e.HasKey(t => t.TeamId);
                e.Property(t => t.Name)
                    .IsRequired()
                    .HasMaxLength(ValidationConstants.MaxLengthTeamName);
                e.Property(t => t.LogoUrl)
                    .HasMaxLength(ValidationConstants.MaxLengthTeamLogoUrl);
                e.Property(t => t.Initials)
                    .HasMaxLength(ValidationConstants.MaxLengthTeamInitials);
                e.HasOne(t => t.PrimaryKitColor)
                    .WithMany(c => c.PrimaryKitTeams)
                    .HasForeignKey(t => t.PrimaryKitColorId)
                    .OnDelete(DeleteBehavior.NoAction);
                e.HasOne(t => t.SecondaryKitColor)
                    .WithMany(c => c.SecondaryKitTeams)
                    .HasForeignKey(t => t.SecondaryKitColorId)
                    .OnDelete(DeleteBehavior.NoAction);
                e.HasOne(t => t.Town)
                    .WithMany(tn => tn.Teams)
                    .HasForeignKey(t => t.TownId);
                e.HasMany(t => t.HomeGames)
                    .WithOne(g => g.HomeTeam)
                    .HasForeignKey(g => g.HomeTeamId)
                    .OnDelete(DeleteBehavior.NoAction);
                e.HasMany(t => t.AwayGames)
                    .WithOne(g => g.AwayTeam)
                    .HasForeignKey(g => g.AwayTeamId)
                    .OnDelete(DeleteBehavior.NoAction);
                e.HasMany(t => t.Players)
                    .WithOne(p => p.Team)
                    .HasForeignKey(p => p.TeamId);

            });

            modelBuilder.Entity<Color>(e =>
            {
                e.HasKey(c => c.ColorId);
                e.Property(c => c.Name)
                    .IsRequired()
                    .HasMaxLength(ValidationConstants.MaxLengthColorName);
                e.HasMany(c => c.PrimaryKitTeams)
                    .WithOne(t => t.PrimaryKitColor)
                    .HasForeignKey(t => t.PrimaryKitColorId)
                    .OnDelete(DeleteBehavior.NoAction);
                e.HasMany(c => c.SecondaryKitTeams)
                    .WithOne(t => t.SecondaryKitColor)
                    .HasForeignKey(t => t.SecondaryKitColorId)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Town>(e =>
            {
                e.HasKey(t => t.TownId);
                e.Property(t => t.Name)
                    .IsRequired()
                    .HasMaxLength(ValidationConstants.MaxLengthTownName);
                //e.Property(t => t.CountryId)
                //    .IsRequired();
                e.HasMany(tn => tn.Teams)
                    .WithOne(t => t.Town)
                    .HasForeignKey(t => t.TownId);
                e.HasOne(tn => tn.Country)
                    .WithMany(c => c.Towns)
                    .HasForeignKey(tn => tn.CountryId);

            });

            modelBuilder.Entity<Country>(e =>
            {
                e.HasKey(c => c.CountryId);
                e.Property(c => c.Name)
                    .IsRequired()
                    .HasMaxLength(ValidationConstants.MaxLengthCountryName);
                e.HasMany(c => c.Towns)
                    .WithOne(tn => tn.Country)
                    .HasForeignKey(tn => tn.CountryId);

            });

            modelBuilder.Entity<Player>(e =>
            {
                e.HasKey(p => p.PlayerId);
                e.Property(p => p.Name)
                    .IsRequired()
                    .HasMaxLength(ValidationConstants.MaxLengthPlayerName);
                e.HasOne(p => p.Team)
                    .WithMany(t => t.Players)
                    .HasForeignKey(p => p.PlayerId);
                e.HasOne(p => p.Position)
                    .WithMany(pos => pos.Players)
                    .HasForeignKey(p => p.PositionId);
                e.HasMany(p => p.PlayersStatistics)
                    .WithOne(ps => ps.Player)
                    .HasForeignKey(ps => ps.PlayerId);

            });

            modelBuilder.Entity<Position>(e =>
            {
                e.HasKey(p => p.PositionId);
                e.Property(p => p.Name)
                    .IsRequired()
                    .HasMaxLength(ValidationConstants.MaxLengthPositionName);
                e.HasMany(pos => pos.Players)
                    .WithOne(p => p.Position)
                    .HasForeignKey(p => p.PositionId);

            });

            modelBuilder.Entity<PlayerStatistic>(e =>
            {
                e.HasKey(ps => new { ps.GameId, ps.PlayerId } );
                e.HasOne(ps => ps.Player)
                    .WithMany(p => p.PlayersStatistics)
                    .HasForeignKey(ps => ps.PlayerId);
                e.HasOne(ps => ps.Game)
                    .WithMany(g => g.PlayersStatistics)
                    .HasForeignKey(ps => ps.GameId);
            });

            modelBuilder.Entity<Game>(e =>
            {
                e.HasKey(g => g.GameId);
                e.Property(g => g.Result)
                    .HasMaxLength(ValidationConstants.MaxLengthGameResult);
                e.HasOne(g => g.HomeTeam)
                    .WithMany(t => t.HomeGames)
                    .HasForeignKey(g => g.HomeTeamId)
                    .OnDelete(DeleteBehavior.NoAction);
                e.HasOne(g => g.AwayTeam)
                    .WithMany(t => t.AwayGames)
                    .HasForeignKey(g => g.AwayTeamId)
                    .OnDelete(DeleteBehavior.NoAction);
                e.HasMany(g => g.PlayersStatistics)
                    .WithOne(ps => ps.Game)
                    .HasForeignKey(ps => ps.GameId);
                e.HasMany(g => g.Bets)
                    .WithOne(b => b.Game)
                    .HasForeignKey(b => b.GameId);

            });

            modelBuilder.Entity<Bet>(e =>
            {
                e.HasKey(b => b.BetId);
                e.HasOne(b => b.Game)
                    .WithMany(g => g.Bets)
                    .HasForeignKey(b => b.GameId);
                e.HasOne(bt => bt.User)
                    .WithMany(u => u.Bets)
                    .HasForeignKey(bt => bt.UserId);

            });

            modelBuilder.Entity<User>(e =>
            {
                e.HasKey(u => u.UserId);
                e.Property(u => u.Username)
                    .IsRequired()
                    .HasMaxLength(ValidationConstants.MaxLengthUserUsername);
                e.Property(u => u.Password)
                    .IsRequired()
                    .HasMaxLength(ValidationConstants.MaxLengthUserPassword);
                e.Property(u => u.Email)
                    .IsRequired()
                    .HasMaxLength(ValidationConstants.MaxLengthUserEmail);
                e.Property(u => u.Name)
                    .IsRequired()
                    .HasMaxLength(ValidationConstants.MaxLengthUserName);
                e.HasMany(u => u.Bets)
                    .WithOne(bt => bt.User)
                    .HasForeignKey(bt => bt.UserId);

            });

            base.OnModelCreating(modelBuilder);
        }

    }
}
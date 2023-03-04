namespace MusicHub.Data
{
    using Microsoft.EntityFrameworkCore;
    using MusicHub.Data.Models;
    using System.Reflection.Emit;

    public class MusicHubDbContext : DbContext
    {
        public DbSet<Song> Songs { get; set; }  
        public DbSet<Album> Albums { get; set; }
        public DbSet<Performer> Performers { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<SongPerformer> SongsPerformers { get; set; }

        public MusicHubDbContext()
        {
        }

        public MusicHubDbContext(DbContextOptions options)
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

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Song>(e =>
            {
                e.HasKey(s => s.Id);
                e.Property(s => s.Name)
                    .IsRequired()
                    .IsUnicode()
                    .HasMaxLength(ValidationConstants.MaxLengthSongName);
                //e.Property(s => s.Duration)
                //    .IsRequired();
                e.Property(s => s.CreatedOn)
                    .IsRequired()
                    .HasColumnType("DATE");
                //e.Property(s => s.Genre)
                //    .IsRequired();
                e.Property(s => s.Price)
                    .IsRequired()
                    .HasPrecision(18, 5);
                //e.Property(s => s.Album)
                //    .IsRequired(false);
                //e.Property(s => s.Writer)
                //    .IsRequired();
                e.HasOne(s => s.Album)
                    .WithMany(a => a.Songs)
                    .HasForeignKey(s => s.AlbumId);
                e.HasOne(s => s.Writer)
                    .WithMany(w => w.Songs)
                    .HasForeignKey(s => s.WriterId);
                e.HasMany(s => s.SongPerformers)
                    .WithOne(sp => sp.Song)
                    .HasForeignKey(sp => sp.SongId);
            });

            builder.Entity<Album>(e =>
            {
                e.HasKey(a => a.Id);
                e.Property(a => a.Name)
                    .IsRequired()
                    .IsUnicode()
                    .HasMaxLength(ValidationConstants.MaxLengthAlbumName);
                e.Property(a => a.ReleaseDate)
                    .IsRequired()
                    .HasColumnType("DATE");
                //e.Property(a => a.Price)
                //    .HasPrecision(18, 5);
                e.Ignore(a => a.Price);         ////////////////////// IGNORE !!! //////////////////////
                e.HasOne(a => a.Producer)
                    .WithMany(p => p.Albums)
                    .HasForeignKey(a => a.ProducerId);
                e.HasMany(a => a.Songs)
                    .WithOne(s => s.Album)
                    .HasForeignKey(s => s.AlbumId);
            });

            builder.Entity<Performer>(e =>
            {
                e.HasKey(p => p.Id);
                e.Property(p => p.FirstName)
                    .IsRequired()
                    .IsUnicode()
                    .HasMaxLength(ValidationConstants.MaxLengthPerformerFirstName);
                e.Property(p => p.LastName)
                    .IsRequired()
                    .IsUnicode()
                    .HasMaxLength(ValidationConstants.MaxLengthPerformerLastName);
                e.Property(p => p.NetWorth)
                    .IsRequired()
                    .HasPrecision(18, 5);
                e.HasMany(p => p.PerformerSongs)
                    .WithOne(ps => ps.Performer)
                    .HasForeignKey(ps => ps.PerformerId);
            });

            builder.Entity<Producer>(e =>
            {
                e.HasKey(pd => pd.Id);
                e.Property(pd => pd.Name)
                    .IsRequired()
                    .IsUnicode()
                    .HasMaxLength(ValidationConstants.MaxLengthProducerName);
                e.Property(pd => pd.Pseudonym)
                    .IsRequired(false)
                    .IsUnicode()
                    .HasMaxLength(ValidationConstants.MaxLengthProducerPseudonym);
                e.Property(pd => pd.PhoneNumber)
                    .IsRequired(false)
                    .IsUnicode(false)
                    .HasMaxLength(ValidationConstants.MaxLengthProducerPhoneNumber);
                e.HasMany(pd => pd.Albums)
                    .WithOne(a => a.Producer)
                    .HasForeignKey(a => a.ProducerId);
            });


            builder.Entity<Writer>(e =>
            {
                e.HasKey(w => w.Id);
                e.Property(w => w.Name)
                    .IsRequired()
                    .IsUnicode()
                    .HasMaxLength(ValidationConstants.MaxLengthWriterName);
                e.Property(w => w.Pseudonym)
                    .IsRequired(false)
                    .IsUnicode()
                    .HasMaxLength(ValidationConstants.MaxLengthProducerPseudonym);
                e.HasMany(w => w.Songs)
                    .WithOne(s => s.Writer)
                    .HasForeignKey(s => s.WriterId);
            });

            builder.Entity<SongPerformer>(e =>
            {
                e.HasKey(sp => new { sp.SongId, sp.PerformerId });
                e.HasOne(sp => sp.Song)
                    .WithMany(s => s.SongPerformers)
                    .HasForeignKey(sp => sp.SongId);
                e.HasOne(sp => sp.Performer)
                    .WithMany(p => p.PerformerSongs)
                    .HasForeignKey(sp => sp.PerformerId);
            });

            // Not included by default. //
            base.OnModelCreating(builder);

        }
    }
}

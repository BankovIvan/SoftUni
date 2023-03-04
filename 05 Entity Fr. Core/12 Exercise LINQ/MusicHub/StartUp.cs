namespace MusicHub
{
    using System;
    using System.Diagnostics;
    using System.Globalization;
    using System.Text;
    using Data;
    using Initializer;
    using MusicHub.Data.Models;

    public class StartUp
    {
        public static void Main()
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            ///
            /// 2.	All Albums Produced by Given Producer
            ///
            /*
            string task02 = ExportAlbumsInfo(context, 9);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(task02);
            Console.ResetColor();
            */

            ///
            /// 3.	Songs Above Given Duration
            ///

            string task03 = ExportSongsAboveDuration(context, 4);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(task03);
            Console.ResetColor();

        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            StringBuilder ret = new StringBuilder();

            var albumsInfo = context.Albums
                // Property Producer/ProducerId can be null!
                .Where(a => a.ProducerId.HasValue && a.ProducerId == producerId)
                .ToArray()
                .OrderByDescending(a => a.Price)
                .Select(a => new
                {
                    AlbumName = a.Name,
                    ReleaseDate = a.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                    ProducerName = a.Producer == null ? "[n/a]" : a.Producer.Name,
                    AlbumSongs = a.Songs
                        .Select(s => new 
                        {
                            SongName = s.Name,
                            SongPrice = s.Price.ToString("F2"),
                            SongWriterName = s.Writer.Name,
                        })
                        .OrderByDescending(s => s.SongName)
                        .ThenBy(s => s.SongWriterName)
                        .ToArray(),
                    TotalAlbumPrice = a.Price.ToString("F2"),
                }).ToArray();

            foreach ( var album in albumsInfo )
            {
                ret.AppendLine(String.Format("-AlbumName: {0}", album.AlbumName));
                ret.AppendLine(String.Format("-ReleaseDate: {0}", album.ReleaseDate));
                ret.AppendLine(String.Format("-ProducerName: {0}", album.ProducerName));
                ret.AppendLine(String.Format("-Songs:"));

                int i = 1;

                foreach ( var song in album.AlbumSongs)
                {
                    ret.AppendLine(String.Format("---#{0}", i++));
                    ret.AppendLine(String.Format("---SongName: {0}", song.SongName));
                    ret.AppendLine(String.Format("---Price: {0}", song.SongPrice));
                    ret.AppendLine(String.Format("---Writer: {0}", song.SongWriterName));
                }

                ret.AppendLine(String.Format("-AlbumPrice: {0}", album.TotalAlbumPrice));
            }


            return ret.ToString().Trim();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            StringBuilder ret = new StringBuilder();

            TimeSpan checkTimespan = new TimeSpan(duration * TimeSpan.TicksPerSecond);

            var songsInfo = context.Songs
                .Where(s => s.Duration > checkTimespan)
                .Select(s => new
                {
                    SongName = s.Name,
                    SongPerformersFullName = s.SongPerformers
                        .Select(sp => sp.Performer.FirstName + " " + sp.Performer.LastName)
                        .OrderBy(spfn => spfn)
                        .ToArray(),
                    SongWriterName = s.Writer.Name,
                    SongAlbumProducerName = s.Album == null ? "" : (s.Album.Producer == null ? "" : s.Album.Producer.Name),
                    SongDuration = s.Duration.ToString("c"),

                })
                .OrderBy(s => s.SongName)
                .ThenBy(s => s.SongWriterName)
                .ToArray();

            int i = 1;

            foreach(var song in songsInfo)
            {
                ret.AppendLine(String.Format("-Song #{0}", i++));
                ret.AppendLine(String.Format("---SongName: {0}", song.SongName));
                ret.AppendLine(String.Format("---Writer: {0}", song.SongWriterName));

                foreach(var performer in song.SongPerformersFullName)
                {
                    if (!String.IsNullOrWhiteSpace(performer))
                    {
                        ret.AppendLine(String.Format("---Performer: {0}", performer));
                    }
                }

                ret.AppendLine(String.Format("---AlbumProducer: {0}", song.SongAlbumProducerName));
                ret.AppendLine(String.Format("---Duration: {0}", song.SongDuration));

            }    

            return ret.ToString().Trim();
        }
    }
}

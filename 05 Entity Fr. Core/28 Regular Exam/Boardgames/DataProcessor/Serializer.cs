namespace Boardgames.DataProcessor
{
    using Boardgames.Data;
    using Newtonsoft.Json.Serialization;
    using Newtonsoft.Json;
    using System.Globalization;
    using Boardgames.DataProcessor.ExportDto;

    public class Serializer
    {
        public static string ExportCreatorsWithTheirBoardgames(BoardgamesContext context)
        {
            string ret = "";

            var exportDTOs = context.Creators
                .Where(c => c.Boardgames.Count > 0)
                .ToArray()
                .Select(c => new ExportDTOCreator()
                {
                    CreatorName = String.Format("{0} {1}", c.FirstName, c.LastName),
                    BoardgamesCount = c.Boardgames.Count,
                    Boardgames = c.Boardgames
                    .OrderBy(b => b.Name)
                    .Select(b => new ExportDTOCreatorBoardgame()
                    {
                        BoardgameName = b.Name,
                        BoardgameYearPublished = b.YearPublished
                    })
                    .ToList()
                })
                .OrderByDescending(x => x.BoardgamesCount)
                .ThenBy(x => x.CreatorName)
                .ToArray();

            // Helper class from Utilities folder.
            ret = XmlHelper.Serialize<ExportDTOCreator[]>(exportDTOs, "Creators");

            return ret;
        }

        public static string ExportSellersWithMostBoardgames(BoardgamesContext context, int year, double rating)
        {
            CultureInfo culture = CultureInfo.InvariantCulture;

            var expordDTOs = context.Sellers
                .Where(s => s.BoardgamesSellers.Count(
                    bs => bs.Boardgame.YearPublished >= year
                        && bs.Boardgame.Rating <= rating) > 0)
                .Select(s => new ExportDTOSeller()
                {
                    Name = s.Name,
                    Website = s.Website,
                    Boardgames = s.BoardgamesSellers
                        .Where(bs => bs.Boardgame.YearPublished >= year
                        && bs.Boardgame.Rating <= rating)
                        .OrderByDescending(bs => bs.Boardgame.Rating)
                        .ThenBy(bs => bs.Boardgame.Name)
                        .Select(bs => new ExportDTOSellerBoardgame()
                        {
                            Name = bs.Boardgame.Name,
                            Rating = bs.Boardgame.Rating,
                            Mechanics = bs.Boardgame.Mechanics,
                            Category = bs.Boardgame.CategoryType.ToString()

                        })
                        .ToList()
                })
                .OrderByDescending(x => x.Boardgames.Count)
                .ThenBy(x => x.Name)
                .Take(5)
                .ToList();

            DefaultContractResolver contractResolver = new DefaultContractResolver()
            {
                //NamingStrategy = new CamelCaseNamingStrategy(false, true),
            };

            // Omit first name if NULL
            return JsonConvert.SerializeObject(
                expordDTOs,
                Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ContractResolver = contractResolver,
                    NullValueHandling = NullValueHandling.Ignore,
                });
        }
    }
}
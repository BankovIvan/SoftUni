namespace Footballers.DataProcessor
{
    using Data;
    using Newtonsoft.Json.Serialization;
    using Newtonsoft.Json;
    using Footballers.DataProcessor.ExportDto;
    using System.Globalization;
    using AutoMapper;

    public class Serializer
    {
        public static string ExportCoachesWithTheirFootballers(FootballersContext context)
        {
            string ret = "";

            // Not needed for manual mapping.
            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<FootballersProfile>();
            }));

            var exportDTOs = context.Coaches
                .Where(c => c.Footballers.Count > 0)
                .Select(c => new ExportDTOCoach()
                {
                    CoachName = c.Name,
                    Count = c.Footballers.Count,
                    Footballers = c.Footballers
                    .Select(f => new ExportDTOCoachFootballer()
                    {
                        Name = f.Name,
                        Position = f.PositionType.ToString(),
                    })
                    .OrderBy(sel => sel.Name)
                    .ToList()
                })
                .OrderByDescending(sel => sel.Count)
                .ThenBy(sel => sel.CoachName)
                .ToArray();

            // Helper class from Utilities folder.
            ret = XmlHelper.Serialize<ExportDTOCoach[]>(exportDTOs, "Coaches");


            return ret;

            //throw new NotImplementedException();
        }

        public static string ExportTeamsWithMostFootballers(FootballersContext context, DateTime date)
        {

            CultureInfo culture = CultureInfo.InvariantCulture;

            var expordDTOs = context.Teams
                .Where(t => t.TeamsFootballers.Count(
                    tf => tf.Footballer.ContractStartDate >= date) > 0)
                .OrderByDescending(t => t.TeamsFootballers.Count(
                    tf => tf.Footballer.ContractStartDate >= date))
                .ThenBy(t => t.Name)
                .Take(5)
                .Select(t => new ExportDTOTeam()
                {
                    Name = t.Name,
                    Footballers = t.TeamsFootballers
                        .Where(tf => tf.Footballer.ContractStartDate >= date)
                        .OrderByDescending(tf => tf.Footballer.ContractEndDate)
                        .ThenBy(tf => tf.Footballer.Name)
                        .Select(tf => new ExportDTOTeamFootballer()
                        {
                            FootballerName = tf.Footballer.Name,
                            ContractStartDate = tf.Footballer.ContractStartDate.ToString("d", culture),
                            ContractEndDate = tf.Footballer.ContractEndDate.ToString("d", culture),
                            BestSkillType = tf.Footballer.BestSkillType.ToString(),
                            PositionType = tf.Footballer.PositionType.ToString(),
                        })
                        .ToList()
                })
                //.ToArray()
                //.OrderByDescending(sel => sel.Footballers.Count)
                //.ThenBy(sel => sel.Name)
                .ToArray();

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

            //throw new NotImplementedException();
        }
    }
}

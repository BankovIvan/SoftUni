namespace Footballers.DataProcessor
{
    using AutoMapper;
    using Castle.Core.Resource;
    using Footballers.Data;
    using Footballers.Data.Models;
    using Footballers.Data.Models.Enums;
    using Footballers.DataProcessor.ImportDto;
    using Newtonsoft.Json.Serialization;
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Text;
    using System.Text.RegularExpressions;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCoach
            = "Successfully imported coach - {0} with {1} footballers.";

        private const string SuccessfullyImportedTeam
            = "Successfully imported team - {0} with {1} footballers.";

        public static string ImportCoaches(FootballersContext context, string xmlString)
        {
            StringBuilder ret = new StringBuilder();

            // Helper class from Utilities folder.
            ImportDTOCoach[] importDTOs =
                XmlHelper.Deserialize<ImportDTOCoach[]>(xmlString, "Coaches");

            ICollection<Coach> importModels = new List<Coach>();
            //ICollection<Footballer> importNestedModels = new List<Footballer>();

            // Not needed for manual mapping.
            //IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            //{
            //    cfg.AddProfile<FootballersProfile>();
            //}));

            foreach (var importDTO in importDTOs)
            {
                if (importDTO.Name.Length < ValidationConstants.MinSizeCoachName ||
                    importDTO.Name.Length > ValidationConstants.MaxSizeCoachName ||
                    importDTO.Nationality.Length < ValidationConstants.MinSizeCoachNationality ||
                    importDTO.Nationality.Length > ValidationConstants.MaxSizeCoachNationality)
                {
                    ret.AppendLine("Invalid data!");
                    continue;
                }

                Coach importModel = new Coach()
                {
                    Name = importDTO.Name,
                    Nationality = importDTO.Nationality,
                    //Footballers = new HashSet<Footballer>()
                };

                foreach (var importNestedDTO in importDTO.Footballers)
                {
                    DateTime startDate;
                    DateTime endDate;

                    bool startDateConverted = DateTime.TryParseExact(
                        importNestedDTO.ContractStartDate,
                        "dd/MM/yyyy",
                        CultureInfo.InvariantCulture,
                        DateTimeStyles.None,
                        out startDate);

                    bool endDateConverted = DateTime.TryParseExact(
                        importNestedDTO.ContractEndDate,
                        "dd/MM/yyyy",
                        CultureInfo.InvariantCulture,
                        DateTimeStyles.None,
                        out endDate);

                    if (importNestedDTO.Name.Length < ValidationConstants.MinSizeFootballerName ||
                        importNestedDTO.Name.Length > ValidationConstants.MaxSizeFootballerName ||
                        startDateConverted == false ||
                        endDateConverted == false ||
                        startDate >= endDate)
                    {
                        ret.AppendLine(ErrorMessage);
                        continue;
                    }

                    Footballer importNestedModel = new Footballer()
                    {
                        Name = importNestedDTO.Name,
                        ContractStartDate = startDate,
                        ContractEndDate = endDate,
                        PositionType = (PositionType)importNestedDTO.PositionType,
                        BestSkillType = (BestSkillType)importNestedDTO.BestSkillType
                    };

                    importModel.Footballers.Add(importNestedModel);

                }

                importModels.Add(importModel);

                ret.AppendLine(
                    String.Format(
                        SuccessfullyImportedCoach
                        , importModel.Name
                        , importModel.Footballers.Count));


            }



            context.Coaches.AddRange(importModels);
            context.SaveChanges();

            return ret.ToString().Trim();

            //throw new NotImplementedException();
        }

        public static string ImportTeams(FootballersContext context, string jsonString)
        {
            StringBuilder ret = new StringBuilder();

            //IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            //{
            //    cfg.AddProfile<FootballersProfile>();
            //}));

            DefaultContractResolver contractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy(false, true),
            };

            ImportDTOTeam[] importDTOs = JsonConvert.DeserializeObject<ImportDTOTeam[]>(
                                                    jsonString,
                                                    new JsonSerializerSettings()
                                                    {
                                                        ContractResolver = contractResolver,
                                                        NullValueHandling = NullValueHandling.Ignore,
                                                    })!;

            ICollection<Team> importModels = new List<Team>();
            //ICollection<TeamFootballer> importNestedModels = new List<TeamFootballer>();

            foreach (var importDTO in importDTOs)
            {
                if(importDTO.Name.Length < ValidationConstants.MinSizeTeamName ||
                    importDTO.Name.Length > ValidationConstants.MaxSizeTeamName ||
                    Regex.IsMatch(importDTO.Name, ValidationConstants.RegExInvalidTeamName) ||
                    importDTO.Nationality.Length < ValidationConstants.MinSizeTeamNationality ||
                    importDTO.Nationality.Length > ValidationConstants.MaxSizeTeamNationality ||
                    importDTO.Trophies == 0)
                {
                    ret.AppendLine("Invalid data!");
                    continue;
                }

                Team importModel = new Team()
                {
                    Name = importDTO.Name,
                    Nationality = importDTO.Nationality,
                    Trophies = importDTO.Trophies
                };

                foreach(var importNestedDTO in importDTO.Footballers)
                {
                    var importFootballer = context.Footballers.Find(importNestedDTO);

                    if (importFootballer == null)
                    {
                        ret.AppendLine("Invalid data!");
                        continue;
                    }

                    TeamFootballer importNestedModel = new TeamFootballer()
                    {
                        Footballer = importFootballer
                    };

                    importModel.TeamsFootballers.Add(importNestedModel);

                }

                importModels.Add(importModel);

                ret.AppendLine(
                    String.Format(
                        SuccessfullyImportedTeam
                        , importModel.Name
                        , importModel.TeamsFootballers.Count));

            }

            context.Teams.AddRange(importModels);
            context.SaveChanges();

            return ret.ToString().Trim();

            //throw new NotImplementedException();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}

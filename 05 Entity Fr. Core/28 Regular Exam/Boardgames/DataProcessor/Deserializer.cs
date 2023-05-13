namespace Boardgames.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics;
    using System.Security.AccessControl;
    using System.Text.RegularExpressions;
    using System.Text;
    using Boardgames.Data;
    using Boardgames.DataProcessor.ImportDto;
    using Boardgames.Data.Models;
    using Boardgames.Data.Models.Enums;
    using Newtonsoft.Json.Linq;
    using System;
    using Castle.Core.Internal;
    using Newtonsoft.Json.Serialization;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCreator
            = "Successfully imported creator – {0} {1} with {2} boardgames.";

        private const string SuccessfullyImportedSeller
            = "Successfully imported seller - {0} with {1} boardgames.";

        public static string ImportCreators(BoardgamesContext context, string xmlString)
        {

            StringBuilder ret = new StringBuilder();

            // Helper class from Utilities folder.
            ImportDTOCreator[] importDTOs =
                XmlHelper.Deserialize<ImportDTOCreator[]>(xmlString, "Creators");

            ICollection<Creator> importModels = new List<Creator>();
            //ICollection<Footballer> importNestedModels = new List<Footballer>();


            foreach (var importDTO in importDTOs)
            {
                if (String.IsNullOrWhiteSpace(importDTO.FirstName) ||
                    importDTO.FirstName.Length < ValidationConstants.MinLengthCreatorFirstName ||
                    importDTO.FirstName.Length > ValidationConstants.MaxLengthCreatorFirstName ||
                    String.IsNullOrWhiteSpace(importDTO.LastName) ||
                    importDTO.LastName.Length < ValidationConstants.MinLengthCreatorLastName ||
                    importDTO.LastName.Length > ValidationConstants.MaxLengthCreatorLastName)
                {
                    ret.AppendLine(ErrorMessage);
                    continue;
                }

                Creator importModel = new Creator()
                {
                    FirstName = importDTO.FirstName,
                    LastName = importDTO.LastName,
                };

                foreach (var importNestedDTO in importDTO.Boardgames)
                {
                    if (String.IsNullOrWhiteSpace(importNestedDTO.Name) ||
                        importNestedDTO.Name.Length < ValidationConstants.MinLengthBoardgameName ||
                        importNestedDTO.Name.Length > ValidationConstants.MaxLengthBoardgameName ||
                        importNestedDTO.Rating < ValidationConstants.MinValueBoardgameRating ||
                        importNestedDTO.Rating > ValidationConstants.MaxValueBoardgameRating ||
                        importNestedDTO.YearPublished < ValidationConstants.MinValueBoardgameYearPublished ||
                        importNestedDTO.YearPublished > ValidationConstants.MaxValueBoardgameYearPublished ||
                        !Enum.IsDefined(typeof(CategoryType), importNestedDTO.CategoryType) ||
                        String.IsNullOrWhiteSpace(importNestedDTO.Mechanics))
                    {
                        ret.AppendLine(ErrorMessage);
                        continue;
                    }

                    Boardgame importNestedModel = new Boardgame()
                    {
                        Name = importNestedDTO.Name,
                        Rating = importNestedDTO.Rating,
                        YearPublished = importNestedDTO.YearPublished,
                        CategoryType = (CategoryType)importNestedDTO.CategoryType,
                        Mechanics = importNestedDTO.Mechanics,
                    };

                    importModel.Boardgames.Add(importNestedModel);

                }

                importModels.Add(importModel);

                ret.AppendLine(
                    String.Format(
                        SuccessfullyImportedCreator
                        , importModel.FirstName
                        , importModel.LastName
                        , importModel.Boardgames.Count));


            }

            context.Creators.AddRange(importModels);
            context.SaveChanges();

            return ret.ToString().Trim();
        }

        public static string ImportSellers(BoardgamesContext context, string jsonString)
        {

            StringBuilder ret = new StringBuilder();

            DefaultContractResolver contractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy(false, true),
            };

            ImportDTOSeller[] importDTOs = JsonConvert.DeserializeObject<ImportDTOSeller[]>(
                                                    jsonString,
                                                    new JsonSerializerSettings()
                                                    {
                                                        ContractResolver = contractResolver,
                                                        NullValueHandling = NullValueHandling.Ignore,
                                                    })!;

            ICollection<Seller> importModels = new List<Seller>();
            //ICollection<TeamFootballer> importNestedModels = new List<TeamFootballer>();

            foreach (var importDTO in importDTOs)
            {
                if (String.IsNullOrWhiteSpace(importDTO.Name) ||
                    importDTO.Name.Length < ValidationConstants.MinLengthSellerName ||
                    importDTO.Name.Length > ValidationConstants.MaxLengthSellerName ||
                    String.IsNullOrWhiteSpace(importDTO.Address) ||
                    importDTO.Address.Length < ValidationConstants.MinLengthSellerAddress ||
                    importDTO.Address.Length > ValidationConstants.MaxLengthSellerAddress ||
                    String.IsNullOrWhiteSpace(importDTO.Country) ||
                    String.IsNullOrWhiteSpace(importDTO.Website) ||
                    !Regex.IsMatch(importDTO.Website, ValidationConstants.RegExValidSellerWebsite))
                {
                    ret.AppendLine(ErrorMessage);
                    continue;
                }

                Seller importModel = new Seller()
                {
                    Name = importDTO.Name,
                    Address = importDTO.Address,
                    Country = importDTO.Country,
                    Website = importDTO.Website,
                };

                foreach (var importNestedDTO in importDTO.Boardgames)
                {
                    var importRelationObject = context.Boardgames.Find(importNestedDTO);

                    if (importRelationObject == null)
                    {
                        ret.AppendLine(ErrorMessage);
                        continue;
                    }

                    BoardgameSeller importNestedModel = new BoardgameSeller()
                    {
                        Boardgame = importRelationObject
                    };

                    importModel.BoardgamesSellers.Add(importNestedModel);

                }

                importModels.Add(importModel);

                ret.AppendLine(
                    String.Format(
                        SuccessfullyImportedSeller
                        , importModel.Name
                        , importModel.BoardgamesSellers.Count));

            }

            context.Sellers.AddRange(importModels);
            context.SaveChanges();

            return ret.ToString().Trim();

        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}

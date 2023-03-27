namespace Trucks.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Text;
    using System.Text.RegularExpressions;
    using Data;
    using Newtonsoft.Json.Serialization;
    using Newtonsoft.Json;
    using Trucks.Data.Models;
    using Trucks.Data.Models.Enums;
    using Trucks.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedDespatcher
            = "Successfully imported despatcher - {0} with {1} trucks.";

        private const string SuccessfullyImportedClient
            = "Successfully imported client - {0} with {1} trucks.";

        public static string ImportDespatcher(TrucksContext context, string xmlString)
        {
            StringBuilder ret = new StringBuilder();

            // Helper class from Utilities folder.
            ImportDTODispatcher[] importDTOs =
                XmlHelper.Deserialize<ImportDTODispatcher[]>(xmlString, "Despatchers");

            ICollection<Despatcher> importModels = new List<Despatcher>();
            //ICollection<Footballer> importNestedModels = new List<Footballer>();


            foreach (var importDTO in importDTOs)
            {
                if (importDTO.Name.Length < ValidationConstants.MinLengthDespatcherName ||
                    importDTO.Name.Length > ValidationConstants.MaxLengthDespatcherName ||
                    String.IsNullOrEmpty(importDTO.Position))
                {
                    ret.AppendLine("Invalid data!");
                    continue;
                }

                Despatcher importModel = new Despatcher()
                {
                    Name = importDTO.Name,
                    Position = importDTO.Position,
                    //Footballers = new HashSet<Footballer>()
                };

                foreach (var importNestedDTO in importDTO.Trucks)
                {
                    CategoryType categoryType;
                    bool categoryTypeValid = Enum.TryParse(importNestedDTO.CategoryType, true, out categoryType);

                    MakeType makeType;
                    bool makeTypeValid = Enum.TryParse(importNestedDTO.MakeType, true, out makeType);

                    if (importNestedDTO.RegistrationNumber.Length != 
                            ValidationConstants.ExactLengthTrucksRegistrationNumber ||
                        importNestedDTO.VinNumber.Length != ValidationConstants.ExactLengthTrucksVinNumber ||
                        !Regex.IsMatch(
                            importNestedDTO.RegistrationNumber, 
                            ValidationConstants.RegExValidTrucksRegistrationNumber) ||
                        importNestedDTO.TankCapacity < ValidationConstants.MinValueTrucksTankCapacity ||
                        importNestedDTO.TankCapacity > ValidationConstants.MaxValueTrucksTankCapacity ||
                        importNestedDTO.CargoCapacity < ValidationConstants.MinValueTrucksCargoCapacity ||
                        importNestedDTO.CargoCapacity > ValidationConstants.MaxValueTrucksCargoCapacity ||
                        !categoryTypeValid ||
                        !makeTypeValid)
                    {
                        ret.AppendLine(ErrorMessage);
                        continue;
                    }

                    Truck importNestedModel = new Truck()
                    {
                        RegistrationNumber = importNestedDTO.RegistrationNumber,
                        VinNumber = importNestedDTO.VinNumber,
                        TankCapacity = importNestedDTO.TankCapacity,
                        CargoCapacity = importNestedDTO.CargoCapacity,
                        CategoryType = categoryType,
                        MakeType = makeType
                    };

                    importModel.Trucks.Add(importNestedModel);

                }

                importModels.Add(importModel);

                ret.AppendLine(
                    String.Format(
                        SuccessfullyImportedDespatcher
                        , importModel.Name
                        , importModel.Trucks.Count));


            }

            context.Despatchers.AddRange(importModels);
            context.SaveChanges();

            return ret.ToString().Trim();

        }

        public static string ImportClient(TrucksContext context, string jsonString)
        {

            StringBuilder ret = new StringBuilder();

            DefaultContractResolver contractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy(false, true),
            };

            ImportDTOClient[] importDTOs = JsonConvert.DeserializeObject<ImportDTOClient[]>(
                                                    jsonString,
                                                    new JsonSerializerSettings()
                                                    {
                                                        ContractResolver = contractResolver,
                                                        NullValueHandling = NullValueHandling.Ignore,
                                                    })!;

            ICollection<Client> importModels = new List<Client>();
            //ICollection<TeamFootballer> importNestedModels = new List<TeamFootballer>();

            foreach (var importDTO in importDTOs)
            {
                if (importDTO.Name.Length < ValidationConstants.MinLengthClientName ||
                    importDTO.Name.Length > ValidationConstants.MaxLengthClientName ||
                    importDTO.Nationality.Length < ValidationConstants.MinLengthClientNationality ||
                    importDTO.Nationality.Length > ValidationConstants.MaxLengthClientNationality ||
                    String.IsNullOrEmpty(importDTO.Type) ||
                    importDTO.Type == "usual")
                {
                    ret.AppendLine("Invalid data!");
                    continue;
                }

                Client importModel = new Client()
                {
                    Name = importDTO.Name,
                    Nationality = importDTO.Nationality,
                    Type = importDTO.Type
                };

                foreach (var importNestedDTO in importDTO.Trucks)
                {
                    var importRelationObject = context.Trucks.Find(importNestedDTO);

                    if (importRelationObject == null)
                    {
                        ret.AppendLine("Invalid data!");
                        continue;
                    }

                    ClientTruck importNestedModel = new ClientTruck()
                    {
                        Truck = importRelationObject
                    };

                    importModel.ClientsTrucks.Add(importNestedModel);

                }

                importModels.Add(importModel);

                ret.AppendLine(
                    String.Format(
                        SuccessfullyImportedClient
                        , importModel.Name
                        , importModel.ClientsTrucks.Count));

            }

            context.Clients.AddRange(importModels);
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
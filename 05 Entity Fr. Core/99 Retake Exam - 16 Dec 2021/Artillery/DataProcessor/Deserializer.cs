namespace Artillery.DataProcessor
{
    using Artillery.Data;
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics;
    using System.Security.AccessControl;
    using System.Text.RegularExpressions;
    using System.Text;
    using Artillery.DataProcessor.ImportDto;
    using Artillery.Data.Models;
    using Newtonsoft.Json.Serialization;
    using Newtonsoft.Json;
    using Artillery.Data.Models.Enums;

    public class Deserializer
    {
        private const string ErrorMessage =
            "Invalid data.";
        private const string SuccessfulImportCountry =
            "Successfully import {0} with {1} army personnel.";
        private const string SuccessfulImportManufacturer =
            "Successfully import manufacturer {0} founded in {1}.";
        private const string SuccessfulImportShell =
            "Successfully import shell caliber #{0} weight {1} kg.";
        private const string SuccessfulImportGun =
            "Successfully import gun {0} with a total weight of {1} kg. and barrel length of {2} m.";

        public static string ImportCountries(ArtilleryContext context, string xmlString)
        {
            StringBuilder ret = new StringBuilder();

            // Helper class from Utilities folder.
            ImportDTOCountry[] importDTOs =
                XmlHelper.Deserialize<ImportDTOCountry[]>(xmlString, "Countries");

            ICollection<Country> importModels = new List<Country>();

            foreach (var importDTO in importDTOs)
            {
                if (importDTO.CountryName.Length < ValidationConstants.MinLengthCountryName ||
                    importDTO.CountryName.Length > ValidationConstants.MaxLengthCountryName ||
                    importDTO.ArmySize < ValidationConstants.MinValueCountryArmySize ||
                    importDTO.ArmySize > ValidationConstants.MaxValueCountryArmySize)
                {
                    ret.AppendLine(ErrorMessage);
                    continue;
                }

                Country importModel = new Country()
                {
                    CountryName = importDTO.CountryName,
                    ArmySize = importDTO.ArmySize,
                };

                importModels.Add(importModel);

                ret.AppendLine(
                    String.Format(
                        SuccessfulImportCountry
                        , importModel.CountryName
                        , importModel.ArmySize));


            }

            context.Countries.AddRange(importModels);
            context.SaveChanges();

            return ret.ToString().Trim();
        }

        public static string ImportManufacturers(ArtilleryContext context, string xmlString)
        {
            StringBuilder ret = new StringBuilder();

            // Helper class from Utilities folder.
            ImportDTOManufacturer[] importDTOs =
                XmlHelper.Deserialize<ImportDTOManufacturer[]>(xmlString, "Manufacturers");

            Dictionary<string, Manufacturer> importModels = new Dictionary<string, Manufacturer>();

            foreach (var importDTO in importDTOs)
            {
                if (importDTO.ManufacturerName.Length < ValidationConstants.MinLengthManufacturerManufacturerName ||
                    importDTO.ManufacturerName.Length > ValidationConstants.MaxLengthManufacturerManufacturerName ||
                    importDTO.Founded.Length < ValidationConstants.MinLengthManufacturerFounded ||
                    importDTO.Founded.Length > ValidationConstants.MaxLengthManufacturerFounded ||
                    importModels.ContainsKey(importDTO.ManufacturerName))
                {
                    ret.AppendLine(ErrorMessage);
                    continue;
                }

                Manufacturer importModel = new Manufacturer()
                {
                    ManufacturerName = importDTO.ManufacturerName,
                    Founded = importDTO.Founded,
                };

                importModels.Add(importModel.ManufacturerName, importModel);

                string[] splitFounded = importModel.Founded
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();


                ret.AppendLine(
                    String.Format(
                        SuccessfulImportManufacturer
                        , importModel.ManufacturerName
                        , String.Format(
                            "{0}, {1}", 
                            splitFounded[splitFounded.Length - 2] /*.Trim().Trim()*/,
                            splitFounded[splitFounded.Length - 1] /*.Trim().Trim()*/)));


            }

            context.Manufacturers.AddRange(importModels.Values);
            context.SaveChanges();

            return ret.ToString().Trim();
        }

        public static string ImportShells(ArtilleryContext context, string xmlString)
        {
            StringBuilder ret = new StringBuilder();

            // Helper class from Utilities folder.
            ImportDTOShell[] importDTOs =
                XmlHelper.Deserialize<ImportDTOShell[]>(xmlString, "Shells");

            ICollection<Shell> importModels = new List<Shell>();

            foreach (var importDTO in importDTOs)
            {
                if (importDTO.ShellWeight < ValidationConstants.MinValueShellShellWeight ||
                    importDTO.ShellWeight > ValidationConstants.MaxValueShellShellWeight ||
                    importDTO.Caliber.Length < ValidationConstants.MinLengthShellCaliber ||
                    importDTO.Caliber.Length > ValidationConstants.MaxLengthShellCaliber)
                {
                    ret.AppendLine(ErrorMessage);
                    continue;
                }

                Shell importModel = new Shell()
                {
                    ShellWeight = importDTO.ShellWeight,
                    Caliber = importDTO.Caliber,
                };

                importModels.Add(importModel);

                ret.AppendLine(
                    String.Format(
                        SuccessfulImportShell
                        , importModel.Caliber
                        , importModel.ShellWeight));


            }

            context.Shells.AddRange(importModels);
            context.SaveChanges();

            return ret.ToString().Trim();
        }

        public static string ImportGuns(ArtilleryContext context, string jsonString)
        {
            StringBuilder ret = new StringBuilder();

            DefaultContractResolver contractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy(false, true),
            };

            ImportDTOGun[] importDTOs = JsonConvert.DeserializeObject<ImportDTOGun[]>(
                                                    jsonString,
                                                    new JsonSerializerSettings()
                                                    {
                                                        ContractResolver = contractResolver,
                                                        NullValueHandling = NullValueHandling.Ignore,
                                                    })!;

            ICollection<Gun> importModels = new List<Gun>();

            foreach (var importDTO in importDTOs)
            {
                GunType gunType;
                bool validGunTupe = Enum.TryParse(importDTO.GunType, out gunType);

                if (/* context.Manufacturers.Find(importDTO.ManufacturerId) == null || */
                    importDTO.GunWeight < ValidationConstants.MinValueGunGunWeight ||
                    importDTO.GunWeight > ValidationConstants.MaxValueGunGunWeight ||
                    importDTO.BarrelLength < ValidationConstants.MinValueGunBarrelLength ||
                    importDTO.BarrelLength > ValidationConstants.MaxValueGunBarrelLength ||
                    importDTO.Range < ValidationConstants.MinValueGunRange ||
                    importDTO.Range > ValidationConstants.MaxValueGunRange ||
                    validGunTupe == false /* ||
                    context.Shells.Find(importDTO.ShellId) == null */)
                {
                    ret.AppendLine(ErrorMessage);
                    continue;
                }

                Gun importModel = new Gun()
                {
                    ManufacturerId = importDTO.ManufacturerId,
                    GunWeight = importDTO.GunWeight,
                    BarrelLength = importDTO.BarrelLength,
                    NumberBuild = importDTO.NumberBuild == null ? null : importDTO.NumberBuild.Value,
                    Range = importDTO.Range,
                    GunType = gunType,
                    ShellId = importDTO.ShellId,
                };

                foreach (var importNestedDTO in importDTO.Countries)
                {
                    /*
                    var importRelationObject = context.Countries.Find(importNestedDTO.Id);

                    if (importRelationObject == null)
                    {
                        ret.AppendLine(ErrorMessage);
                        continue;
                    }

                    CountryGun importNestedModel = new CountryGun()
                    {
                        Country = importRelationObject
                    };
                    */

                    CountryGun importNestedModel = new CountryGun()
                    {
                        CountryId = importNestedDTO.Id
                    };

                    importModel.CountriesGuns.Add(importNestedModel);

                }

                importModels.Add(importModel);

                ret.AppendLine(
                    String.Format(
                        SuccessfulImportGun
                        , importModel.GunType.ToString()
                        , importModel.GunWeight /* * importModel.CountriesGuns.Count */
                        , importModel.BarrelLength));

            }

            context.Guns.AddRange(importModels);
            context.SaveChanges();

            return ret.ToString().Trim();

        }

        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}
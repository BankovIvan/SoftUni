
namespace Artillery.DataProcessor
{
    using Artillery.Data;
    using Newtonsoft.Json.Serialization;
    using Newtonsoft.Json;
    using System.Globalization;
    using Artillery.DataProcessor.ExportDto;
    using Artillery.Data.Models.Enums;
    using System.Linq;

    public class Serializer
    {
        public static string ExportShells(ArtilleryContext context, double shellWeight)
        {
            CultureInfo culture = CultureInfo.InvariantCulture;

            var expordDTOs = context.Shells
                .Where(s => s.ShellWeight > shellWeight)
                .OrderBy(s => s.ShellWeight)
                .Select(s => new ExportDTOShell()
                {
                    ShellWeight = s.ShellWeight,
                    Caliber = s.Caliber,
                    Guns = s.Guns
                        .Where(g => g.GunType == GunType.AntiAircraftGun)
                        .OrderByDescending(g => g.GunWeight)
                        .Select(g => new ExportDTOShellGun()
                        {
                            GunType = ((GunType)g.GunType).ToString(),
                            GunWeight = g.GunWeight,
                            BarrelLength = g.BarrelLength,
                            Range = g.Range > 3000 ? "Long-range" : "Regular range"

                        })
                        .ToList()
                })
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

        public static string ExportGuns(ArtilleryContext context, string manufacturer)
        {
            string ret = "";

            var exportDTOs = context.Guns
                .Where(g => g.Manufacturer.ManufacturerName == manufacturer)
                .OrderBy(g => g.BarrelLength)
                .Select(g => new ExportDTOGun()
                {
                    Manufacturer = g.Manufacturer.ManufacturerName,
                    GunType = g.GunType.ToString(),
                    GunWeight = g.GunWeight,
                    BarrelLength = g.BarrelLength,
                    Range = g.Range,
                    Countries = g.CountriesGuns
                    .Where(cg => cg.Country.ArmySize > 4500000)
                    .OrderBy(cg => cg.Country.ArmySize)
                    .Select(cg => new ExportDTOGunCountry()
                    {
                        Country = cg.Country.CountryName,
                        ArmySize = cg.Country.ArmySize
                    })
                    .ToList()
                })
                .ToArray();

            // Helper class from Utilities folder.
            ret = XmlHelper.Serialize<ExportDTOGun[]>(exportDTOs, "Guns");

            return ret;

        }
    }
}

namespace Trucks.DataProcessor
{
    using AutoMapper;
    using Data;
    using Newtonsoft.Json.Serialization;
    using Newtonsoft.Json;
    using System.Globalization;
    using Trucks.DataProcessor.ExportDto;
    using Trucks.Data.Models.Enums;

    public class Serializer
    {
        public static string ExportDespatchersWithTheirTrucks(TrucksContext context)
        {
            string ret = "";

            var exportDTOs = context.Despatchers
                .Where(d => d.Trucks.Count > 0)
                .OrderByDescending(d => d.Trucks.Count)
                .ThenBy(d => d.Name)
                .Select(d => new ExportDTODispatcher()
                {
                    TrucksCount = d.Trucks.Count,
                    Name = d.Name,
                    Trucks = d.Trucks
                    .OrderBy(t => t.RegistrationNumber)
                    .Select(t => new ExportDTODispatcherTruck()
                    {
                        RegistrationNumber = t.RegistrationNumber,
                        Make = t.MakeType.ToString()
                    })
                    .ToList()
                })
                .ToArray();

            // Helper class from Utilities folder.
            ret = XmlHelper.Serialize<ExportDTODispatcher[]>(exportDTOs, "Despatchers");

            return ret;
        }

        public static string ExportClientsWithMostTrucks(TrucksContext context, int capacity)
        {
            CultureInfo culture = CultureInfo.InvariantCulture;

            var expordDTOs = context.Clients
                .Where(c => c.ClientsTrucks.Count(
                    ct => ct.Truck.TankCapacity >= capacity) > 0)
                .Select(c => new ExportDTOClient()
                {
                    Name = c.Name,
                    Trucks = c.ClientsTrucks
                        .Where(ct => ct.Truck.TankCapacity >= capacity)
                        .OrderBy(ct => ct.Truck.MakeType)
                        .ThenByDescending(ct => ct.Truck.CargoCapacity)
                        .Select(t => new ExportDTOClientTruck()
                        {
                            TruckRegistrationNumber = t.Truck.RegistrationNumber,
                            VinNumber = t.Truck.VinNumber,
                            TankCapacity = t.Truck.TankCapacity,
                            CargoCapacity = t.Truck.CargoCapacity,
                            CategoryType = t.Truck.CategoryType.ToString(),
                            MakeType = t.Truck.MakeType.ToString()

                        })
                        .ToList()
                })
                .OrderByDescending(x => x.Trucks.Count)
                .ThenBy(x => x.Name)
                .Take(10)
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

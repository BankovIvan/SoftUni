namespace CarDealer
{
    using AutoMapper;
    using CarDealer.Data;
    using CarDealer.DTOs.Import;
    using CarDealer.Models;
    using Castle.Core.Resource;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.IdentityModel.Protocols.OpenIdConnect;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using System.Diagnostics;
    using System.IO;
    using System.Security.Cryptography.X509Certificates;
    using System.Text.Json.Nodes;
    using System.Xml.Linq;

    public class StartUp
    {
        public static void Main()
        {
            CarDealerContext context = new CarDealerContext();

            ///
            /// Query 9. Import Suppliers
            ///
            /*
            string inputJson09 = File.ReadAllText(@"../../../Datasets/suppliers.json");
            string ret09 = ImportSuppliers(context, inputJson09);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(ret09);
            Console.ResetColor();
            

            ///
            /// Query 10. Import Parts
            ///
            
            string inputJson10 = File.ReadAllText(@"../../../Datasets/parts.json");
            string ret10 = ImportParts(context, inputJson10);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(ret10);
            Console.ResetColor();
            

            ///
            /// Query 11. Import Cars
            ///
            
            string inputJson11 = File.ReadAllText(@"../../../Datasets/cars.json");
            string ret11 = ImportCars(context, inputJson11);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(ret11);
            Console.ResetColor();
            

            ///
            /// Query 12. Import Customers
            ///
            
            string inputJson12 = File.ReadAllText(@"../../../Datasets/customers.json");
            string ret12 = ImportCustomers(context, inputJson12);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(ret12);
            Console.ResetColor();
            

            ///
            /// Query 13. Import Sales
            ///
            
            string inputJson13 = File.ReadAllText(@"../../../Datasets/sales.json");
            string ret13 = ImportSales(context, inputJson13);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(ret13);
            Console.ResetColor();
            */

            ///
            /// Query 14. Export Ordered Customers
            ///
            /*
            string ret14 = GetOrderedCustomers(context);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(ret14);
            Console.ResetColor();
            */

            ///
            /// Query 15. Export Cars from Make Toyota
            ///
            /*
            string ret15 = GetCarsFromMakeToyota(context);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(ret15);
            Console.ResetColor();
            */

            ///
            /// Query 16. Export Local Suppliers
            ///
            /*
            string ret16 = GetLocalSuppliers(context);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(ret16);
            Console.ResetColor();
            */
            ///
            /// Query 17. Export Local Suppliers
            ///
            /*
            string ret17 = GetCarsWithTheirListOfParts(context);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(ret17);
            Console.ResetColor();
            */

            ///
            /// Query 18. Export Total Sales by Customer
            ///
            
            string ret18 = GetTotalSalesByCustomer(context);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(ret18);
            Console.ResetColor();
            

            ///
            /// Query 19. Export Sales with Applied Discount
            ///
            /*
            string ret19 = GetSalesWithAppliedDiscount(context);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(ret19);
            Console.ResetColor();
            */

        }

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            /*
            var suppliersImport = new[]
            {
                new 
                {
                    name = String.Empty,
                    isImporter = false
                }
            };
                
            var suppliersData = JsonConvert.DeserializeAnonymousType(inputJson, suppliersImport);

            ICollection<Supplier> suppliers = new List<Supplier>();

            foreach (var supplierData in suppliersData) 
            { 
                var supplier = new Supplier();
                supplier.Name = supplierData.name;
                supplier.IsImporter = supplierData.isImporter;

                suppliers.Add(supplier);
            
            }

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}.";
            */

            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            }));

            DefaultContractResolver contractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy(false, true),
            };

            ImportDTO09Suppliers[] supplierDTOs = JsonConvert.DeserializeObject<ImportDTO09Suppliers[]>(
                                                    inputJson,
                                                    new JsonSerializerSettings()
                                                    {
                                                        ContractResolver = contractResolver,
                                                        NullValueHandling = NullValueHandling.Ignore,
                                                    })!;

            ICollection<Supplier> validSuppliers = new HashSet<Supplier>();

            foreach (var supplierDTO in supplierDTOs)
            {
                Supplier supplier = mapper.Map<Supplier>(supplierDTO);

                validSuppliers.Add(supplier);

            }

            context.Suppliers.AddRange(validSuppliers);
            context.SaveChanges();

            return $"Successfully imported {validSuppliers.Count}.";
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            }));

            DefaultContractResolver contractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy(false, true),
            };

            ImportDTO10Parts[] partDTOs = JsonConvert.DeserializeObject<ImportDTO10Parts[]>(
                                                    inputJson,
                                                    new JsonSerializerSettings()
                                                    {
                                                        ContractResolver = contractResolver,
                                                        NullValueHandling = NullValueHandling.Ignore,
                                                    })!;

            ICollection<Part> parts = new HashSet<Part>();

            foreach (var partDTO in partDTOs)
            {
                if(context.Suppliers.Any(s => s.Id == partDTO.SupplierId))
                {
                    Part part = mapper.Map<Part>(partDTO);
                    parts.Add(part);
                }

            }

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}.";
        }

        public static string ImportCars(CarDealerContext context, string inputJson)
        {

            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            }));

            DefaultContractResolver contractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy(false, true),
            };

            ImportDTO11Car[] carDTOs = JsonConvert.DeserializeObject<ImportDTO11Car[]>(
                                                    inputJson,
                                                    new JsonSerializerSettings()
                                                    {
                                                        ContractResolver = contractResolver,
                                                        //NullValueHandling = NullValueHandling.Ignore,
                                                    })!;

            ICollection<Car> cars = new List<Car>();

            ICollection<PartCar> partCars = new List<PartCar>();

            foreach (var carDTO in carDTOs)
            {

                Car car = mapper.Map<Car>(carDTO);
                cars.Add(car);

                foreach (var partId in carDTO.PartsId.Distinct())
                {
                    PartCar partCar = new PartCar() { Car = car, PartId = partId };
                    partCars.Add(partCar);
                }

            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            context.PartsCars.AddRange(partCars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}.";
        }

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            }));

            DefaultContractResolver contractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy(false, true),
            };

            ImportDTO12Customer[] customerDTOs = JsonConvert.DeserializeObject<ImportDTO12Customer[]>(
                                                    inputJson,
                                                    new JsonSerializerSettings()
                                                    {
                                                        ContractResolver = contractResolver,
                                                        NullValueHandling = NullValueHandling.Ignore,
                                                    })!;

            ICollection<Customer> customers = new HashSet<Customer>();

            foreach (var customerDTO in customerDTOs)
            {
                Customer customer = mapper.Map<Customer>(customerDTO);
                customers.Add(customer);
            }

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}.";
        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            }));

            DefaultContractResolver contractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy(false, true),
            };

            ImportDTO13Sale[] saleDTOs = JsonConvert.DeserializeObject<ImportDTO13Sale[]>(
                                                    inputJson,
                                                    new JsonSerializerSettings()
                                                    {
                                                        ContractResolver = contractResolver,
                                                        NullValueHandling = NullValueHandling.Ignore,
                                                    })!;

            ICollection<Sale> sales = new HashSet<Sale>();

            foreach (var saleDTO in saleDTOs)
            {
                //if(context.Cars.Any(c => c.Id == saleDTO.CarId) &&
                //    context.Customers.Any(c => c.Id == saleDTO.CustomerId))
                //{
                    Sale sale = mapper.Map<Sale>(saleDTO);
                    sales.Add(sale);
                //}

            }

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}.";
        }

        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                    .OrderBy(c => c.BirthDate)
                    .ThenBy(c => c.IsYoungDriver)
                    .ToArray()
                    .Select(c => new
                    {
                        Name = c.Name,
                        BirthDate = c.BirthDate.ToString("dd/MM/yyyy"), // String.Format("{0}", c.BirthDate),
                        IsYoungDriver = c.IsYoungDriver,
                    })
                    // .AsNoTracking()
                    .ToArray();

            DefaultContractResolver contractResolver = new DefaultContractResolver()
            {
                //NamingStrategy = new CamelCaseNamingStrategy(false, true),
            };

            // Omit first name if NULL
            return JsonConvert.SerializeObject(
                customers,
                Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ContractResolver = contractResolver,
                    NullValueHandling = NullValueHandling.Ignore,
                });
        }

        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var toyotaCars = context.Cars
                .Where(c => c.Make == "Toyota")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TraveledDistance)
                .Select(c => new
                {
                    Id = c.Id,
                    Make = c.Make,
                    Model = c.Model,
                    TraveledDistance = c.TraveledDistance,
                })
                // .AsNoTracking()
                .ToArray();

            DefaultContractResolver contractResolver = new DefaultContractResolver()
            {
                //NamingStrategy = new CamelCaseNamingStrategy(false, true),
            };

            // Omit first name if NULL
            return JsonConvert.SerializeObject(
                toyotaCars,
                Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ContractResolver = contractResolver,
                    NullValueHandling = NullValueHandling.Ignore,
                });
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var localSuppliers = context.Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count,
                })
                // .AsNoTracking()
                .ToArray();

            DefaultContractResolver contractResolver = new DefaultContractResolver()
            {
                //NamingStrategy = new CamelCaseNamingStrategy(false, true),
            };

            // Omit first name if NULL
            return JsonConvert.SerializeObject(
                localSuppliers,
                Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ContractResolver = contractResolver,
                    NullValueHandling = NullValueHandling.Ignore,
                });
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var carsAndParts = context.Cars
                .Select(c => new
                {
                    car = new
                    {
                        Make = c.Make,
                        Model = c.Model,
                        TraveledDistance = c.TraveledDistance
                    },
                    parts = c.PartsCars
                        .Select(pc => new
                        {
                            Name = pc.Part.Name,
                            Price = String.Format("{0:F2}", pc.Part.Price),
                        })
                        .ToArray()

                }).ToArray();

            DefaultContractResolver contractResolver = new DefaultContractResolver()
            {
                //NamingStrategy = new CamelCaseNamingStrategy(false, true),
            };

            // Omit first name if NULL
            return JsonConvert.SerializeObject(
                carsAndParts,
                Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ContractResolver = contractResolver,
                    NullValueHandling = NullValueHandling.Ignore,
                });
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            
            var customersWithCars = context.Customers
                .Where(c => c.Sales.Count > 0)
                .Select(c => new
                {
                    fullName = c.Name,
                    boughtCars = c.Sales.Count,
                    //spentMoney = 0,
                    CARS = c.Sales
                        .Select(s => new
                        {
                            carName = s.Car.Model,
                            PARTS = s.Car.PartsCars
                                .Select(pc => new 
                                {
                                    partName = pc.Part.Name,
                                    PRICES = pc.Part.Price,
                                })
                                .ToArray()
                                .Sum(p => p.PRICES)
                        })
                        .ToArray(),
                })
                .ToArray();

            var data = customersWithCars
                .Select(c => new
                {
                    fullName = c.fullName,
                    boughtCars = c.boughtCars,
                    spentMoney = c.CARS.Sum(c => c.PARTS)
                })
                .OrderByDescending(x => x.spentMoney)
                .ThenByDescending(x => x.boughtCars)
                .ToArray();

            DefaultContractResolver contractResolver = new DefaultContractResolver()
            {
                //NamingStrategy = new CamelCaseNamingStrategy(false, true),
            };

            // Omit first name if NULL
            return JsonConvert.SerializeObject(
                data,
                Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ContractResolver = contractResolver,
                    NullValueHandling = NullValueHandling.Ignore,
                });
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {

            var salesDiscount = context.Sales
                .Take(10)
                .Select(s => new
                {
                    car = new
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TraveledDistance = s.Car.TraveledDistance
                    },
                    customerName = s.Customer.Name,
                    discount = String.Format("{0:F2}", s.Discount),
                    price = String.Format("{0:F2}", 
                        s.Car.PartsCars.Sum(pc => pc.Part.Price)),
                    priceWithDiscount = String.Format("{0:F2}", 
                        s.Car.PartsCars.Sum(pc => pc.Part.Price) * (100 - s.Discount) / 100)
                })
                .ToArray();

            DefaultContractResolver contractResolver = new DefaultContractResolver()
            {
                //NamingStrategy = new CamelCaseNamingStrategy(false, true),
            };

            // Omit first name if NULL
            return JsonConvert.SerializeObject(
                salesDiscount,
                Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ContractResolver = contractResolver,
                    NullValueHandling = NullValueHandling.Ignore,
                });
        }

    }
}
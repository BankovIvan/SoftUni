namespace CarDealer
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using CarDealer.Data;
    using CarDealer.DTOs.Export;
    using CarDealer.DTOs.Import;
    using CarDealer.Models;
    using CarDealer.Utilities;
    using Castle.Core.Internal;
    using Microsoft.EntityFrameworkCore;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.Serialization;

    public class StartUp
    {
        public static void Main()
        {
            CarDealerContext context = new CarDealerContext();


            ///
            /// Query 9. Import Suppliers
            ///
            /*
            string input09 = File.ReadAllText("../../../Datasets/suppliers.xml");
            string ret09 = ImportSuppliers(context, input09);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(ret09);
            Console.ResetColor();
            

            ///
            /// Query 10. Import Parts
            ///
            
            string input10 = File.ReadAllText("../../../Datasets/parts.xml");
            string ret10 = ImportParts(context, input10);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(ret10);
            Console.ResetColor();
            

            ///
            /// Query 11. Import Cars
            ///
            
            string input11 = File.ReadAllText("../../../Datasets/cars.xml");
            string ret11 = ImportCars(context, input11);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(ret11);
            Console.ResetColor();
            

            ///
            /// Query 12. Import Customers
            ///

            string input12 = File.ReadAllText("../../../Datasets/customers.xml");
            string ret12 = ImportCustomers(context, input12);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(ret12);
            Console.ResetColor();


            ///
            /// Query 13. Import Sales
            ///
            
            string input13 = File.ReadAllText("../../../Datasets/sales.xml");
            string ret13 = ImportSales(context, input13);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(ret13);
            Console.ResetColor();
            */

            ///
            /// Query 14. Export Cars With Distance
            ///
            /*
            string ret14 = GetCarsWithDistance(context);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(ret14);
            Console.ResetColor();
            */

            ///
            /// Query 15. Export Cars from Make BMW
            ///
            /*
            string ret15 = GetCarsFromMakeBmw(context);
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
            /// Query 17. Export Cars with Their List of Parts
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

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            /*
            XmlRootAttribute xmlRootAttribute = new XmlRootAttribute("Suppliers");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportDTO09Supplier[]), xmlRootAttribute);

            using StringReader xmlReader = new StringReader(inputXml);
            ImportDTO09Supplier[] importSuppliers = (ImportDTO09Supplier[])xmlSerializer.Deserialize(xmlReader)!;
            */

            // Helper class from Utilities folder.
            ImportDTO09Supplier[] importSuppliersDTOs =
                XmlHelper.Deserialize<ImportDTO09Supplier[]>(inputXml, "Suppliers");

            ICollection<Supplier> suppliers = new List<Supplier>();

            // Not needed for manual mapping.
            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            }));

            foreach (var supplierDTO in importSuppliersDTOs)
            {
                if (!String.IsNullOrEmpty(supplierDTO.Name))
                {
                    /*
                    // Manual Mapping
                    Supplier supplier = new Supplier()
                    {
                        Name = supplierDTO.Name,
                        IsImporter = supplierDTO.IsImporter,
                    };
                    suppliers.Add(supplier);
                    */

                    Supplier supplier = mapper.Map<Supplier>(supplierDTO);
                    suppliers.Add(supplier);
                }
            }

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}";
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            // Helper class from Utilities folder.
            ImportDTO10Part[] importPartDTOs =
                XmlHelper.Deserialize<ImportDTO10Part[]>(inputXml, "Parts");

            ICollection<Part> parts = new List<Part>();

            // Not needed for manual mapping.
            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            }));

            foreach (var partDTO in importPartDTOs)
            {
                if (!String.IsNullOrEmpty(partDTO.Name)
                    && context.Suppliers.Find(partDTO.SupplierId) != null)
                {
                    Part part = mapper.Map<Part>(partDTO);
                    parts.Add(part);
                }
            }

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}";
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            // Helper class from Utilities folder.
            ImportDTO11Car[] importCarDTOs =
                XmlHelper.Deserialize<ImportDTO11Car[]>(inputXml, "Cars");

            // Not needed for manual mapping.
            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            }));

            ICollection<Car> cars = new List<Car>();
            //ICollection<PartCar> partCars = new List<PartCar>();

            foreach (var carDTO in importCarDTOs)
            {
                if (!String.IsNullOrEmpty(carDTO.Make)
                    && !String.IsNullOrEmpty(carDTO.Model))
                {
                    Car car = mapper.Map<Car>(carDTO);
                    
                    foreach(var partDTO in carDTO.PARTS.DistinctBy(p => p.PartId))
                    {
                        if(context.Parts.Find(partDTO.PartId) != null)
                        {
                            PartCar partCar = new PartCar()
                            {
                                //Car = car,
                                PartId = partDTO.PartId
                            };
                            //partCars.Add(partCar);

                            car.PartsCars.Add(partCar);

                        }
                    }

                    cars.Add(car);

                }
            }

            context.Cars.AddRange(cars);
            //context.PartsCars.AddRange(partCars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}";
        }

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            // Helper class from Utilities folder.
            ImportDTO12Customer[] importCustomerDTOs =
                XmlHelper.Deserialize<ImportDTO12Customer[]>(inputXml, "Customers");

            // Not needed for manual mapping.
            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            }));

            ICollection<Customer> customers = new List<Customer>();

            foreach (var customerDTO in importCustomerDTOs)
            {
                if (!String.IsNullOrEmpty(customerDTO.Name) &&
                    !String.IsNullOrEmpty(customerDTO.BirthDate) )
                {
                    Customer customer = mapper.Map<Customer>(customerDTO);
                    customers.Add(customer);

                }
            }

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}";
        }

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            // Helper class from Utilities folder.
            ImportDTO13Sale[] importSaleDTOs =
                XmlHelper.Deserialize<ImportDTO13Sale[]>(inputXml, "Sales");

            // Not needed for manual mapping.
            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            }));

            ICollection<Sale> sales = new List<Sale>();

            foreach (var saleDTO in importSaleDTOs)
            {
                if (context.Cars.Find(saleDTO.CarId) != null 
                    /*&& context.Customers.Find(saleDTO.CustomerId) != null*/)
                {
                    Sale sale = mapper.Map<Sale>(saleDTO);
                    sales.Add(sale);

                }
            }

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}";
        }

        public static string GetCarsWithDistance(CarDealerContext context)
        {
            string ret = "";

            // Not needed for manual mapping.
            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            }));

            ExportDTO14CarWithDistance[] exportCarDTOs = context.Cars
                .Where(c => c.TraveledDistance > 2000000)
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .ProjectTo<ExportDTO14CarWithDistance>(mapper.ConfigurationProvider)
                .ToArray();

            /*
            XmlRootAttribute xmlRoot = new XmlRootAttribute("cars");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportDTO14CarWithDistance[]), xmlRoot);
            XmlSerializerNamespaces xmlNamespaces = new XmlSerializerNamespaces();
            xmlNamespaces.Add(string.Empty, string.Empty);

            StringBuilder sb = new StringBuilder();
            using StringWriter sw = new StringWriter(sb);
            xmlSerializer.Serialize(sw, exportCarDTOs, xmlNamespaces);
            */

            // Helper class from Utilities folder.
            ret =XmlHelper.Serialize<ExportDTO14CarWithDistance[]>(exportCarDTOs, "cars");


            return ret;
        }

        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            string ret = "";

            // Not needed for manual mapping.
            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            }));

            ExportDTO15CarBMW[] exportCarDTOs = context.Cars
                .Where(c => c.Make == "BMW")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TraveledDistance)
                .ProjectTo<ExportDTO15CarBMW>(mapper.ConfigurationProvider)
                .ToArray();

            // Helper class from Utilities folder.
            ret = XmlHelper.Serialize<ExportDTO15CarBMW[]>(exportCarDTOs, "cars");


            return ret;
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            string ret = "";

            // Not needed for manual mapping.
            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            }));

            ExportDTO16LocalSupplier[] exportLocalSupplierDTOs = context.Suppliers
                .Where(s => s.IsImporter == false)
                .ProjectTo<ExportDTO16LocalSupplier>(mapper.ConfigurationProvider)
                .ToArray();

            // Helper class from Utilities folder.
            ret = XmlHelper.Serialize<ExportDTO16LocalSupplier[]>(exportLocalSupplierDTOs, "suppliers");


            return ret;
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            string ret = "";

            // Not needed for manual mapping.
            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            }));

            ExportDTO17CarWithParts[] exportDTOs = context.Cars
                .OrderByDescending(c => c.TraveledDistance)
                .ThenBy(c => c.Model)
                .Take(5)
                .ProjectTo<ExportDTO17CarWithParts>(mapper.ConfigurationProvider)
                .ToArray();

            // Helper class from Utilities folder.
            ret = XmlHelper.Serialize<ExportDTO17CarWithParts[]>(exportDTOs, "cars");


            return ret;
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            string ret = "";

            // Not needed for manual mapping.
            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            }));

            ExportDTO18SalePrices[] exportDTOs = context.Customers
                .Where(c => c.Sales.Count > 0)
                .ProjectTo<ExportDTO18SalePrices>(mapper.ConfigurationProvider)
                .ToArray();

            List<ExportDTO18SaleByCustomer> xmlDTOs = new List<ExportDTO18SaleByCustomer> ();

            foreach (var exportDTO in exportDTOs)
            {
                ExportDTO18SaleByCustomer xmlDTO = new ExportDTO18SaleByCustomer()
                {
                    Name = exportDTO.Name,
                    BoughtCars = exportDTO.BoughtCars,
                    SpentMoney = Math.Round(exportDTO.CarPrices.Sum(), 2)
                };

                xmlDTOs.Add(xmlDTO);
            }

            xmlDTOs = xmlDTOs
                .OrderByDescending(x => x.SpentMoney)
                //.ThenByDescending(x => x.BoughtCars)
                .ToList();

            // Helper class from Utilities folder.
            ret = XmlHelper.Serialize<List<ExportDTO18SaleByCustomer>>(xmlDTOs, "customers");

            return ret;
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            string ret = "";

            // Not needed for manual mapping.
            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            }));

            ExportDTO19SaleAndDiscount[] exportDTOs = context.Sales
                .ProjectTo<ExportDTO19SaleAndDiscount>(mapper.ConfigurationProvider)
                .ToArray();

            // Helper class from Utilities folder.
            ret = XmlHelper.Serialize<ExportDTO19SaleAndDiscount[]>(exportDTOs, "sales");


            return ret;
        }









    }
}
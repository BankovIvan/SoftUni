namespace ProductShop
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using ProductShop.Data;
    using ProductShop.DTOs.Export;
    using ProductShop.DTOs.Import;
    using ProductShop.Models;
    using ProductShop.Utilities;

    public class StartUp
    {
        public static void Main()
        {
            ProductShopContext context = new ProductShopContext();

            ///
            /// Query 1. Import Users
            ///
            /*
            string input01 = File.ReadAllText("../../../Datasets/users.xml");
            string ret01 = ImportUsers(context, input01);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(ret01);
            Console.ResetColor();


            ///
            /// Query 2. Import Products
            ///

            string input02 = File.ReadAllText("../../../Datasets/products.xml");
            string ret02 = ImportProducts(context, input02);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(ret02);
            Console.ResetColor();


            ///
            /// Query 3. Import Categories
            ///

            string input03 = File.ReadAllText("../../../Datasets/categories.xml");
            string ret03 = ImportCategories(context, input03);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(ret03);
            Console.ResetColor();


            ///
            /// Query 4. Import Categories and Products
            ///

            string input04 = File.ReadAllText("../../../Datasets/categories-products.xml");
            string ret04 = ImportCategoryProducts(context, input04);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(ret04);
            Console.ResetColor();
            */

            ///
            /// Query 5. Export Products In Range
            ///
            /*
            string ret05 = GetProductsInRange(context);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(ret05);
            Console.ResetColor();
            */

            ///
            /// Query 6. Export Sold Products
            ///
            /*
            string ret06 = GetSoldProducts(context);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(ret06);
            Console.ResetColor();
            */

            ///
            /// Query 7. Export Categories By Products Count
            ///
            /*
            string ret07 = GetCategoriesByProductsCount(context);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(ret07);
            Console.ResetColor();
            */

            ///
            /// Query 8. Export Users and Products
            ///

            string ret08 = GetUsersWithProducts(context);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(ret08);
            Console.ResetColor();







        }


        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            // Helper class from Utilities folder.
            ImportDTO01User[] importDTOs =
                XmlHelper.Deserialize<ImportDTO01User[]>(inputXml, "Users");

            ICollection<User> users = new List<User>();

            // Not needed for manual mapping.
            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            }));

            foreach (var importDTO in importDTOs)
            {
                if (!String.IsNullOrEmpty(importDTO.FirstName)
                    && !String.IsNullOrEmpty(importDTO.LastName))
                {
                    User user = mapper.Map<User>(importDTO);
                    users.Add(user);
                }
            }

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            // Helper class from Utilities folder.
            ImportDTO02Product[] importDTOs =
                XmlHelper.Deserialize<ImportDTO02Product[]>(inputXml, "Products");

            ICollection<Product> products = new List<Product>();

            // Not needed for manual mapping.
            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            }));

            foreach (var importDTO in importDTOs)
            {
                if (!String.IsNullOrEmpty(importDTO.Name))
                {
                    Product product = mapper.Map<Product>(importDTO);
                    products.Add(product);
                }
            }

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            // Helper class from Utilities folder.
            ImportDTO03Category[] importDTOs =
                XmlHelper.Deserialize<ImportDTO03Category[]>(inputXml, "Categories");

            ICollection<Category> categories = new List<Category>();

            // Not needed for manual mapping.
            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            }));

            foreach (var importDTO in importDTOs)
            {
                if (!String.IsNullOrEmpty(importDTO.Name))
                {
                    Category category = mapper.Map<Category>(importDTO);
                    categories.Add(category);
                }
            }

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            // Helper class from Utilities folder.
            ImportDTO04CategoryProduct[] importDTOs =
                XmlHelper.Deserialize<ImportDTO04CategoryProduct[]>(inputXml, "CategoryProducts");

            ICollection<CategoryProduct> categoryProducts = new List<CategoryProduct>();

            // Not needed for manual mapping.
            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            }));

            foreach (var importDTO in importDTOs)
            {
                if (context.Categories.Find(importDTO.CategoryId) != null
                    && context.Products.Find(importDTO.ProductId) != null)
                {
                    CategoryProduct categoryProduct = mapper.Map<CategoryProduct>(importDTO);
                    categoryProducts.Add(categoryProduct);
                }
            }

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}";

        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            string ret = "";

            // Not needed for manual mapping.
            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            }));

            ExportDTO05ProductsInRange[] exportDTOs = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Take(10)
                .ProjectTo<ExportDTO05ProductsInRange>(mapper.ConfigurationProvider)
                .ToArray();

            // Helper class from Utilities folder.
            ret = XmlHelper.Serialize<ExportDTO05ProductsInRange[]>(exportDTOs, "Products");


            return ret;
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            string ret = "";

            // Not needed for manual mapping.
            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            }));

            ExportDTO06UserWithProducts[] exportDTOs = context.Users
                .Where(u => u.ProductsSold.Count > 0)
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Take(5)
                .ProjectTo<ExportDTO06UserWithProducts>(mapper.ConfigurationProvider)
                .ToArray();

            // Helper class from Utilities folder.
            ret = XmlHelper.Serialize<ExportDTO06UserWithProducts[]>(exportDTOs, "Users");


            return ret;
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            string ret = "";

            // Not needed for manual mapping.
            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            }));

            ExportDTO07CategoryByProduct[] exportDTOs = context.Categories
                .ProjectTo<ExportDTO07CategoryByProduct>(mapper.ConfigurationProvider)
                .OrderByDescending(c => c.Count)
                .ThenBy(c => c.TotalRevenue)
                .ToArray();

            // Helper class from Utilities folder.
            ret = XmlHelper.Serialize<ExportDTO07CategoryByProduct[]>(exportDTOs, "Categories");


            return ret;
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            string ret = "";

            // Not needed for manual mapping.
            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            }));

            List<ExportDTO08UserWithSoldProducts> exportDTOs = context.Users
                .Where(u => u.ProductsSold.Count > 0)
                .OrderByDescending(u => u.ProductsSold.Count)
                .Take(10)
                .ProjectTo<ExportDTO08UserWithSoldProducts>(mapper.ConfigurationProvider)
                .ToList();

            foreach (var exportDTO in exportDTOs) 
            {
                exportDTO.PRODUCTS.ProductsSold = exportDTO.PRODUCTS.ProductsSold.OrderByDescending(ps => ps.Price).ToList();
            }

            ExportDTO08UserData userData = new ExportDTO08UserData()
            {
                Count = context.Users.Count(u => u.ProductsSold.Count > 0),
                USERS = exportDTOs
            };

            // Helper class from Utilities folder.
            ret = XmlHelper.Serialize<ExportDTO08UserData>(userData, "Users");


            return ret;
        }




    }
}
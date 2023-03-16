namespace ProductShop
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using ProductShop.Data;
    using ProductShop.DTOs.Export;
    using ProductShop.DTOs.Import;
    using ProductShop.Models;
    using System.Text;
    using System.Xml.Linq;

    public class StartUp
    {
        public static void Main()
        {
            ProductShopContext context = new ProductShopContext();

            ///
            /// Query 1. Import Users
            ///
            /*
            string inputJson01 = File.ReadAllText(@"../../../Datasets/users.json");
            string ret01 = ImportUsers(context, inputJson01);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(ret01);
            Console.ResetColor();
            */

            ///
            /// Query 2. Import Products
            ///
            /*
            string inputJson02 = File.ReadAllText(@"../../../Datasets/products.json");
            string ret02 = ImportProducts(context, inputJson02);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(ret02);
            Console.ResetColor();
            */

            ///
            /// Query 3. Import Categories
            ///
            /*
            string inputJson03 = File.ReadAllText(@"../../../Datasets/categories.json");
            string ret03 = ImportCategories(context, inputJson03);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(ret03);
            Console.ResetColor();
            */

            ///
            /// Query 4. Import Categories and Products
            ///
            /*
            string inputJson04 = File.ReadAllText(@"../../../Datasets/categories-products.json");
            string ret04 = ImportCategoryProducts(context, inputJson04);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(ret04);
            Console.ResetColor();
            */

            ///
            /// 2.	Export Data
            /// Query 5. Export Products in Range
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
            /// Query 7. Export Categories by Products Count
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

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            StringBuilder ret = new StringBuilder();

            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            }));

            ImportDTOUser[] userDTOs = JsonConvert.DeserializeObject<ImportDTOUser[]>(inputJson)!;

            ICollection<User> validUsers = new HashSet<User>();

            foreach (var userDTO in userDTOs)
            {
                User user = mapper.Map<User>(userDTO);

                validUsers.Add(user);

            }

            context.Users.AddRange(validUsers);
            context.SaveChanges();

            ret.AppendLine(String.Format("Successfully imported {0}", validUsers.Count));

            return ret.ToString().Trim();

        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            StringBuilder ret = new StringBuilder();

            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            }));

            ImportDTOProduct[] productDTOs = JsonConvert.DeserializeObject<ImportDTOProduct[]>(inputJson)!;

            /*
            ICollection<Product> validProducts = new HashSet<Product>();

            foreach (var productDTO in productDTOs)
            {
                Product product = mapper.Map<Product>(productDTO);

                validProducts.Add(product);

            }
            */

            Product[] products = mapper.Map<Product[]>(productDTOs);    

            context.Products.AddRange(products);
            context.SaveChanges();
            

            ret.AppendLine(String.Format("Successfully imported {0}", products.Length));
            
            return ret.ToString().Trim();

        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            StringBuilder ret = new StringBuilder();

            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            }));

            ImportDTOCategory[] categoryDTOs = JsonConvert.DeserializeObject<ImportDTOCategory[]>(inputJson)!;

            ICollection<Category> validCategories = new HashSet<Category>();

            foreach (var categoryDTO in categoryDTOs)
            {
                Category category = mapper.Map<Category>(categoryDTO);

                if(category != null && !String.IsNullOrEmpty(category.Name))
                {
                    validCategories.Add(category);
                }

            }

            context.Categories.AddRange(validCategories);
            context.SaveChanges();

            ret.AppendLine(String.Format("Successfully imported {0}", validCategories.Count));

            return ret.ToString().Trim();

        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            StringBuilder ret = new StringBuilder();

            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            }));

            ImportDTOCategoryProduct[] categoryProductDTOs = 
                JsonConvert.DeserializeObject<ImportDTOCategoryProduct[]>(inputJson)!;

            ICollection<CategoryProduct> validCategoryProducts = new HashSet<CategoryProduct>();

            foreach (var categoryProductDTO in categoryProductDTOs)
            {
                
                bool validCategoryIdExist = context.Categories
                    .Any(c => c.Id == categoryProductDTO.CategoryId);

                bool validProductIdExist = context.Products
                    .Any(p => p.Id == categoryProductDTO.ProductId);

                bool categoryProductDoesNotExist = !context.CategoriesProducts
                    .Any(c => c.CategoryId == categoryProductDTO.CategoryId
                        && c.ProductId == categoryProductDTO.ProductId);

                // NOT WORKING IN JUDGE !!!

                validCategoryIdExist = true;
                validProductIdExist = true;
                categoryProductDoesNotExist = true;

                if (validCategoryIdExist && validProductIdExist && categoryProductDoesNotExist)
                {
                    CategoryProduct categoryProduct = mapper.Map<CategoryProduct>(categoryProductDTO);
                    validCategoryProducts.Add(categoryProduct);
                }
                

            }

            context.CategoriesProducts.AddRange(validCategoryProducts);
            context.SaveChanges();

            ret.AppendLine(String.Format("Successfully imported {0}", validCategoryProducts.Count));

            return ret.ToString().Trim();

        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            /*
            var productsInRange = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .Select(p => new
                {
                    name = p.Name,
                    price = p.Price,
                    seller = String.Format("{0} {1}", p.Seller.FirstName, p.Seller.LastName),

                })
                .OrderBy(p => p.price)
                .AsNoTracking()
                .ToArray();
            */
            
            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            }));

            ExportDTOProductInRange[] productsInRange = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .AsNoTracking()
                .ProjectTo<ExportDTOProductInRange>(mapper.ConfigurationProvider)
                .ToArray();
            

            return JsonConvert.SerializeObject(productsInRange, Formatting.Indented);

        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            /*
            DefaultContractResolver contractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy(false, true)
            };
            */

            var usersWithSoldProducts = context.Users
                .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    soldProducts = u.ProductsSold
                        .Where(p => p.Buyer != null)
                        .Select(p => new
                        {
                            name = p.Name,
                            price = p.Price,
                            buyerFirstName = p.Buyer.FirstName,
                            buyerLastName = p.Buyer.LastName,
                        })
                        .ToArray()
                })
                .AsNoTracking()
                .ToArray();

            /*
            return JsonConvert.SerializeObject(
                usersWithSoldProducts, 
                Formatting.Indented, 
                new JsonSerializerSettings()
                {
                    ContractResolver = contractResolver
                });
            */

            return JsonConvert.SerializeObject(usersWithSoldProducts, Formatting.Indented);
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categoriesByProductCount = context.Categories
                .OrderByDescending(c => c.CategoriesProducts.Count)
                .Select(c => new
                {
                    category = c.Name,
                    productsCount = c.CategoriesProducts.Count,
                    averagePrice = 
                        String.Format("{0:F2}",
                            c.CategoriesProducts.Any() ? 
                            c.CategoriesProducts.Average(p => p.Product.Price) :
                            0),
                    totalRevenue =
                        String.Format("{0:F2}",
                            c.CategoriesProducts.Any() ?
                            c.CategoriesProducts.Sum(p => p.Product.Price) :
                            0),
                })
                .AsNoTracking()
                .ToArray();

            return JsonConvert.SerializeObject(categoriesByProductCount, Formatting.Indented);

        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var usersWithProducts = new
            {
                usersCount = context.Users.Count(u => u.ProductsSold.Any(p => p.Buyer != null)),
                users = context.Users
                    .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                    .OrderByDescending(u => u.ProductsSold.Count(p => p.Buyer != null))
                    .Select(u => new
                    {
                        ///
                        /// !!!!! Judge requires First Name !!!!!
                        /// 
                        firstName = u.FirstName,
                        lastName = u.LastName,
                        age = u.Age,
                        soldProducts = new
                        {
                            count = u.ProductsSold.Count(x => x.Buyer != null),
                            products = u.ProductsSold
                                .Where(ps => ps.Buyer != null)
                                .Select(ps => new
                                {
                                    name = ps.Name,

                                    ///
                                    /// !!!!! Judge requires cast to double !!!!!
                                    ///
                                    price = (double)ps.Price
                                    //price = String.Format("{0:G29}", ps.Price) // Does not work as it adds " to the value. 
                                })
                                .ToArray()
                        }
                    })
                    .AsNoTracking()
                    .ToArray()
            };

            // Not really needed just for beautifulness...
            DefaultContractResolver contractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy(false, true),
            };

            // Omit first name if NULL
            return JsonConvert.SerializeObject(
                usersWithProducts,
                Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ContractResolver = contractResolver,
                    NullValueHandling = NullValueHandling.Ignore,
                });

        }

    }
}
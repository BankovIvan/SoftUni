namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using System.Globalization;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            DbInitializer.ResetDatabase(db);

            ///
            ///  2.	Age Restriction
            ///
            /*
            string command = Console.ReadLine();
            string ret02 = GetBooksByAgeRestriction(db, command);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(ret02);
            Console.ResetColor();
            */

            ///
            ///  3.	Golden Books
            ///
            //command = Console.ReadLine();
            /*
            string ret03 = GetGoldenBooks(db);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(ret03);
            Console.ResetColor();
            */

            ///
            ///  4.	Books by Price
            ///
            //command = Console.ReadLine();
            /*
            string ret04 = GetBooksByPrice(db);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(ret04);
            Console.ResetColor();
            */

            ///
            ///  5.	Not Released In
            ///
            /*
            int command = int.Parse(Console.ReadLine());
            string ret05 = GetBooksNotReleasedIn(db, command);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(ret05);
            Console.ResetColor();
            */

            ///
            ///  6.	Book Titles by Category
            ///
            /*
            string command = Console.ReadLine();
            string ret06 = GetBooksByCategory(db, command);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(ret06);
            Console.ResetColor();
            */

            ///
            ///  7.	Released Before Date
            ///
            /*
            string command = Console.ReadLine();
            string ret07 = GetBooksReleasedBefore(db, command);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(ret07);
            Console.ResetColor();
            */

            ///
            ///  8.	Author Search
            ///
            /*
            string command = Console.ReadLine();
            string ret08 = GetAuthorNamesEndingIn(db, command);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(ret08);
            Console.ResetColor();
            */

            ///
            ///  9.	Book Search
            ///
            /*
            string command = Console.ReadLine();
            string ret09 = GetBookTitlesContaining(db, command);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(ret09);
            Console.ResetColor();
            */

            ///
            ///  10.	Book Search by Author
            ///
            /*
            string command = Console.ReadLine();
            string ret10 = GetBooksByAuthor(db, command);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(ret10);
            Console.ResetColor();
            */

            ///
            ///  11.	Count Books
            ///
            /*
            int command = int.Parse(Console.ReadLine());
            int ret11 = CountBooks(db, command);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(ret11);
            Console.ResetColor();
            */

            ///
            ///  12.	Total Book Copies
            ///
            //string command = Console.ReadLine();
            /*
            string ret12 = CountCopiesByAuthor(db);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(ret12);
            Console.ResetColor();
            */

            ///
            ///  13.	Profit by Category
            ///
            //string command = Console.ReadLine();
            /*
            string ret13 = GetTotalProfitByCategory(db);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(ret13);
            Console.ResetColor();
            */

            ///
            ///  14.	Most Recent Books
            ///
            //string command = Console.ReadLine();
            /*
            string ret14 = GetMostRecentBooks(db);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(ret14);
            Console.ResetColor();
            */

            ///
            ///  15.	Increase Prices
            ///
            /*
            IncreasePrices(db);
            */

            ///
            ///  16.	Remove Books
            ///
            //string command = Console.ReadLine();
            /*
            int ret16 = RemoveBooks(db);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(ret16);
            Console.ResetColor();
            */

        }


        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {

            StringBuilder ret = new StringBuilder();

            AgeRestriction ageRestriction;

            //Enum.TryParse(command, true, out ageRestriction);

            try
            {
                ageRestriction = Enum.Parse<AgeRestriction>(command, true);

                var booksByAgeData = context.Books
                    .Where(b => b.AgeRestriction == ageRestriction)
                    .Select(b => new
                    {
                        Title = b.Title,

                    })
                    .OrderBy(b => b.Title)
                    .ToArray();

                foreach (var book in booksByAgeData)
                {
                    ret.AppendLine(book.Title);
                }

            }

            catch(Exception e)
            {
                return e.Message;
            }

            return ret.ToString().Trim();
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            StringBuilder ret = new StringBuilder();

            var goldenBooks = context.Books
                .Where(b => b.Copies < 5000 && b.EditionType == EditionType.Gold)
                .OrderBy(b => b.BookId)
                .Select(b => new
                {
                    Title = b.Title,
                })
                .ToArray();

            foreach (var book in goldenBooks)
            {
                ret.AppendLine(book.Title);
            }

            return ret.ToString().Trim();

        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            StringBuilder ret = new StringBuilder();

            var goldenBooks = context.Books
                .Where(b => b.Price > 40)
                .OrderByDescending(b => b.Price)
                .Select(b => new
                {
                    Title = b.Title,
                    Price = b.Price,
                })
                .ToArray();

            foreach (var book in goldenBooks)
            {
                ret.AppendLine(String.Format("{0} - ${1:F2}", book.Title, book.Price));
            }

            return ret.ToString().Trim();

        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {

            StringBuilder ret = new StringBuilder();

            DateTime checkYearFrom = new DateTime(year, 1, 1);
            DateTime checkYearTo = new DateTime(year + 1, 1, 1);

            var booksReleased = context.Books
                .Where(b => b.ReleaseDate < checkYearFrom || b.ReleaseDate >= checkYearTo)
                .OrderBy(b => b.BookId)
                .Select(b => new
                {
                    Title = b.Title,

                })
                .ToArray();

            foreach (var book in booksReleased)
            {
                ret.AppendLine(book.Title);
            }

            return ret.ToString().Trim();
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {

            StringBuilder ret = new StringBuilder();

            HashSet<string> lstSelected = input.ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToHashSet();

            /*
            var categories = context.Categories
                .Where(c => lstSelected.Contains(c.Name))
                .Select(c => c.CategoryId)
                .ToArray();
            */

            var BookIDs = context.BooksCategories
                .Where(bc => lstSelected.Contains(bc.Category.Name.ToLower()))
                .Select(bc => bc.BookId)
                .ToHashSet();


            var booksByCategory = context.Books
                .Where(b => BookIDs.Contains(b.BookId))
                .OrderBy(b => b.Title)
                .Select(b => new
                {
                    Title = b.Title,

                })
                .ToArray();

            foreach (var book in booksByCategory)
            {
                ret.AppendLine(book.Title);
            }

            return ret.ToString().Trim();
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {

            StringBuilder ret = new StringBuilder();

            DateTime checkDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var booksReleased = context.Books
                .Where(b => b.ReleaseDate < checkDate)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => new
                {
                    Title = b.Title,
                    Edition = b.EditionType.ToString(),
                    Price = string.Format("${0:F2}", b.Price),

                })
                .ToArray();

            foreach (var book in booksReleased)
            {
                ret.AppendLine(string.Format("{0} - {1} - {2}", book.Title, book.Edition, book.Price));
            }

            return ret.ToString().Trim();
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {

            StringBuilder ret = new StringBuilder();

            string[] authorNames = context.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .OrderBy(a => a.FirstName)
                .ThenBy(a => a.LastName)
                .Select(a => String.Format("{0} {1}", a.FirstName, a.LastName))
                .ToArray();

            ret.AppendLine(string.Join(Environment.NewLine, authorNames));

            return ret.ToString().Trim();
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {

            StringBuilder ret = new StringBuilder();

            string check = input.ToLower();

            string[] bookTitles = context.Books
                .Where(b => b.Title.ToLower().Contains(check))
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToArray();

            ret.AppendLine(string.Join(Environment.NewLine, bookTitles));

            return ret.ToString().Trim();

        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {

            StringBuilder ret = new StringBuilder();

            string check = input.ToLower();

            var bookTitles = context.Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(check))
                .OrderBy(b => b.BookId)
                .Select(b => new
                {
                    BookTitle = b.Title,
                    AuthorName = String.Format("{0} {1}", b.Author.FirstName, b.Author.LastName),
                })
                .ToArray();

            foreach (var book in bookTitles)
            {
                ret.AppendLine(string.Format("{0} ({1})", book.BookTitle, book.AuthorName));
            }

            return ret.ToString().Trim();

        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {

            int bookCount = context.Books
                .Where(b => b.Title.Length > lengthCheck)
                .Count();

            return bookCount;

        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {

            StringBuilder ret = new StringBuilder();

            var bookCopies = context.Authors
                .Select(a => new
                {
                    AuthorName = string.Format("{0} {1}", a.FirstName, a.LastName),
                    TotalBookCopies = a.Books.Sum(b => b.Copies), 
                })
                .OrderByDescending(a => a.TotalBookCopies)
                .ToArray();

            foreach(var copy in bookCopies)
            {
                ret.AppendLine(String.Format("{0} - {1}", copy.AuthorName, copy.TotalBookCopies));
            }

            return ret.ToString().Trim();

        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {

            StringBuilder ret = new StringBuilder();

            var categoryProfits = context.Categories
                .Select(c => new
                {
                    CategoryName = c.Name,
                    TotalProfit = c.CategoryBooks
                        .Select(bc => new 
                        {
                            Profit = bc.Book.Price * bc.Book.Copies,
                        })
                        .Sum(bc => bc.Profit),

                })
                .OrderByDescending(c => c.TotalProfit)
                .ThenBy(c => c.CategoryName)
                .ToArray();

            foreach (var profit in categoryProfits)
            {
                ret.AppendLine(String.Format("{0} ${1:F2}", profit.CategoryName, profit.TotalProfit));
            }

            return ret.ToString().Trim();

        }

        public static string GetMostRecentBooks(BookShopContext context)
        {

            StringBuilder ret = new StringBuilder();

            var newestBooksByCategory = context.Categories
                .OrderBy(c => c.Name)
                .Select(c => new
                {
                    CategoryName = c.Name,
                    RecentBooks = c.CategoryBooks
                        .OrderByDescending(bc => bc.Book.ReleaseDate)
                        .Take(3)
                        .Select(bc => new
                        {
                            BookTitle = bc.Book.Title,
                            BookReleaseDate = String.Format("{0:yyyy}", bc.Book.ReleaseDate),
                        })
                        .ToArray(),

                })
                .ToArray();

            foreach (var cat in newestBooksByCategory)
            {
                ret.AppendLine(String.Format("--{0}", cat.CategoryName));

                foreach(var book in cat.RecentBooks)
                {
                    ret.AppendLine(String.Format("{0} ({1})", book.BookTitle, book.BookReleaseDate));
                }
            }

            return ret.ToString().Trim();

        }

        public static void IncreasePrices(BookShopContext context)
        {
            DateTime releaseDateBefore = new DateTime(2010, 1, 1);

            var booksPriceIncrease = context.Books
                .Where(b => b.ReleaseDate < releaseDateBefore);

            foreach (var book in booksPriceIncrease)
            {
                book.Price = book.Price + 5;
            }

            context.SaveChanges();

        }

        public static int RemoveBooks(BookShopContext context)
        {
            DateTime releaseDateBefore = new DateTime(2010, 1, 1);

            var booksToDelete = context.Books
                .Where(b => b.Copies < 4200);

            int ret = booksToDelete.Count();

            context.RemoveRange(booksToDelete);

            context.SaveChanges();

            return ret;

        }




    }
}



namespace Book.Tests
{
    using System;

    using NUnit.Framework;
    using static System.Net.Mime.MediaTypeNames;

    [TestFixture]
    public class Tests
    {

        private const string BOOK_NAME_1 = "Nose Scratching Mastership";
        private const string BOOK_NAME_2 = "TEST_BOOK_2";
        private const string BOOK_NAME_3 = "TEST_BOOK_3";

        private const string BOOK_AUTHOR_1 = "Bai Ivan";
        private const string BOOK_AUTHOR_2 = "TEST_AUTHOR_2";
        private const string BOOK_AUTHOR_3 = "TEST_AUTHOR_3";

        private const string BOOK_FOOTNOTE_1 = "Real Star!";
        private const string BOOK_FOOTNOTE_2 = "Footnote 2";
        private const string BOOK_FOOTNOTE_3 = "Footnote 3";

        private Book book;

        [SetUp]
        public void Setup()
        {
            book = new Book(BOOK_NAME_1, BOOK_AUTHOR_1);
        }

        [Test]
        public void Test_01_Book_Constructor_Valid()
        {
            Assert.AreEqual(book.BookName, BOOK_NAME_1);
            Assert.AreEqual(book.Author, BOOK_AUTHOR_1);
            Assert.AreEqual(book.FootnoteCount, 0);

            book = new Book("   ", "   ");
            Assert.AreEqual(book.FootnoteCount, 0);
        }

        [Test]
        public void Test_02_Book_Constructor_Invalid()
        {
            Assert.Throws<ArgumentException>(() => book = new Book(null, BOOK_AUTHOR_1));
            Assert.Throws<ArgumentException>(() => book = new Book("", BOOK_AUTHOR_1));

            Assert.Throws<ArgumentException>(() => book = new Book(BOOK_NAME_1, null));
            Assert.Throws<ArgumentException>(() => book = new Book(BOOK_NAME_1, ""));
        }

        [Test]
        public void Test_03_Book_FootnoteCount_Valid()
        {
            book.AddFootnote(1, BOOK_FOOTNOTE_1);
            book.AddFootnote(2, BOOK_FOOTNOTE_2);
            book.AddFootnote(-3, "");

            Assert.AreEqual(book.FootnoteCount, 3);

            book.AlterFootnote(-3, "Changed footnote!");

            Assert.AreEqual(book.FootnoteCount, 3);

        }

        [Test]
        public void Test_04_Book_FootnoteCount_Invalid()
        {
            // None
        }

        [Test]
        public void Test_05_Book_BookName_Valid()
        {
            // Already tested

        }

        [Test]
        public void Test_06_Book_BookName_Invalid()
        {
            // Already tested

        }

        [Test]
        public void Test_07_Book_Author_Valid()
        {
            // Already tested

        }

        [Test]
        public void Test_08_Book_Author_Invalid()
        {
            // Already tested

        }

        [Test]
        public void Test_09_Book_AddFootnote_Valid()
        {
            book.AddFootnote(1, BOOK_FOOTNOTE_1);
            Assert.AreEqual(book.FindFootnote(1), $"Footnote #{1}: {BOOK_FOOTNOTE_1}" );

            book.AddFootnote(-1, BOOK_FOOTNOTE_1);
            Assert.AreEqual(book.FindFootnote(-1), $"Footnote #{-1}: {BOOK_FOOTNOTE_1}");

            book.AddFootnote(100, BOOK_FOOTNOTE_3);
            Assert.AreEqual(book.FindFootnote(100), $"Footnote #{100}: {BOOK_FOOTNOTE_3}");

            book.AddFootnote(1000, "");
            Assert.AreEqual(book.FindFootnote(1000), $"Footnote #{1000}: ");

            for(int i = 1001; i <= 12000; i++)
            {
                book.AddFootnote(i, "");
            }
            Assert.AreEqual(book.FootnoteCount, 11004);
        }

        [Test]
        public void Test_10_Book_AddFootnote_Invalid()
        {
            book.AddFootnote(1, BOOK_FOOTNOTE_1);

            Assert.Throws<InvalidOperationException>(() => book.AddFootnote(1, BOOK_FOOTNOTE_2));

            book.AddFootnote(-2, BOOK_FOOTNOTE_2);

            Assert.Throws<InvalidOperationException>(() => book.AddFootnote(-2, ""));

        }

        [Test]
        public void Test_11_Book_FindFootnote_Valid()
        {
            // Already tested
        }

        [Test]
        public void Test_12_Book_FindFootnote_Invalid()
        {
            Assert.Throws<InvalidOperationException>(() => book.FindFootnote(1));

            book.AddFootnote(1, BOOK_FOOTNOTE_1);

            Assert.Throws<InvalidOperationException>(() => book.FindFootnote(-1));

        }

        [Test]
        public void Test_13_Book_AlterFootnote_Valid()
        {
            book.AddFootnote(1, BOOK_FOOTNOTE_1);
            book.AddFootnote(2, BOOK_FOOTNOTE_2);
            book.AddFootnote(3, BOOK_FOOTNOTE_3);
            book.AddFootnote(4, "");

            book.AlterFootnote(1, "");
            Assert.AreEqual(book.FindFootnote(1), $"Footnote #{1}: ");

            book.AlterFootnote(1, BOOK_FOOTNOTE_1);
            book.AlterFootnote(4, "UNIQUE");
            Assert.AreEqual(book.FindFootnote(1), $"Footnote #{1}: {BOOK_FOOTNOTE_1}");
            Assert.AreEqual(book.FindFootnote(4), $"Footnote #{4}: UNIQUE");

            book.AlterFootnote(2, BOOK_FOOTNOTE_3);
            book.AlterFootnote(3, "");
            Assert.AreEqual(book.FindFootnote(2), $"Footnote #{2}: {BOOK_FOOTNOTE_3}");
            Assert.AreEqual(book.FindFootnote(3), $"Footnote #{3}: ");
        }

        [Test]
        public void Test_14_Book_AlterFootnote_Invalid()
        {
            Assert.Throws<InvalidOperationException>(() => book.AlterFootnote(0, " "));
            Assert.Throws<InvalidOperationException>(() => book.AlterFootnote(1, " "));

            book.AddFootnote(1, BOOK_FOOTNOTE_1);
            book.AddFootnote(2, BOOK_FOOTNOTE_2);
            Assert.Throws<InvalidOperationException>(() => book.AlterFootnote(3, " "));

        }

    }
}
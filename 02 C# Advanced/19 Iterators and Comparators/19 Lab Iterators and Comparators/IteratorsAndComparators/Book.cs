namespace IteratorsAndComparators
{
    using System;
    using System.Collections.Generic;
    //using System.Linq;
    using System.Text;

    public class Book : IComparable<Book>
    {
        private int id;
        private static int next = 0;
        private string title;
        private int year;

        public int Id { get { return id; } }
        public string Title { get { return title; } set { title = value; } }
        public int Year { get { return year; } set { year = value; } }  
        public IReadOnlyList<string> Authors { get; private set; } 

        /*
        public Book()
        {
            this.id = next;
            next++;
            this.title = "";
            this.year = 0;
            this.Authors = new List<string>();

        }
        */

        /*
        public Book(string title_in, int year_in, List<string> authors_in)
        {
            this.id = next;
            next++;
            this.Title = title_in;
            this.Year = year_in;
            this.Authors = authors_in;
        }
        */

        public Book(string title_in, int year_in, params string[] authors_in )
        {
            this.id = next;
            next++;
            this.Title = title_in;
            this.Year = year_in;
            this.Authors = new List<string>(authors_in);
        }

        public override string ToString()
        {
            //return String.Format("{0} - {1}\n{2}", this.Title, this.Year, string.Join('\n', this.Authors));
            return String.Format("{0} - {1}", this.Title, this.Year);
        }

        public int CompareTo(Book other)
        {
            int ret = 0;

            ret = this.Year.CompareTo(other.Year);

            if(ret == 0)
            {
                ret = this.Title.CompareTo(other.Title);
            }

            if (ret == 0)
            {
                ret = this.id.CompareTo(other.id);
            }

            return ret;

        }
    }
}

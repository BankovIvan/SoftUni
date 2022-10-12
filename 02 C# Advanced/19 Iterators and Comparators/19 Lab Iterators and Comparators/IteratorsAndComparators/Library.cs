namespace IteratorsAndComparators
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    //using System.Linq;
    using System.Text;

    public class Library : IEnumerable<Book>
    {
        public List<Book> Books;

        public Library(params Book[] books)
        {
            this.Books = new List<Book>(books);
            this.Books.Sort();
        }


        public IEnumerator<Book> GetEnumerator()
        {
            for (int i = 0; i < this.Books.Count; i++)
            {
                yield return this.Books[i];
            }

            //return new LibraryIterator(this.Books);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private class LibraryIterator : IEnumerator<Book>
        {
            private readonly List<Book> books;
            private int index;

            public LibraryIterator(IEnumerable<Book> books)
            {
                this.Reset();
                this.books = new List<Book>(books);
            }

            public void Dispose()
            {
                //throw new NotImplementedException();
            }

            public bool MoveNext()
            {
                bool ret = false;

                ret = ++this.index < this.books.Count;

                return ret;

            }

            public void Reset()
            {
                this.index = -1;
            }

            public Book Current { get { return this.books[this.index]; } }

            object IEnumerator.Current { get { return this.Current; } }

        }

    }
}

using P02._Books_After;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P02._Books_After
{
    public class Library
    {
        private ICollection<Book> books;

        public Library(ICollection<Book> books)
        {
            this.books = books;
        }

        public Book FindBook(string title)
        {
            return books
                .Where(b => b.Title == title)
                .FirstOrDefault();
        }
    }
}

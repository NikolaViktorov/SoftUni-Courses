using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IteratorsAndComparators
{
    public class Book
    {
        string title;
        int year;
        IReadOnlyList<string> authors;

        public string Title
        {
            get => title;
            set => title = value;
        }
        public int Year
        {
            get => year;
            set => year = value;
        }
        public IReadOnlyList<string> Authors
        {
            get => authors;
            set => authors = value;
        }

        public Book(string title, int year, params string[] authors)
        {
            this.title = title;
            this.year = year;
            this.authors = authors;
        }
    }
}

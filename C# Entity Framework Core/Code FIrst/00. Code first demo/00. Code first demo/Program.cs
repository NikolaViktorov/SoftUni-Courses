using _00._Code_first_demo.Data;
using System;
using System.Linq;

namespace _00._Code_first_demo
{
    class Program
    {
        static void Main(string[] args)
        {
            using var db = new StudentDbContext();

            db.Students.ToList();
        }
    }
}

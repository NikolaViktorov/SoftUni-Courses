using _00._Outputting_data_from_db.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace _00._Outputting_data_from_db
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new SoftUniContext())
            {
                var towns = db.Towns
                    .Select(e => new 
                    {
                        Name = e.Name,
                        Addresses = e.Addresses
                    })
                    .ToList();
                foreach (var town in towns)
                {
                    Console.WriteLine(town.Name);

                    foreach (var address in town.Addresses)
                    {
                        Console.WriteLine($"--- {address.AddressText}");
                    }
                }
            }
        }
    }
}

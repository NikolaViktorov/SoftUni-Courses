using System;
using System.Collections.Generic;
using System.Linq;


namespace _06._Parking_Lot
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            HashSet<string> cars = new HashSet<string>();

            while (input[0] != "END")
            {
                string direciton = input[0];
                string car = input[1];

                if (direciton == "IN")
                {
                    cars.Add(car);
                }
                else
                {
                    if (cars.Contains(car) == true)
                    {
                        cars.Remove(car);
                    }
                }

                input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);
            }

            if (cars.Count > 0)
            {
                foreach (string car in cars)
                {
                    Console.WriteLine(car);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}

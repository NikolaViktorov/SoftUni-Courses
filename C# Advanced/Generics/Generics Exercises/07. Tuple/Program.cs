using System;
using System.Linq;

namespace GenericsExercise
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] nameAndAdress = Console.ReadLine()
                .Split();
            string[] nameAndBeer = Console.ReadLine()
                .Split();
            string[] nums = Console.ReadLine()
                .Split();

            string name = nameAndAdress[0] + " " + nameAndAdress[1];
            string adress = nameAndAdress[2];

            Tuple<string, string> nameAdress =
                new Tuple<string, string>(name, adress);

            string beerManName = nameAndBeer[0];
            int beers = int.Parse(nameAndBeer[1]);

            Tuple<string, int> nameBeer =
                new Tuple<string, int>(beerManName, beers);

            int firstNum = int.Parse(nums[0]);
            double secNum = double.Parse(nums[1]);

            Tuple<int, double> intDouble =
                new Tuple<int, double>(firstNum, secNum);

            Console.WriteLine(nameAdress.ToString());
            Console.WriteLine(nameBeer.ToString());
            string res = intDouble.ToString();
            Console.WriteLine(res);
            
        }
    }
}

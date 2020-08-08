using System;
using System.Linq;

namespace GenericsExercise
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] nameAdressTown = Console.ReadLine()
                .Split();
            string[] nameAndBeer = Console.ReadLine()
                .Split();
            string[] bankAcc = Console.ReadLine()
                .Split();

            string name = nameAdressTown[0] + " " + nameAdressTown[1];
            string adress = nameAdressTown[2];
            string[] townInfo = nameAdressTown.Skip(3).ToArray();
            string town = townInfo[0];
            for (int i = 1; i < townInfo.Length; i++)
            {
                town += " " + townInfo[i];
            }

            Tuple<string, string, string> nameAdress =
                new Tuple<string, string, string>(name, adress, town);

            string beerManName = nameAndBeer[0];
            int liters = int.Parse(nameAndBeer[1]);
            bool drunk = nameAndBeer[2] == "drunk" ? true : false;

            Tuple<string, int, bool> nameBeer =
                new Tuple<string, int, bool>(beerManName, liters, drunk);

            string bankName = bankAcc[2];
            double ball = double.Parse(bankAcc[1]);
            string personName = bankAcc[0];

            Tuple<string, double, string> bankAccount =
                new Tuple<string, double, string>(personName, ball, bankName);

            Console.WriteLine(nameAdress.ToString());
            Console.WriteLine(nameBeer.ToString());
            Console.WriteLine(bankAccount);
            
        }
    }
}

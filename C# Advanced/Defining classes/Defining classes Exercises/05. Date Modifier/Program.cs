using System;

namespace _05._Date_Modifier
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string firstDate = Console.ReadLine();
            string secondDate = Console.ReadLine();

            Console.WriteLine(DateModifier.CalculateDiffInDays(firstDate, secondDate));
               
        }
    }
}

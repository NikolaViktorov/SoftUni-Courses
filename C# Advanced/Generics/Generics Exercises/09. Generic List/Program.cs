using System;

namespace GenericsExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomList<string> names = new CustomList<string>();

            names.Add("fuck");
            if (names.Contains("kys"))
            {
                Console.WriteLine("yes");
            }

            names.InsertAt(0, "pesho");
            names.RemoveAt(1);
            Console.WriteLine(names[0]);
        }
    }
}

using System;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList randList = new RandomList();

            randList.Add("a");
            randList.Add("b");
            randList.Add("c");
            randList.Add("d");
            randList.Add("e");
            randList.Add("f");
            randList.Add("g");


            Console.WriteLine(randList.RandomString());
            Console.WriteLine(string.Join(", ", randList));
        }
    }
}

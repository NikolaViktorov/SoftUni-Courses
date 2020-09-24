using System;

namespace _06._Coding_Tracker
{
    [Author("Ventsi")]
    public class StartUp
    {
        [Author("Gosho")]
        static void Main(string[] args)
        {
            var tracker = new Tracker();
            Tracker.PrintMethodsByAuthor();
        }
    }
}

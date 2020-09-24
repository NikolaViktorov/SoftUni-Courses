using System;

namespace _05._Create_Attribute
{
    [Author("Ventsi")]
    public class StartUp
    {
        [Author("Gosho")]
        static void Main(string[] args)
        {
            var tp = typeof(StartUp);

            var attributes = tp.CustomAttributes;

            foreach (var atr in attributes)
            {
                if (atr.AttributeType == typeof(AuthorAttribute))
                {
                    Console.WriteLine(atr.NamedArguments.Count);
                }
            }
        }
    }
}

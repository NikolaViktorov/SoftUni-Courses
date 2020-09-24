using System;

namespace BoxData
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int height = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int lenght = int.Parse(Console.ReadLine());

            try
            {
                Box box = new Box(lenght, width, height);

                Console.WriteLine($"Surface Area – {box.GetSurfaceArea():F2}");
                Console.WriteLine($"Lateral Surface Area – {box.GetLateralSurfaceArea():F2}");
                Console.WriteLine($"Volume  – {box.Volume():F2}");
            }
            catch (Exception a)
            {
                Console.WriteLine(a.Message);
            }
            
        }
    }
}

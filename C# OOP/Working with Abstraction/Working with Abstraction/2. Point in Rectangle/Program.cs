using System;
using System.Linq;

namespace _2._Point_in_Rectangle
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int[] recPoints = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Point topLeft = new Point(recPoints[0], recPoints[1]);
            Point bottomRight = new Point(recPoints[2], recPoints[3]);
            Rectangle rectangle = new Rectangle(topLeft, bottomRight);

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                int[] pointCord = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
                Point curPoint = new Point(pointCord[0], pointCord[1]);
                Console.WriteLine(rectangle.Contains(curPoint));
            }
        }
    }
}

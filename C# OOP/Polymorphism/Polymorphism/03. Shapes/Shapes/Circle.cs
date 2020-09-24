using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Circle : Shape
    {
        public double Radius { get; protected set; }
        public Circle(double radius)
        {
            this.Radius = radius;
        }
        public override double CalculateArea()
        {
            return Math.Round(Math.PI * Radius * Radius, 2);
        }
        public override double CalculatePerimeter()
        {
            return Math.Round(Math.PI * Radius, 2);
        }
        public override string Draw()
        {
            string result = "";
            double rIn = Radius - 0.4;
            double rOut = Radius + 0.4;
            for (double y = Radius; y >= -Radius; --y)
            {
                for (double x = -Radius; x < rOut; x += 0.5)
                {
                    double value = x * x + y * y;

                    if (value >= rIn * rIn && value <= rOut * rOut)
                    {
                        result += "*";
                    }
                    else
                    {
                        result += " ";
                    }
                }
                result += Environment.NewLine;
            }
            return result;
        }
    }
}

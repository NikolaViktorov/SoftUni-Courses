using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectangle : Shape
    {
        public double Height { get; protected set; }
        public double Width { get; protected set; }
        public Rectangle(double height, double width)
        {
            this.Height = height;
            this.Width = width;
        }
        public override double CalculateArea()
        {
            return Height * Width;
        }
        public override double CalculatePerimeter()
        {
            return 2 * Height + 2 * Width;
        }
        public override string Draw()
        {
            string result = DrawLine(Width, '*', '*');
            for (int i = 1; i < Height - 1; ++i)
            {
                result += DrawLine(Width, '*', ' ');
            }
            result += DrawLine(Width, '*', '*');
            return result;
        }
        private string DrawLine(double width, char end, char mid)
        {
            string result = $"{end}";
            for (int i = 1; i < width - 1; i++)
            {
                result += mid;
            }
            result += end + Environment.NewLine;
            return result;
        }
    }
}

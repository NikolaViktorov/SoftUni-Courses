using System;
using System.Collections.Generic;
using System.Text;

namespace BoxData
{
    public class Box
    {
        double width;
        double lenght;
        double height;

        double Lenght
        {
            get => lenght;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Lenght cannot be zero or negative.");
                }
                lenght = value;
            }
        }
        double Width
        {
            get => width;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }
                width = value;
            }
        }
        double Height
        {
            get => height;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }
                height = value;
            }
        }
        public Box(double lenght, double width, double height)
        {
            this.Width = width;
            this.Lenght = lenght;
            this.Height = height;
        }

        public double GetSurfaceArea()
        {
            // 2lw + 2lh + 2wh
            return 2 * lenght * width + 2 * lenght * height + 2 * width * height;
        }
        public double GetLateralSurfaceArea()
        {
            // 2lh + 2wh
            return 2 * lenght * height + 2 * width * height;
        }
        public double Volume()
        {
            // lwh
            return lenght * width * height;
        }
    }
}

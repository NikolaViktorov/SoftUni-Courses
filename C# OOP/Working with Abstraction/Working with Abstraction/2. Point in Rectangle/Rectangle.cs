using System;
using System.Collections.Generic;
using System.Text;

namespace _2._Point_in_Rectangle
{
    public class Rectangle
    {
        public Point TopLeft { get; set; }
        public Point BottomRight { get; set; }

        public Rectangle(Point topLeft, Point bottomRight)
        {
            this.TopLeft = topLeft;
            this.BottomRight = bottomRight;
        }

        public bool Contains(Point point)
        {
            bool insideX = point.X >= TopLeft.X && point.X <= BottomRight.X;
            bool insideY = point.Y <= BottomRight.Y && point.Y >= TopLeft.Y;
            return insideX && insideY;
        }
    }
}

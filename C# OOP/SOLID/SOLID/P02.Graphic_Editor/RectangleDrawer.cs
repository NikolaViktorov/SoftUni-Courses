using P02.Graphic_Editor.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P02.Graphic_Editor
{
    public class RectangleDrawer : IGraphicEditor
    {
        public void DrawShape(IShape shape)
        {
            Console.WriteLine("Rec");
        }

        public bool IsMatch(IShape shape)
        {
            return shape is Rectangle;
        }
    }
}

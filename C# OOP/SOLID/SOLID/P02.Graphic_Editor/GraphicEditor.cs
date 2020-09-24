using P02.Graphic_Editor.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P02.Graphic_Editor
{
    public class GraphicEditor : IGraphicEditor
    {
        public void DrawShape(IShape shape)
        {
            List<IGraphicEditor> drawers = new List<IGraphicEditor>()
            {
                new RectangleDrawer(),
                new CircleDrawer(),
                new SquareDrawer()
            };

            drawers.First(x => x.IsMatch(shape)).DrawShape(shape);
        }

        public bool IsMatch(IShape shape)
        {
            throw new NotImplementedException();
        }
    }
}

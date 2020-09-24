using P02.Graphic_Editor.Contracts;

namespace P02.Graphic_Editor
{
    internal class SquareDrawer : IGraphicEditor
    {
        public void DrawShape(IShape shape)
        {
            System.Console.WriteLine("squ");
        }

        public bool IsMatch(IShape shape)
        {
            return shape is Square; 
        }
    }
}
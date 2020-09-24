using P02.Graphic_Editor.Contracts;

namespace P02.Graphic_Editor
{
    internal class CircleDrawer : IGraphicEditor
    {
        public void DrawShape(IShape shape)
        {
            System.Console.WriteLine("cir");
        }

        public bool IsMatch(IShape shape)
        {
            return shape is Circle;
        }
    }
}
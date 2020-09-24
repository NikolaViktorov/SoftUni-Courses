using System;
using System.Collections.Generic;
using System.Text;

namespace P02._DrawingShape_Before.Contracts
{
    public interface IDrawer
    {
        void Draw(IShape shape);
    }
}

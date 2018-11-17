using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingToolkit.Command
{
    public abstract class ParametricDrawableCommand : DrawableCommand
    {
        protected readonly int x, y;

        public ParametricDrawableCommand(DrawingCanvas canvas, DrawingObject drawing, int x, int y) : base(canvas, drawing)
        {
            this.x = x;
            this.y = y;
        }
    }
}

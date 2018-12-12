using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DrawingToolkit.Command
{
    public abstract class ChangeColorCommand : DrawableCommand
    {
        protected Color oldColor;
        protected Color newColor;

        public ChangeColorCommand(DrawingCanvas canvas, DrawingObject drawing, Color color) : base(canvas, drawing)
        {
            newColor = color;
            oldColor = drawing.BackgroundColor;
        }
    }
}

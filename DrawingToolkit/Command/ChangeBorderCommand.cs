using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingToolkit.Command
{
    public class ChangeBorderCommand : ChangeColorCommand
    {
        public ChangeBorderCommand(DrawingCanvas canvas, DrawingObject drawing, Color color) : base(canvas, drawing, color)
        {
        }

        public override void Execute()
        {
            drawingObject.BorderColor = newColor;
        }

        public override void Unexecute()
        {
            drawingObject.BorderColor = oldColor;
        }
    }
}

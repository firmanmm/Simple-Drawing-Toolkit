using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DrawingToolkit.Command
{
    class ChangeBackgroundCommand : ChangeColorCommand
    {
        public ChangeBackgroundCommand(DrawingCanvas canvas, DrawingObject drawing, Color color) : base(canvas, drawing, color){

        }

        public override void Execute()
        {
            drawingObject.BackgroundColor = newColor;
        }

        public override void Unexecute()
        {
            drawingObject.BackgroundColor = oldColor;
        }
    }
}

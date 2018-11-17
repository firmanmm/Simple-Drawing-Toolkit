using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingToolkit.Command
{
    public class TranslateCommand : ParametricDrawableCommand
    {
        public TranslateCommand(DrawingCanvas canvas, DrawingObject drawingObject, int x, int y) : base(canvas, drawingObject, x, y)
        {
        }

        public override void Execute()
        {
            drawingObject.Translate(x, y);
        }

        public override void Unexecute()
        {
            drawingObject.Translate(-x, -y);
        }
    }
}

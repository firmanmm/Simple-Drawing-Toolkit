using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DrawingToolkit.Command
{
    public class ResizeCommand : ParametricDrawableCommand
    {
        private readonly Point transPoint;
        public ResizeCommand(DrawingCanvas canvas, DrawingObject drawingObject, Point translationPoint, int x, int y) : base(canvas, drawingObject, x, y)
        {
            transPoint = translationPoint;
        }

        public override void Execute()
        {
            drawingObject.ResizeByTranslate(transPoint, x, y);
        }

        public override void Unexecute()
        {
            drawingObject.ResizeByTranslate(transPoint, -x, -y);
        }
    }
}

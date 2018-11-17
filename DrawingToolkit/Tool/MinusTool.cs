using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DrawingToolkit.Command;

namespace DrawingToolkit
{
    class MinusTool : Tool
    {
        public MinusTool(DrawingCanvas canvas) : base(canvas) { }

        public override void MouseInit(int x, int y)
        {
            DrawingObject drawable = drawingCanvas.GetLastIntersection(x, y);
            if (drawable != null) {
                drawingCanvas.undoRedoController.AddProcess(new RemoveDrawableCommand(drawingCanvas, drawable));
            }
        }
    }
}

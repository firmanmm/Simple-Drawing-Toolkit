using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingToolkit
{
    class MinusTool : Tool
    {
        public MinusTool(DrawingCanvas canvas) : base(canvas) { }

        public override void MouseInit(int x, int y)
        {
            drawingCanvas.DeleteLastIntersection(x, y);
        }
    }
}

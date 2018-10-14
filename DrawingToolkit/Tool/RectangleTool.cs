using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingToolkit
{
    public class RectangleTool : Tool
    {
        public RectangleTool(DrawingCanvas canvas) : base(canvas)
        {

        }

        public override void MouseInit(int x, int y)
        {
            drawingObject = new Rectangle();
            base.MouseInit(x, y);
        }
    }
}

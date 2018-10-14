using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingToolkit
{
    public class CircleTool : Tool
    {
        public CircleTool(DrawingCanvas canvas) : base(canvas) {
            
        }

        public override void MouseInit(int x, int y)
        {
            drawingObject = new Circle();
            base.MouseInit(x, y);
        }
    }
}

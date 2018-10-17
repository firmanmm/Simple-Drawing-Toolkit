using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DrawingToolkit
{
    public class LineTool : DrawingTool
    {
        public LineTool(DrawingCanvas canvas) : base(canvas) {
            
        }

        public override void MouseInit(int x, int y)
        {
            drawingObject = new Line();
            base.MouseInit(x, y);
        }


    }
}

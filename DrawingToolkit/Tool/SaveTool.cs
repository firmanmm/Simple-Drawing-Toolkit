using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingToolkit
{
    class SaveTool : Tool
    {
        public SaveTool(DrawingCanvas canvas) : base(canvas)
        {
        }

        protected override void Tool_MouseDown(object sender, MouseEventArgs e)
        {
            drawingCanvas.SaveDrawingData();
        }
    }
}

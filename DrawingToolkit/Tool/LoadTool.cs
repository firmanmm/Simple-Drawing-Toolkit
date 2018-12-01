using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingToolkit
{
    public class LoadTool : Tool
    {
        public LoadTool(DrawingCanvas canvas) : base(canvas)
        {
        }

        protected override void Tool_MouseDown(object sender, MouseEventArgs e)
        {
            drawingCanvas.LoadDrawingData();
            drawingCanvas.SetActiveTool(null);
        }
    }
}

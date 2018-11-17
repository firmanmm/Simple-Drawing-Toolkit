using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace DrawingToolkit
{
    public class RedoTool : Tool
    {
        public RedoTool(DrawingCanvas canvas) : base(canvas)
        {

        }

        protected override void Tool_MouseDown(object sender, MouseEventArgs e)
        {
            drawingCanvas.undoRedoController.RedoProcess();
        }
    }
}

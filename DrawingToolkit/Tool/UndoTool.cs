using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingToolkit
{
    public class UndoTool : Tool
    {
        public UndoTool(DrawingCanvas canvas) : base(canvas)
        {

        }

        protected override void Tool_MouseDown(object sender, MouseEventArgs e)
        {
            drawingCanvas.undoRedoController.UndoProcess();
        }
    }
}

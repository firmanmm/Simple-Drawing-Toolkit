using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace DrawingToolkit
{
    public abstract class Tool : ToolStripButton
    {

        private bool _isActive;

        protected DrawingCanvas drawingCanvas;
        protected DrawingObject drawingObject;

        public Tool(DrawingCanvas canvas) {
            drawingCanvas = canvas;
            MouseDown += Tool_MouseDown;
        }

        protected virtual void Tool_MouseDown(object sender, MouseEventArgs e)
        {
            IsActive = true;
        }

        public bool IsActive {
            get { return _isActive; }
            set {
                if (_isActive = value) {
                    BackColor = Color.Silver;
                    if (drawingCanvas.ActiveTool != null) {
                        drawingCanvas.ActiveTool.IsActive = false;
                    }
                    drawingCanvas.ActiveTool = this;
                } else {
                    BackColor = Color.Gainsboro;
                    ClearDrawable();
                }
            }
        }

        public virtual void MouseInit(int x, int y) {
            drawingObject.StartPosition(x, y);
        }

        public void MouseUpdate(int x, int y)
        {
            if (drawingObject != null) {
                drawingObject.UpdatePosition(x, y);
            }
        }

        public DrawingObject GetDrawable() {
            return drawingObject;
        }

        private void ClearDrawable() {
            drawingObject = null;
        }
        
    }
}

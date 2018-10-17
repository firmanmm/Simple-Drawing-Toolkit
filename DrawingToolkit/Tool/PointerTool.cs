using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingToolkit
{
    public class PointerTool : Tool
    {
        private int lastX;
        private int lastY;
        private DrawingObject focusObject;
        private DrawingObject lastFocusObject;

        public PointerTool(DrawingCanvas canvas) : base(canvas)
        {
            OnInactive = EndPointerTool;
        }

        public override void MouseInit(int x, int y)
        {
            lastX = x;
            lastY = y;
            if (lastFocusObject != null) {
                lastFocusObject.IsActive = false;
            }
            focusObject = drawingCanvas.GetLastIntersection(x, y);
            if (focusObject != null) {
                focusObject.IsActive = true;
            }
        }

        public override void MouseUpdate(int x, int y)
        {
           
            focusObject?.Translate(x - lastX, y- lastY);
            lastX = x;
            lastY = y;
        }

        public override void MouseEnd(int x, int y)
        {
            lastFocusObject = focusObject;
            focusObject = null;
        }

        private void EndPointerTool() {
            if (lastFocusObject != null) {
                lastFocusObject.IsActive = false;
                lastFocusObject = null;
            }
        }
    }
}

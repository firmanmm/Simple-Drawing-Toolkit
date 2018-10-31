using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DrawingToolkit
{
    public class PointerTool : Tool
    {
        private int lastX;
        private int lastY;
        private DrawingObject focusObject;
        private DrawingObject lastFocusObject;
        private Point transResizeIndex;

        public PointerTool(DrawingCanvas canvas) : base(canvas)
        {
            OnInactive = EndPointerTool;
        }

        public override void MouseInit(int x, int y)
        {
            lastX = x;
            lastY = y;
            if (lastFocusObject != null) {
                transResizeIndex = lastFocusObject.GetTransResizeIndex(x, y);
                if (transResizeIndex.X != -7) {
                    focusObject = lastFocusObject;
                }
                lastFocusObject.SetState(IdleState.GetState());
            }
            focusObject = (focusObject == null) ? drawingCanvas.GetLastIntersection(x, y) : focusObject;
            if (focusObject != null) {
                focusObject.SetState(ActiveState.GetState());
            }
        }

        public override void MouseUpdate(int x, int y)
        {
            if (transResizeIndex.X != -7) {
                focusObject?.ResizeByTranslate(transResizeIndex, x - lastX, y - lastY);
            } else {
                focusObject?.Translate(x - lastX, y - lastY);
            }
            lastX = x;
            lastY = y;
        }

        public override void MouseEnd(int x, int y)
        {
            lastFocusObject = focusObject;
            transResizeIndex = new Point(-7, 7);
            focusObject = null;
        }

        private void EndPointerTool() {
            if (lastFocusObject != null) {
                lastFocusObject.SetState(IdleState.GetState());
                lastFocusObject = null;
            }
        }
    }
}

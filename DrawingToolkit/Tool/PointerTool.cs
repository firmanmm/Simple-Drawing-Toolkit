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
        public Action OnCompositeReady;
        public Action OnCompositeNotReady;

        private int lastX;
        private int lastY;
        private LinkedList<DrawingObject> prepareComposite;
        private DrawingObject focusObject;
        private DrawingObject lastFocusObject;
        private Point transResizeIndex;


        public PointerTool(DrawingCanvas canvas) : base(canvas)
        {
            prepareComposite = new LinkedList<DrawingObject>();
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
            ComputeFocus(x,y);
                
        }

        private void ComputeFocus(int x, int y) {
            focusObject = (focusObject == null) ? drawingCanvas.GetLastIntersection(x, y) : focusObject;

            if (focusObject != null) {
                if (lastFocusObject == null || focusObject == lastFocusObject && prepareComposite.Count < 2) {
                    focusObject.SetState(EditState.GetState());
                } else {
                    lastFocusObject?.SetState(ActiveState.GetState());
                }
                if (!prepareComposite.Contains(focusObject)) {
                    prepareComposite.AddLast(focusObject);
                    if (prepareComposite.Count > 1) {
                        OnCompositeReady();
                        focusObject.SetState(ActiveState.GetState());
                    }

                }

            } else {
                SetComposite(IdleState.GetState());
                prepareComposite.Clear();
                OnCompositeNotReady();
            }
        }

        public override void MouseUpdate(int x, int y)
        {
            if (prepareComposite.Count <= 1) {
                focusObject?.OnMouseUpdate(transResizeIndex, x - lastX, y - lastY);
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
            SetComposite(IdleState.GetState());
            prepareComposite.Clear();
            OnCompositeNotReady();
        }

        private void SetComposite(DrawingState drawingState) {
            foreach (DrawingObject obj in prepareComposite) {
                obj.SetState(drawingState);
            }
        }

        public void MakeComposite() {
            if (prepareComposite.Count < 2) {
                return;
            }
            CompositeShape composite = new CompositeShape(prepareComposite);
            foreach (DrawingObject obj in prepareComposite) {
                drawingCanvas.RemoveDrawable(obj);
            }
            drawingCanvas.AddDrawable(composite);
            SetComposite(IdleState.GetState());
            prepareComposite.Clear();
            OnCompositeNotReady();
        }
    }
}

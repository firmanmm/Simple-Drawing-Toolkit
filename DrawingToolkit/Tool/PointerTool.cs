using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using DrawingToolkit.Command;

namespace DrawingToolkit
{
    public class PointerTool : Tool
    {
        public const int NO_MATCH_BOUNDRY = -7;

        public Action OnCompositeReady;
        public Action OnCompositeNotReady;

        private int deltaX;
        private int deltaY;
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
            deltaX = deltaY = 0;
            lastX = x;
            lastY = y;
            if (lastFocusObject != null) {
                transResizeIndex = lastFocusObject.GetTransResizeIndex(x, y);
                if (transResizeIndex.X != NO_MATCH_BOUNDRY) {
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
                    if (focusObject.ChildCount > 0) {
                        OnCompositeReady();
                    }
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
                SetPreparedState(IdleState.GetState());
                prepareComposite.Clear();
                OnCompositeNotReady?.Invoke();
            }
        }

        public override void MouseUpdate(int x, int y)
        {
            deltaX += x - lastX;
            deltaY += y - lastY;

            if (focusObject != null && prepareComposite.Count <= 1) {
                if (transResizeIndex.X != NO_MATCH_BOUNDRY) {
                    focusObject.ResizeByTranslate(transResizeIndex, x - lastX, y - lastY);
                } else {
                    focusObject.Translate(x - lastX, y - lastY);
                }
            }

            lastX = x;
            lastY = y;
        }

        public override void MouseEnd(int x, int y)
        {
            if (focusObject != null && prepareComposite.Count <= 1) {
                if (transResizeIndex.X != NO_MATCH_BOUNDRY) {
                    focusObject.ResizeByTranslate(transResizeIndex, -deltaX, -deltaY);
                    drawingCanvas.undoRedoController.AddProcess(new ResizeCommand(drawingCanvas, focusObject, transResizeIndex, deltaX, deltaY));
                } else {
                    focusObject.Translate(-deltaX, -deltaY);
                    drawingCanvas.undoRedoController.AddProcess(new TranslateCommand(drawingCanvas, focusObject, deltaX, deltaY));
                }
            }

            lastFocusObject = focusObject;
            transResizeIndex = new Point(NO_MATCH_BOUNDRY, -NO_MATCH_BOUNDRY);
            focusObject = null;
        }

        private void EndPointerTool() {
            if (lastFocusObject != null) {
                lastFocusObject.SetState(IdleState.GetState());
                lastFocusObject = null;
            }
            SetPreparedState(IdleState.GetState());
            prepareComposite?.Clear();
            OnCompositeNotReady?.Invoke();
        }

        private void SetPreparedState(DrawingState drawingState) {
            foreach (DrawingObject obj in prepareComposite) {
                obj.SetState(drawingState);
            }
        }

        public void ExecuteComposite() {
            if (prepareComposite.Count == 1) {
                drawingCanvas.undoRedoController.AddProcess(new DecompositeCommand(drawingCanvas, prepareComposite.First.Value));
            } else {
                DrawingObject composite = DrawingObject.MakeComposite(drawingCanvas, prepareComposite.ToArray());
                drawingCanvas.undoRedoController.AddProcess(new CompositeCommand(drawingCanvas, composite));
            }
            SetPreparedState(IdleState.GetState());
            prepareComposite.Clear();
            OnCompositeNotReady();
        }
    }
}

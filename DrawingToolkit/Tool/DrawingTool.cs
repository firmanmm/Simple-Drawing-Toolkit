using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrawingToolkit.Command;

namespace DrawingToolkit
{
    public class DrawingTool : Tool
    {
        protected DrawingObject drawingObject;

        public DrawingTool(DrawingCanvas canvas) : base(canvas){
           
        }

        public override void MouseInit(int x, int y)
        {
            drawingCanvas.undoRedoController.AddProcess(new AddDrawableCommand(drawingCanvas,drawingObject));
            drawingObject.StartPosition(x, y);
        }

        public override void MouseUpdate(int x, int y)
        {
            if (drawingObject != null) {
                drawingObject.UpdatePosition(x, y);
            }
        }

        public override void MouseEnd(int x, int y)
        {
            drawingObject?.SetState(IdleState.GetState());
            drawingObject = null;
        }

        public DrawingObject GetDrawable()
        {
            return drawingObject;
        }

        private void ClearDrawable()
        {
            drawingObject = null;
        }

    }
}

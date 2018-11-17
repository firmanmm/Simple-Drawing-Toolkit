using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingToolkit.Command
{
    public class CompositeCommand : DrawableCommand
    {

        private DrawingObject[] drawables;
        private bool isInitialized = false;

        public CompositeCommand(DrawingCanvas canvas, DrawingObject drawing) : base(canvas, drawing)
        {
            drawables = drawingObject.DisAssemble(); //Get Drawable for Undo and Redo Purposes
            foreach (DrawingObject obj in drawables) {
                canvas.RemoveDrawable(obj);
            }
            Unexecute();
            isInitialized = true;
        }

        public override void Execute()
        {
            foreach (DrawingObject obj in drawables) {
                drawingObject.AddChild(obj);
                canvas.RemoveDrawable(obj);
            }
            if (isInitialized) {
                canvas.AddDrawable(drawingObject);
            }
        }

        public override void Unexecute()
        {
            canvas.RemoveDrawable(drawingObject);
            drawingObject.DisAssemble();
            foreach (DrawingObject drawable in drawables) {
                canvas.AddDrawable(drawable);
            }
        }
    }
}

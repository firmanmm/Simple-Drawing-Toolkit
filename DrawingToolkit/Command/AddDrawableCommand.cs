using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingToolkit.Command
{
    public class AddDrawableCommand : DrawableCommand
    {
        public AddDrawableCommand(DrawingCanvas canvas, DrawingObject drawing) : base(canvas, drawing)
        {
        }

        public override void Execute()
        {
            canvas.AddDrawable(drawingObject);
        }

        public override void Unexecute()
        {
            canvas.RemoveDrawable(drawingObject.Id);
        }
    }
}

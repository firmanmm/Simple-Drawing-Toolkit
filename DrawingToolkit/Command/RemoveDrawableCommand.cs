using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingToolkit.Command
{
    public class RemoveDrawableCommand : AddDrawableCommand
    {

        //Reversed Add
        public RemoveDrawableCommand(DrawingCanvas canvas, DrawingObject drawing) : base(canvas, drawing)
        {
        }

        public override void Execute()
        {
            base.Unexecute();
        }

        public override void Unexecute()
        {
            base.Execute();
        }
    }
}

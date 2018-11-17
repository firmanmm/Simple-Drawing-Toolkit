using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingToolkit.Command
{
    public class DecompositeCommand : CompositeCommand
    {

        
        //Reversed Composite
        public DecompositeCommand(DrawingCanvas canvas, DrawingObject drawing) : base(canvas, drawing)
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DrawingToolkit
{
    public class DrawingContext
    {
        public DrawingState State { get; private set; }

        private readonly DrawingObject drawable;

        public DrawingContext(DrawingObject drawable) {
            this.drawable = drawable;
            State = InitState.GetState();
        }
        
        public void Draw(Graphics graphics, Pen pen) {
            State.StateDraw(drawable, graphics, pen);
        }

        public void MouseUpdate(DrawingObject drawing, Point transIndex, int deltaX, int deltaY) {
            State.StateMouseUpdate(drawing, transIndex, deltaX, deltaY);
        }

        public void SetState(DrawingState state)
        {
            State = state;
        }
    }
}

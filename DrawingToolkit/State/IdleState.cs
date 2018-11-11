using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingToolkit
{
    public class IdleState : IDrawingState
    {
        private static IdleState state;

        private IdleState() { }

        public static IdleState GetState() {
            if (state == null) {
                state = new IdleState();
            }
            return state;
        }

        public void StateDraw(DrawingObject drawing, Graphics graphics, Pen pen)
        {
            drawing.DrawGraphic(graphics, pen);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DrawingToolkit
{
    public class InitState : IDrawingState
    {
        private static InitState state;

        private InitState() { }

        public static InitState GetState()
        {
            if (state == null) {
                state = new InitState();
            }
            return state;
        }

        public void StateDraw(DrawingObject drawing, Graphics graphics, Pen pen)
        {
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            drawing.DrawGraphic(graphics, pen);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
        }
    }
}

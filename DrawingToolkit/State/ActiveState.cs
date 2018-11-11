using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DrawingToolkit
{
    public class ActiveState : IDrawingState
    {
        private static ActiveState state;

        private ActiveState() { }

        public static ActiveState GetState()
        {
            if (state == null) {
                state = new ActiveState();
            }
            return state;
        }

        public void StateDraw(DrawingObject drawing, Graphics graphics, Pen pen)
        {
            Color defaultColor = pen.Color;
            float defaultWidth = pen.Width;
            pen.Color = Color.Cyan;
            pen.Width = 2;

            drawing.DrawGraphic(graphics, pen);

            pen.Width = defaultWidth;
            pen.Color = defaultColor;

            drawing.DrawResizePoint(graphics, pen);
        }
    }
}

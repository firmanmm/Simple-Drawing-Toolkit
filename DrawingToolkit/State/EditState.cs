using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DrawingToolkit
{
    public class EditState : DrawingState
    {
        private static EditState state;

        private EditState() { }

        public static EditState GetState()
        {
            if (state == null) {
                state = new EditState();
            }
            return state;
        }

        public override void StateDraw(DrawingObject drawing, Graphics graphics, Pen pen)
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

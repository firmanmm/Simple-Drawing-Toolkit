using System.Drawing;

namespace DrawingToolkit
{
    public class ActiveState : DrawingState
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

        public override void StateDraw(DrawingObject drawing, Graphics graphics, Pen pen)
        {
            Color defaultColor = pen.Color;
            pen.Color = Color.Blue;

            drawing.DrawGraphic(graphics, pen);

            pen.Color = defaultColor;
        }
    }
}

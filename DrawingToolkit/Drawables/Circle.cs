using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingToolkit
{
    public class Circle : SimpleShape
    {

        public Circle() : base(8) {
            name = "Circle";
        }
        public override void DrawGraphic(Graphics graphics, Pen pen)
        {
            if (BackgroundColor.R != 255 || BackgroundColor.G != 255 || BackgroundColor.B != 255) {
                graphics.FillEllipse(new SolidBrush(BackgroundColor), Start.X - Width, Start.Y - Height, Width * 2, Height * 2);
            }
            graphics.DrawEllipse(pen, Start.X - Width, Start.Y - Height, Width * 2, Height * 2);

        }

        public static DrawingObject FromTokenString(Dictionary<int, DrawingObject> drawingPool, string[] token)
        {
            Circle current = new Circle();
            SetBaseProperties(current, token);
            current.UpdateDerived();
            return current;

        }

    }
}

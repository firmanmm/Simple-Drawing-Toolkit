using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DrawingToolkit
{
    public class Rectangle : SimpleShape
    {

        public Rectangle() : base(8) {
            name = "Rectangle";
        }

        public override void DrawGraphic(Graphics graphics, Pen pen)
        {
            if (BackgroundColor.R != 255 || BackgroundColor.G != 255 || BackgroundColor.B != 255) {
                graphics.FillRectangle(new SolidBrush(BackgroundColor), Start.X - Width, Start.Y - Height, Width * 2, Height * 2);
            }
            graphics.DrawRectangle(pen, Start.X - Width, Start.Y - Height, Width * 2, Height * 2);


        }

        public static DrawingObject FromTokenString(Dictionary<int, DrawingObject> drawingPool, string[] token)
        {
            Rectangle current = new Rectangle();
            SetBaseProperties(current, token);
            current.UpdateDerived();
            return current;

        }
    }
}

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
            graphics.DrawEllipse(pen, Start.X - Width, Start.Y - Height, Width * 2, Height * 2);
        }

        public static DrawingObject FromTokenString(Dictionary<int, DrawingObject> drawingPool, string[] token)
        {
            Circle current = new Circle() {
                Id = int.Parse(token[1]),
                Start = new Point(
                    int.Parse(token[3]),
                    int.Parse(token[4])),
                End = new Point(
                    int.Parse(token[5]),
                    int.Parse(token[6]))
            };
            current.UpdateDerived();
            return current;

        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DrawingToolkit
{
    public class ResizePoint : SimpleShape
    {
        public Point Multiplier;

        public ResizePoint(int x, int y, int size) {
            Multiplier = new Point(x, y);
            UpdatePosition(2, 2);
        }

        public override void DrawGraphic(Graphics graphics, Pen pen) {
            graphics.FillRectangle(Brushes.Crimson, Start.X - Width, Start.Y - Height, Width * 2, Height * 2);
        }

    }
}

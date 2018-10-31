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
        public Rectangle() : base(8) { }
        public override void DrawGraphic(Graphics graphics, Pen pen)
        {
            graphics.DrawRectangle(pen, Start.X - width, Start.Y - height, width*2, height*2);
        }
    }
}

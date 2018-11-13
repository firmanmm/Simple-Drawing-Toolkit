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
        public Circle() : base(8) { }
        public override void DrawGraphic(Graphics graphics, Pen pen)
        {
            graphics.DrawEllipse(pen, Start.X - Width, Start.Y - Height, Width * 2, Height * 2);
        }

        
    }
}

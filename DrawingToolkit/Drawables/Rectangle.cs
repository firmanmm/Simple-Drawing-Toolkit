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
        public override void Draw(Graphics graphics, Pen pen)
        {
            graphics.DrawRectangle(pen, Start.X - width / 2f, Start.Y - height / 2f, width * 1.5f, height * 1.5f);
        }
    }
}

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
        public override void Draw(Graphics graphics, Pen pen)
        {
            graphics.DrawEllipse(pen, Start.X - width / 2, Start.Y - height / 2, width * 1.5f, height * 1.5f);
        }
    }
}

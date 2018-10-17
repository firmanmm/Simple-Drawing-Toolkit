using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DrawingToolkit
{
    /// <summary>
    /// A Drawable Object that represent line
    /// </summary>
    public class Line : DrawingObject
    {


        public override void StartPosition(int x, int y)
        {
            _start.X = x;
            _start.Y = y;
        }

        public override void UpdatePosition(int x, int y)
        {
            _end.X = x;
            _end.Y = y;
        }

        protected override void DrawGraphic(Graphics graphics,Pen pen) {
            graphics.DrawLine(pen, _start, _end);
        }

        public override bool IsIntersect(int x, int y)
        {
            return Math.Abs((x - _start.X) * (_end.Y - _start.Y) - (y - _start.Y) * (_end.X - _start.X)) < 5000 && base.IsIntersect(x,y); 
        }
    }
}

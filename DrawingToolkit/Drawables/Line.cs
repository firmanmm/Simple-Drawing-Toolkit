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
        public Line() {
            errorTolerance = 2500;
            resizePoints.AddRange(new ResizePoint[] {
                new ResizePoint(0,0,2),
                new ResizePoint(1,1,2),
            });
        }

        public override void StartPosition(int x, int y)
        {
            _start.X = x;
            _start.Y = y;
            UpdateResizePoint();
        }

        public override void UpdatePosition(int x, int y)
        {
            _end.X = x;
            _end.Y = y;
            UpdateResizePoint();
        }

        protected override void UpdateResizePoint()
        {
            resizePoints[0].StartPosition(_start.X, _start.Y);
            resizePoints[1].StartPosition(_end.X, _end.Y);
        }

        protected override void DrawGraphic(Graphics graphics,Pen pen) {
            graphics.DrawLine(pen, _start, _end);
        }

        public override bool IsIntersect(int x, int y)
        {
            return Math.Abs((x - _start.X) * (_end.Y - _start.Y) - (y - _start.Y) * (_end.X - _start.X)) < errorTolerance && base.IsIntersect(x,y); 
        }

        public override void ResizeByTranslate(Point pos, int x, int y)
        {
            base.ResizeByTranslate(pos, x, y);
            if (pos == null) {
                return;
            }
            if (pos.X == 0 && pos.Y == 0) {
                _start.X += x;
                _start.Y += y;
            } else if(pos.X == 1 && pos.Y == 1){
                _end.X += x;
                _end.Y += y;
            }
        }
    }
}

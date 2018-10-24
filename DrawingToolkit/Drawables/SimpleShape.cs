using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DrawingToolkit
{
    public abstract class SimpleShape : DrawingObject
    {

        protected int width;
        protected int height;

        public SimpleShape() { }
        public SimpleShape(int point) {
            resizePoints.AddRange(new ResizePoint[] {
                new ResizePoint(-1,-1,2),
                new ResizePoint(-1,0,2),
                new ResizePoint(-1,1,2),
                new ResizePoint(0,1,2),
                new ResizePoint(1,1,2),
                new ResizePoint(1,0,2),
                new ResizePoint(1,-1,2),
                new ResizePoint(0,-1,2),
            });
        }

        public override void StartPosition(int x, int y)
        {
            Start = new Point(x, y);
            if (resizePoints.Count > 0) {
                UpdateResizePoint();
            }
        }

        public override void UpdatePosition(int x, int y)
        {
            _end.X = x;
            _end.Y = y;
            if (resizePoints.Count > 0) {
                UpdateResizePoint();
            }
            UpdateDerived();
        }

        private void UpdateDerived()
        {
            width = Math.Abs(_start.X - _end.X);
            height = Math.Abs(_start.Y - _end.Y);
        }

        public override bool IsIntersect(int x, int y)
        {
            int diffX = Math.Abs(_start.X - x);
            int diffY = Math.Abs(_start.Y - y);
            return diffX < width + errorTolerance && diffY < height + errorTolerance;
        }

        protected override void UpdateResizePoint()
        {
            resizePoints[0].StartPosition(_start.X - width, _start.Y - height);
            resizePoints[1].StartPosition(_start.X - width, _start.Y);
            resizePoints[2].StartPosition(_start.X - width, _start.Y + height);
            resizePoints[3].StartPosition(_start.X, _start.Y + height);
            resizePoints[4].StartPosition(_start.X + width, _start.Y + height);
            resizePoints[5].StartPosition(_start.X + width, _start.Y);
            resizePoints[6].StartPosition(_start.X + width, _start.Y - height);
            resizePoints[7].StartPosition(_start.X, _start.Y - height);
        }

        public override Point GetTransResizeIndex(int x, int y)
        {
            Point point = base.GetTransResizeIndex(x, y);
            if (_end.X - _start.X < 0) {
                point.X *= -1;
            }
            if (_end.Y - _start.Y < 0) {
                point.Y *= -1;
            }
            return (Math.Abs(point.X) <= 1 && Math.Abs(point.Y) <= 1) ? point : new Point(-7, 7);
        }

        public override void ResizeByTranslate(Point pos, int x, int y)
        {
            UpdatePosition(_end.X + pos.X * x, _end.Y += pos.Y * y);
        }

        
    }
}

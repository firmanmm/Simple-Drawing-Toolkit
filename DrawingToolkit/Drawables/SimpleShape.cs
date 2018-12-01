using System;
using System.Drawing;

namespace DrawingToolkit
{
    public abstract class SimpleShape : DrawingObject
    {

        public int Width { protected set; get; }
        public int Height { protected set; get; }

        public SimpleShape() {
            name = "Simple";
        }
        public SimpleShape(int point) {
            name = "Simple";
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
            UpdateDerived();
        }

        protected virtual void UpdateDerived()
        {
            Width = Math.Abs(_start.X - _end.X);
            Height = Math.Abs(_start.Y - _end.Y);
            if (resizePoints.Count > 0) {
                UpdateResizePoint();
            }
        }

        public override bool IsIntersect(int x, int y)
        {
            int diffX = Math.Abs(_start.X - x);
            int diffY = Math.Abs(_start.Y - y);
            return diffX < Width + errorTolerance && diffY < Height + errorTolerance;
        }

        protected override void UpdateResizePoint()
        {
            resizePoints[0].StartPosition(_start.X - Width, _start.Y - Height);
            resizePoints[1].StartPosition(_start.X - Width, _start.Y);
            resizePoints[2].StartPosition(_start.X - Width, _start.Y + Height);
            resizePoints[3].StartPosition(_start.X, _start.Y + Height);
            resizePoints[4].StartPosition(_start.X + Width, _start.Y + Height);
            resizePoints[5].StartPosition(_start.X + Width, _start.Y);
            resizePoints[6].StartPosition(_start.X + Width, _start.Y - Height);
            resizePoints[7].StartPosition(_start.X, _start.Y - Height);
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

        public override int[] GetBorder()
        {
            return new int[] {_start.X-Width,_start.Y-Height,_end.X,_end.Y};
        }

    }
}

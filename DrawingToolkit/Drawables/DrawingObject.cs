using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DrawingToolkit
{
    public abstract class DrawingObject
    {
        private readonly DrawingContext State;
        
        protected Point _start;
        protected Point _end;
        protected int errorTolerance = 3;
        protected List<ResizePoint> resizePoints;

        public DrawingObject() {
            State = new DrawingContext(this);
            resizePoints = new List<ResizePoint>();
        }

        public Point Start
        {
            get { return _start; }
            set {
                if ((_start = value) == null) {
                    _start = new Point(0, 0);
                }
            }
        }

        public Point End
        {
            get { return _end; }
            set {
                if ((_end = value) == null) {
                    _end = new Point(0, 0);
                }
            }
        }

        public abstract void StartPosition(int x, int y);
        public abstract void UpdatePosition(int x, int y);

        public virtual Point GetTransResizeIndex(int x, int y) {
            foreach (ResizePoint point in resizePoints) {
                if (point.IsIntersect(x, y)) {
                    return point.Multiplier;
                }
            }
            return new Point(-7, 7);
        }
        public abstract void DrawGraphic(Graphics graphics, Pen pen);
        protected abstract void UpdateResizePoint();

        public virtual void ResizeByTranslate(Point pos, int x, int y)
        {
            UpdateResizePoint();
        }

        public void DrawResizePoint(Graphics graphics, Pen pen) {
            foreach (ResizePoint point in resizePoints) {
                point.DrawGraphic(graphics, pen);
            }
        }

        public virtual void Draw(Graphics graphics, Pen pen) {
            State.Draw(graphics, pen);
        }

        public void Translate(int x, int y) {
            _start.X += x;
            _start.Y += y;
            _end.X += x;
            _end.Y += y;
            UpdateResizePoint();
        }

        public virtual bool IsIntersect(int x, int y) {
            Point first = _start;
            Point second = _end;
            if (first.X > second.X) {
                Point temp = first;
                first = second;
                second = temp;
            }
            if (x < first.X || x > second.X) {
                return false;
            }
            if (first.Y > second.Y) {
                Point temp = first;
                first = second;
                second = temp;
            }
            if(y < first.Y || y > second.Y) {
                return false;
            }

            return true;

        }

        public void SetState(IDrawingState state) {
            State.SetState(state);
        }
    }
}

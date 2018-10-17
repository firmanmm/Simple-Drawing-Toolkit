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
        public bool IsActive { get; set; }
        protected Point _start;
        protected Point _end;

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
        public virtual void Draw(Graphics graphics, Pen pen) {
            pen.Color = (IsActive) ? Color.Blue : Color.Black;
            pen.Width = (IsActive) ? 2 : 1;
            DrawGraphic(graphics, pen);
            pen.Width = 1;
            pen.Color = Color.Black;
        }
        protected abstract void DrawGraphic(Graphics graphics, Pen pen);

        public void Translate(int x, int y) {
            _start.X += x;
            _start.Y += y;
            _end.X += x;
            _end.Y += y;
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
    }
}

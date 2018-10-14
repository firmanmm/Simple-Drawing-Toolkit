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

        private Point _start;
        private Point _end;

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
                UpdateSize();
            }
        }

        public override void StartPosition(int x, int y)
        {
            Start = new Point(x, y);
        }

        public override void UpdatePosition(int x, int y)
        {
            _end.X = x;
            _end.Y = y;
            UpdateSize();
        }

        private void UpdateSize()
        {
            width = Math.Abs(_start.X - _end.X);
            height = Math.Abs(_start.Y - _end.Y);
        }
    }
}

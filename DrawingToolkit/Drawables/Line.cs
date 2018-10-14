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
        private Point _start;
        private Point _end;

        public Point Start {
            get { return _start; }
            set {
                if ((_start = value) == null) {
                    _start = new Point(0, 0);
                }
            }
        }

        public Point End {
            get { return _end; }
            set {
                if ((_end = value) == null) {
                    _end = new Point(0, 0);
                }
            }
        }

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

        public override void Draw(Graphics graphics,Pen pen) {
            graphics.DrawLine(pen, _start, _end);
        }
    }
}

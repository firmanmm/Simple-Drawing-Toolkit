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

        public override void StartPosition(int x, int y)
        {
            Start = new Point(x, y);
        }

        public override void UpdatePosition(int x, int y)
        {
            _end.X = x;
            _end.Y = y;
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
            return diffX < width && diffY < height;
        }
    }
}

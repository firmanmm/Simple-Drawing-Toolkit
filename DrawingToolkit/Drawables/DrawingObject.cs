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
        public abstract void StartPosition(int x, int y);
        public abstract void UpdatePosition(int x, int y);
        public abstract void Draw(Graphics graphics, Pen pen);
    }
}

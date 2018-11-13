using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DrawingToolkit
{
    public abstract class DrawingState
    {
        public abstract void StateDraw(DrawingObject drawing, Graphics graphics, Pen pen);
        public virtual void StateMouseUpdate(DrawingObject drawing,Point transIndex, int deltaX, int deltaY) {
            return;
        }
    }
}

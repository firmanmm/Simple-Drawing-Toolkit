using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DrawingToolkit
{
    public interface IDrawingState
    {
        void StateDraw(DrawingObject drawing, Graphics graphics, Pen pen);   
    }
}

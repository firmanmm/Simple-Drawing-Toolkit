using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingToolkit
{
    [Flags]
    public enum PropertyModifier
    {
        NoModification = 0,
        BorderColorable = 1,
        BackgroundColorable = 2,
        SizeAdjustable = 4,
        PositionAdjustable = 8,
    }
}

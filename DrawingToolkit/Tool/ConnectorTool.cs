using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingToolkit
{
    public class ConnectorTool : DrawingTool
    {
        private DrawingObject initObject;

        public ConnectorTool(DrawingCanvas canvas) : base(canvas)
        {

        }

        public override void MouseInit(int x, int y)
        {
            initObject = drawingCanvas.GetLastIntersection(x, y);
            
            if (initObject == null) {
                return;
            }

            drawingObject = new Connector();
            base.MouseInit(x, y);
        }

        public override void MouseUpdate(int x, int y)
        {
            base.MouseUpdate(x, y);
        }

        public override void MouseEnd(int x, int y)
        {
            DrawingObject lastObject = drawingCanvas.GetLastIntersection(x, y);
            if (lastObject == null) {
                if (drawingObject != null) {
                    drawingCanvas.RemoveDrawable(drawingObject.Id);
                }
            } else {
                ((Connector)drawingObject)?.SetHeadAndTail(initObject, lastObject);
            }
            base.MouseEnd(x, y);
        }
    }
}

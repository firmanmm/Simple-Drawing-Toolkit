using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace DrawingToolkit
{
    public class Connector : Line
    {

        private DrawingObject head;
        private DrawingObject tail;

        public void SetHeadAndTail(DrawingObject head, DrawingObject tail) {
            this.head = head;
            this.tail = tail;
            head.OnUpdate += Update;
            tail.OnUpdate += Update;
            Update();
        }

        public override void DrawGraphic(Graphics graphics, Pen pen)
        {
            graphics.DrawLine(pen, _start, _end);
        }

        public override bool IsIntersect(int x, int y)
        {
            return false;
        }

        private void Update() {
            if(head == null || tail == null) {
                return;
            }
            _start = head.Start;
            _end = tail.Start;
        }
    }

}

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

        public Connector() {
            name = "Connector";
            Modifier = PropertyModifier.NoModification;
        }

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

        public override List<string> ToTokenString()
        {
            return new List<string>(base.ToTokenString()) {
                "H",
                head.Id.ToString(), //20
                "T",
                tail.Id.ToString(), //22
            };
        }

        public static new DrawingObject FromTokenString(Dictionary<int, DrawingObject> drawingPool, string[] token)
        {
            Connector current = new Connector();
            SetBaseProperties(current, token);
            DrawingObject head = drawingPool[int.Parse(token[20])];
            DrawingObject tail = drawingPool[int.Parse(token[22])];
            current.SetHeadAndTail(head, tail);
            return current;

        }
    }

}

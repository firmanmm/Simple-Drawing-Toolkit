using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingToolkit
{
    public class CompositeShape : SimpleShape
    {
        private LinkedList<DrawingObject> childs;

        public override int ChildCount {
            get { return childs.Count; }
        }

        public CompositeShape(IEnumerable<DrawingObject> objects) {
            name = "Composite";
            Modifier = PropertyModifier.PositionAdjustable;
            childs = new LinkedList<DrawingObject>();
            foreach (DrawingObject obj in objects) {
                AddChild(obj);
            }
            _start.X = _start.Y = int.MaxValue;
            _end.X = _end.Y = int.MinValue;
            
            UpdateDerived();
        }

        public override void DrawGraphic(Graphics graphics, Pen pen)
        {
            Color defaultColor = pen.Color;
            foreach (DrawingObject child in childs) {
                pen.Color = child.BorderColor;
                child.Draw(graphics, pen);
            }

            pen.Color = defaultColor;
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            graphics.DrawRectangle(pen, _start.X - Width, _start.Y - Height, Width * 2, Height * 2);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
        }

        public override LinkedListNode<DrawingObject> AddChild(DrawingObject child)
        {
            LinkedListNode<DrawingObject> node = childs.AddLast(child);
            child.SetParent(this,node);
            UpdateDerived();
            return node;
        }

        public override void Translate(int x, int y)
        {
            base.Translate(x, y);
            foreach (DrawingObject child in childs) {
                child.Translate(x, y);
            }
        }

        public override void RemoveChild(LinkedListNode<DrawingObject> node)
        {
            childs.Remove(node);
            UpdateDerived();
        }

        public override DrawingObject[] DisAssemble() {
            DrawingObject[] drawable = childs.ToArray();
            foreach (DrawingObject child in drawable) {
                 child.Detach();
            }
            return drawable;
        }

        public override void StartPosition(int x, int y)
        {
            //SPIN
        }

        public override void UpdatePosition(int x, int y)
        {
            //SPIN
        }

        protected override void UpdateResizePoint()
        {
            //SPIN
        }

        public override IEnumerable<DrawingObject> GetChilds()
        {
            return childs;
        }

        protected override void UpdateDerived()
        {
            foreach (DrawingObject child in childs) {
                int[] border = child.GetBorder();
                _start.X = (border[0] < _start.X) ? border[0] : _start.X;
                _start.Y = (border[1] < _start.Y) ? border[1] : _start.Y;
                _end.X = (border[2] > _end.X) ? border[2] : _end.X;
                _end.Y = (border[3] > _end.Y) ? border[3] : _end.Y;
            }
            base.UpdateDerived();
            _start.X = _end.X - Width / 2;
            _start.Y = _end.Y - Height / 2;
            base.UpdateDerived();
        }
        ~CompositeShape(){
            foreach (DrawingObject child in childs) {
                child.SetParent(null,null);
            }
        }

        public override List<string> ToTokenString()
        {
            List<string> tokens = new List<string>(base.ToTokenString()) {
                "C" // 19
            };
            foreach (DrawingObject child in childs) {
                tokens.Add(child.Id.ToString());
            }
            return tokens;
        }

        public static DrawingObject FromTokenString(Dictionary<int, DrawingObject> drawingPool, string[] token)
        {
            List<DrawingObject> compositeObjects = new List<DrawingObject>();
            for (int i = 20; i < token.Length; i++) {
                int id = int.Parse(token[i]);
                compositeObjects.Add(drawingPool[id]);
                drawingPool.Remove(id);
            }

            CompositeShape composite = new CompositeShape(compositeObjects);
            SetBaseProperties(composite, token);
            composite.UpdateDerived();
            return composite;

        }
    }

    
}

using System;
using System.Collections.Generic;
using System.Drawing;

namespace DrawingToolkit
{
    public abstract class DrawingObject
    {
        private readonly DrawingContext State;

        //Observeable
        public Action OnUpdate { get; set; }
        

        private DrawingObject parent;
        private LinkedListNode<DrawingObject> node;
        
        protected Point _start;
        protected Point _end;
        protected int errorTolerance = 3;
        protected List<ResizePoint> resizePoints;

        public DrawingObject() {
            State = new DrawingContext(this);
            resizePoints = new List<ResizePoint>();
        }

        public virtual int ChildCount {
            get { return 0; }
        }

        public Point Start
        {
            get { return _start; }
            set {
                if ((_start = value) == null) {
                    _start = new Point(0, 0);
                }
            }
        }

        public Point End
        {
            get { return _end; }
            set {
                if ((_end = value) == null) {
                    _end = new Point(0, 0);
                }
            }
        }

        public abstract void StartPosition(int x, int y);
        public abstract void UpdatePosition(int x, int y);

        public virtual Point GetTransResizeIndex(int x, int y) {
            foreach (ResizePoint point in resizePoints) {
                if (point.IsIntersect(x, y)) {
                    return point.Multiplier;
                }
            }
            return new Point(-7, 7);
        }
        public abstract void DrawGraphic(Graphics graphics, Pen pen);
        protected abstract void UpdateResizePoint();

        public virtual void ResizeByTranslate(Point pos, int x, int y)
        {
            UpdateResizePoint();
            OnUpdate?.Invoke();
        }

        public void DrawResizePoint(Graphics graphics, Pen pen) {
            foreach (ResizePoint point in resizePoints) {
                point.DrawGraphic(graphics, pen);
            }
        }



        public virtual void Draw(Graphics graphics, Pen pen) {
            State.Draw(graphics, pen);
        }

        public virtual void Translate(int x, int y) {
            _start.X += x;
            _start.Y += y;
            _end.X += x;
            _end.Y += y;
            UpdateResizePoint();
            OnUpdate?.Invoke();
        }

        public virtual bool IsIntersect(int x, int y) {
            Point first = _start;
            Point second = _end;
            if (first.X > second.X) {
                Point temp = first;
                first = second;
                second = temp;
            }
            if (x < first.X || x > second.X) {
                return false;
            }
            if (first.Y > second.Y) {
                Point temp = first;
                first = second;
                second = temp;
            }
            if(y < first.Y || y > second.Y) {
                return false;
            }

            return true;

        }

        public void SetState(DrawingState state) {
            State.SetState(state);
        }

        public virtual LinkedListNode<DrawingObject> AddChild(DrawingObject child) {
            return null;
        }

        public virtual void RemoveChild(LinkedListNode<DrawingObject> node) {
            return;
        }

        public virtual void Detach() {
            if (parent != null) {
                parent.RemoveChild(node);
                parent = null;
            }
        }

        public virtual DrawingObject[] DisAssemble() {
            return null;
        }


        public void SetParent(DrawingObject parent,LinkedListNode<DrawingObject> node) {
            this.parent = parent;
            this.node = node;
        }

        public virtual int[] GetBorder() {
            return new int[] {_start.X,_start.Y,_end.X,_end.Y};
        }

        public void OnMouseUpdate(Point transResizeIndex, int deltaX, int deltaY) {
            State.MouseUpdate(this, transResizeIndex, deltaX, deltaY);
        }

        public static DrawingObject MakeComposite(DrawingCanvas canvas, DrawingObject[] drawables) {
            if (drawables.Length < 2) {
                return drawables[0];
            }
            CompositeShape composite = new CompositeShape(drawables);
            return composite;
        }
    }
}

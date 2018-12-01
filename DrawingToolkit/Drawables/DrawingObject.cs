using System;
using System.Collections.Generic;
using System.Drawing;

namespace DrawingToolkit
{
    public abstract class DrawingObject
    {
        protected string name;

        public int Id { get; set; }

        protected Color _borderColor;
        protected Color _backgroundColor;

        public PropertyModifier Modifier { get; set; }

        public virtual Color BorderColor {
            get { return _borderColor; }
            set { _borderColor = (Modifier.HasFlag(PropertyModifier.BorderColorable)) ? value : _borderColor; }
        }
        public virtual Color BackgroundColor {
            get { return _backgroundColor; }
            set { _backgroundColor = (Modifier.HasFlag(PropertyModifier.BackgroundColorable)) ? value : _backgroundColor; }
        }

        protected readonly DrawingContext State;

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
            name = "DrawingObject";
            _borderColor = Color.Black;
            _backgroundColor = Color.White;
            Modifier = PropertyModifier.PositionAdjustable;
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
            pen.Color = BorderColor;
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

        public virtual IEnumerable<DrawingObject> GetChilds() {
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

        public void SetID(int id) {
            if (this.Id == 0) {
                this.Id = id;
            } else {
                throw new FieldAccessException("Id can only be set once for lifetime!");
            }
        }

        public static void SetBaseProperties(DrawingObject drawing, string[] token) {
            drawing.SetID(int.Parse(token[2]));
            drawing.BorderColor = Color.FromArgb(int.Parse(token[6]), int.Parse(token[7]), int.Parse(token[8]));
            drawing.BackgroundColor = Color.FromArgb(int.Parse(token[10]), int.Parse(token[11]), int.Parse(token[12]));
            drawing.Start = new Point(int.Parse(token[14]), int.Parse(token[15]));
            drawing.End = new Point(int.Parse(token[17]), int.Parse(token[18]));
        }

        public virtual List<string> ToTokenString() {
            return new List<string>() {
                name,
                "ID",
                Id.ToString(), //2
                "PID", 
                (parent == null) ? "0" : parent.Id.ToString(), //4
                "BR_RGB",
                BorderColor.R.ToString(), //6
                BorderColor.G.ToString(), //7
                BorderColor.B.ToString(), //8
                "BG_RGB-",
                BackgroundColor.R.ToString(), //10
                BackgroundColor.G.ToString(), //11
                BackgroundColor.B.ToString(), //12
                "STR",
                _start.X.ToString(), //14
                _start.Y.ToString(), //15
                "END",
                _end.X.ToString(), //17
                _end.Y.ToString(), //18
            };
        }
    }
}

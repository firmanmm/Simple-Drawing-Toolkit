using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace DrawingToolkit
{
    /// <summary>
    /// Provides drawing capabilities
    /// </summary>
    public class DrawingCanvas : Control
    {
        public Tool ActiveTool { get; set;}

        private LinkedList<DrawingObject> drawables;
        private Pen pen;

        public DrawingCanvas() {
            SetStyle(ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            drawables = new LinkedList<DrawingObject>();
            pen = new Pen(Color.Black);
            MouseDown += DrawingCanvas_MouseDown;
            MouseMove += DrawingCanvas_MouseMove;
            MouseUp += DrawingCanvas_MouseUp;
        }

        private void DrawingCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (ActiveTool != null) {
                ActiveTool.MouseUpdate(e.X, e.Y);
                Invalidate();
                ActiveTool.IsActive = false;
            }
            ActiveTool = null;
        }

        private void DrawingCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (ActiveTool != null) {
                ActiveTool.MouseInit(e.X, e.Y);
                drawables.AddLast(ActiveTool.GetDrawable());
            }
        }


        private void DrawingCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (ActiveTool != null) {
                ActiveTool.MouseUpdate(e.X, e.Y);
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            foreach (DrawingObject drawable in drawables) {
                drawable.Draw(e.Graphics, pen);
            }
        }

        public void Clear() {
            drawables.Clear();
            Invalidate();
        }
    }
}

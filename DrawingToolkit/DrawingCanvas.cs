using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using DrawingToolkit.Controller;

namespace DrawingToolkit
{
    /// <summary>
    /// Provides drawing capabilities
    /// </summary>
    public class DrawingCanvas : Control
    {
        public Tool ActiveTool { get; private set;}
        public readonly UndoRedoManager undoRedoController;

        private readonly Pen pen;
        private readonly FileManager fileManager;

        private int idTracker = 1;

        private readonly LinkedList<DrawingObject> drawables;
        private readonly Dictionary<int, LinkedListNode<DrawingObject>> drawableMapper;

        public DrawingCanvas() {

            fileManager = new FileManager();
            undoRedoController = new UndoRedoManager(this);

            SetStyle(ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            drawables = new LinkedList<DrawingObject>();
            drawableMapper = new Dictionary<int, LinkedListNode<DrawingObject>>();
            pen = new Pen(Color.Black);
            MouseDown += DrawingCanvas_MouseDown;
            MouseMove += DrawingCanvas_MouseMove;
            MouseUp += DrawingCanvas_MouseUp;
        }

        

        private void DrawingCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (ActiveTool != null) {
                ActiveTool.MouseEnd(e.X, e.Y);
                Invalidate();
            }
        }

        private void DrawingCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (ActiveTool != null) {
                ActiveTool.MouseInit(e.X, e.Y);
            }
        }

        private void DrawingCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (ActiveTool != null) {
                ActiveTool.MouseUpdate(e.X, e.Y);
                Invalidate();
            }
        }

        public int AddDrawable(DrawingObject drawable) {
            if (drawable.Id == 0) {
                drawable.Id = idTracker;
                drawableMapper.Add(idTracker++, drawables.AddLast(drawable));
            } else {
                idTracker = (drawable.Id >= idTracker) ? drawable.Id + 1 : idTracker;
                drawableMapper.Add(drawable.Id, drawables.AddLast(drawable));
            }
            return drawable.Id;

        }

        public void RemoveDrawable(int id) {
            LinkedListNode<DrawingObject> data;
            if (drawableMapper.TryGetValue(id, out data)) {
                drawables.Remove(data);
                drawableMapper.Remove(id);
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
            undoRedoController.ClearProcesses();
            drawables.Clear();
            drawableMapper.Clear();
            Invalidate();
        }

        public DrawingObject GetLastIntersection(int x,int y)
        {
            LinkedListNode<DrawingObject> iter = drawables.Last;
            while (iter != null) {
                if (iter.Value.IsIntersect(x, y)) {
                    return iter.Value;
                }
                iter = iter.Previous;
            }
            return null;
        }

        public DrawingObject DeleteLastIntersection(int x, int y) {
            LinkedListNode<DrawingObject> iter = drawables.Last;
            while (iter != null) {
                if (iter.Value.IsIntersect(x, y)) {
                    iter.Value.Detach();
                    DrawingObject drawable = iter.Value;
                    drawables.Remove(iter);
                    return drawable;
                }
                iter = iter.Previous;
            }
            return null;
        }

        public void SetActiveTool(Tool activeTool) {
            if (ActiveTool != null) {
                ActiveTool.IsActive = false;
            }
            ActiveTool = activeTool;
        }

        public void SaveDrawingData() {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Save to File";
            saveFileDialog.InitialDirectory = fileManager.CurrentPath;
            saveFileDialog.AddExtension = true;
            saveFileDialog.Filter = "RenSimpleDrawingToolkit (*.rsdt) | *.rsdt";
            DialogResult result = saveFileDialog.ShowDialog();
            if (result == DialogResult.OK) {
                fileManager.Save(drawables, saveFileDialog.FileName);
            }

        }

        public void LoadDrawingData() {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Open File";
            openFileDialog.InitialDirectory = fileManager.CurrentPath;
            openFileDialog.AddExtension = true;
            openFileDialog.Filter = "RenSimpleDrawingToolkit (*.rsdt) | *.rsdt";
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK) {
                Clear();
                try {
                    IEnumerable<DrawingObject> drawings = fileManager.Load(openFileDialog.FileName);
                    foreach (DrawingObject drawing in drawings) {
                        AddDrawable(drawing);
                        SetIDTracker(drawing.Id + 1);
                    }
                } catch(Exception e) {
                    MessageBox.Show(e.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Invalidate();
            }
            
        }

        public int SetIDTracker(int id) {
            if (idTracker < id) {
                idTracker = id;
            }
            return idTracker;
        }
    }

}

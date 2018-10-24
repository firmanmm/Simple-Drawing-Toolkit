using System.Windows.Forms;

namespace DrawingToolkit
{
    public partial class DrawingFrame : Frame
    {
        private LineTool lineTool;
        private CircleTool circleTool;
        private RectangleTool rectangleTool;
        private ClearTool clearTool;
        private PointerTool pointerTool;
        private MinusTool minusTool;
        private ToolStrip toolbar;
        
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        
        private DrawingCanvas drawingCanvas;

        #region Windows Form Designer generated code

        protected override void InitializeComponent()
        {
            this.drawingCanvas = new DrawingCanvas();
            this.lineTool = new LineTool(drawingCanvas);
            this.circleTool = new CircleTool(drawingCanvas);
            this.rectangleTool = new RectangleTool(drawingCanvas);
            this.clearTool = new ClearTool(drawingCanvas);
            this.pointerTool = new PointerTool(drawingCanvas);
            this.minusTool = new MinusTool(drawingCanvas);

            this.toolbar = new System.Windows.Forms.ToolStrip();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.toolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // drawingCanvas
            // 
            this.drawingCanvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drawingCanvas.Location = new System.Drawing.Point(0, 25);
            this.drawingCanvas.Name = "drawingCanvas";
            this.drawingCanvas.Size = new System.Drawing.Size(800, 425);
            this.drawingCanvas.TabIndex = 1;
            // 
            // lineTool
            // 
            this.lineTool.BackColor = System.Drawing.Color.Gainsboro;
            this.lineTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.lineTool.Image = global::DrawingToolkit.Properties.Resources.line;
            this.lineTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.lineTool.IsActive = false;
            this.lineTool.Name = "lineTool";
            this.lineTool.Size = new System.Drawing.Size(23, 22);
            this.lineTool.Text = "Draw Line";
            // 
            // circleTool
            // 
            this.circleTool.BackColor = System.Drawing.Color.Gainsboro;
            this.circleTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.circleTool.Image = global::DrawingToolkit.Properties.Resources.circle;
            this.circleTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.circleTool.IsActive = false;
            this.circleTool.Name = "circleTool";
            this.circleTool.Size = new System.Drawing.Size(23, 22);
            this.circleTool.Text = "Draw Circle";
            // 
            // rectangleTool
            // 
            this.rectangleTool.BackColor = System.Drawing.Color.Gainsboro;
            this.rectangleTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.rectangleTool.Image = global::DrawingToolkit.Properties.Resources.rectangle;
            this.rectangleTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.rectangleTool.IsActive = false;
            this.rectangleTool.Name = "rectangleTool";
            this.rectangleTool.Size = new System.Drawing.Size(23, 22);
            this.rectangleTool.Text = "Draw Rectangle";
            // 
            // clearTool
            // 
            this.clearTool.BackColor = System.Drawing.Color.Gainsboro;
            this.clearTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.clearTool.Image = global::DrawingToolkit.Properties.Resources.clear;
            this.clearTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.clearTool.IsActive = false;
            this.clearTool.Name = "clearTool";
            this.clearTool.Size = new System.Drawing.Size(23, 22);
            this.clearTool.Text = "Clear All Drawing";
            // 
            // pointerTool
            // 
            this.pointerTool.BackColor = System.Drawing.Color.Gainsboro;
            this.pointerTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pointerTool.Image = global::DrawingToolkit.Properties.Resources.pointer;
            this.pointerTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pointerTool.IsActive = false;
            this.pointerTool.Name = "pointerTool";
            this.pointerTool.Size = new System.Drawing.Size(23, 22);
            this.pointerTool.Text = "Select And Move Drawing";
            // 
            // toolbar
            // 
            this.toolbar.BackColor = System.Drawing.Color.Gainsboro;
            this.toolbar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pointerTool,
            this.lineTool,
            this.circleTool,
            this.rectangleTool,
            this.minusTool,
            this.clearTool});
            this.toolbar.Location = new System.Drawing.Point(0, 0);
            this.toolbar.Name = "toolbar";
            this.toolbar.Size = new System.Drawing.Size(800, 25);
            this.toolbar.Stretch = true;
            this.toolbar.TabIndex = 0;
            this.toolbar.Text = "Toolbar";
            // 
            // minusTool
            // 
            this.minusTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.minusTool.Image = global::DrawingToolkit.Properties.Resources.minus;
            this.minusTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.minusTool.Name = "minusTool";
            this.minusTool.Size = new System.Drawing.Size(23, 22);
            this.minusTool.Text = "Delete Single Object";
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // DrawingFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.drawingCanvas);
            this.Controls.Add(this.toolbar);
            this.Name = "DrawingFrame";
            this.Text = "Simple Drawing Toolkit";
            this.toolbar.ResumeLayout(false);
            this.toolbar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

    }
}

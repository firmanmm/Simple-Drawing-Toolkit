using System.Windows.Forms;

namespace DrawingToolkit
{
    public partial class DrawingFrame : Frame
    {
        private Tool lineTool;
        private Tool circleTool;
        private Tool rectangleTool;
        private Tool clearTool;

        private ToolStrip toolbar;
        private DrawingCanvas drawingCanvas;


        #region Windows Form Designer generated code

        protected override void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DrawingFrame));
            this.toolbar = new System.Windows.Forms.ToolStrip();
            this.drawingCanvas = new DrawingCanvas();
            this.lineTool = new LineTool(drawingCanvas);
            this.circleTool = new CircleTool(drawingCanvas);
            this.rectangleTool = new RectangleTool(drawingCanvas);
            this.clearTool = new ClearTool(drawingCanvas);
            
            this.toolbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolbar
            // 
            this.toolbar.BackColor = System.Drawing.Color.Gainsboro;
            this.toolbar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lineTool,
            this.circleTool,
            this.rectangleTool,
            this.clearTool});
            this.toolbar.Location = new System.Drawing.Point(0, 0);
            this.toolbar.Name = "toolbar";
            this.toolbar.Size = new System.Drawing.Size(800, 25);
            this.toolbar.Stretch = true;
            this.toolbar.TabIndex = 0;
            this.toolbar.Text = "Toolbar";
            // 
            // lineTool
            // 
            this.lineTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.lineTool.Image = ((System.Drawing.Image)(resources.GetObject("lineTool.Image")));
            this.lineTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.lineTool.Name = "lineTool";
            this.lineTool.Size = new System.Drawing.Size(23, 22);
            this.lineTool.Text = "Draw Line";
            // 
            // circleTool
            // 
            this.circleTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.circleTool.Image = ((System.Drawing.Image)(resources.GetObject("circleTool.Image")));
            this.circleTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.circleTool.Name = "circleTool";
            this.circleTool.Size = new System.Drawing.Size(23, 22);
            this.circleTool.Text = "Draw Circle";
            // 
            // rectangleTool
            // 
            this.rectangleTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.rectangleTool.Image = ((System.Drawing.Image)(resources.GetObject("rectangleTool.Image")));
            this.rectangleTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.rectangleTool.Name = "rectangleTool";
            this.rectangleTool.Size = new System.Drawing.Size(23, 22);
            this.rectangleTool.Text = "Draw Rectangle";
            // 
            // clearTool
            // 
            this.clearTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.clearTool.Image = ((System.Drawing.Image)(resources.GetObject("clearTool.Image")));
            this.clearTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.clearTool.Name = "clearTool";
            this.clearTool.Size = new System.Drawing.Size(23, 22);
            this.clearTool.Text = "Clear All Drawing";
            // 
            // drawingCanvas
            // 
            this.drawingCanvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drawingCanvas.Location = new System.Drawing.Point(0, 25);
            this.drawingCanvas.Name = "drawingCanvas";
            this.drawingCanvas.Size = new System.Drawing.Size(800, 425);
            this.drawingCanvas.TabIndex = 1;
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

    }
}

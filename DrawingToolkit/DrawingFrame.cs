﻿using System.Windows.Forms;
using DrawingToolkit.Controller;
using System.Drawing;
using System;

namespace DrawingToolkit
{
    public partial class DrawingFrame : Frame
    {
        private Tool lineTool;
        private Tool circleTool;
        private Tool rectangleTool;
        private Tool clearTool;
        private Tool pointerTool;
        private Tool minusTool;
        private ToolStrip toolbar;
        private Tool compositeTool;
        private Tool connectorTool;
        private Tool undoTool;
        private Tool redoTool;
        private Tool saveBtn;
        private Tool loadBtn;
        private PropertiesPanel propertiesPanel;

        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        
        private DrawingCanvas drawingCanvas;

        private void InitCustomTool()
        {
            this.drawingCanvas = new DrawingCanvas();
            this.propertiesPanel = new PropertiesPanel(drawingCanvas);
            this.lineTool = new LineTool(drawingCanvas);
            this.circleTool = new CircleTool(drawingCanvas);
            this.rectangleTool = new RectangleTool(drawingCanvas);
            this.clearTool = new ClearTool(drawingCanvas);
            this.pointerTool = new PointerTool(drawingCanvas, propertiesPanel);
            this.minusTool = new MinusTool(drawingCanvas);
            this.compositeTool = new CompositeTool(drawingCanvas, (PointerTool)pointerTool);
            this.connectorTool = new ConnectorTool(drawingCanvas);
            this.undoTool = new UndoTool(drawingCanvas);
            this.redoTool = new RedoTool(drawingCanvas);
            this.saveBtn = new SaveTool(drawingCanvas);
            this.loadBtn = new LoadTool(drawingCanvas);

            this.toolbar = new System.Windows.Forms.ToolStrip();
            PopulateFactory();
            InitPropertiesPanel();
        }

        private void InitPropertiesPanel() {
            this.propertiesPanel.Location = new Point(400, 430);
            this.propertiesPanel.Size = new Size(400, 20);
            this.propertiesPanel.BackColor = Color.White;
            this.propertiesPanel.BorderStyle = BorderStyle.FixedSingle;
            this.propertiesPanel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            this.Controls.Add(this.propertiesPanel);
        }

        private void PopulateFactory() {
            DrawableFactory.AddStrategy("Line", Line.FromTokenString);
            DrawableFactory.AddStrategy("Circle", Circle.FromTokenString);
            DrawableFactory.AddStrategy("Rectangle", Rectangle.FromTokenString);
            DrawableFactory.AddStrategy("Composite", CompositeShape.FromTokenString);
            DrawableFactory.AddStrategy("Connector", Connector.FromTokenString);
        }

        #region Windows Form Designer generated code

        protected override void InitializeComponent()
        {
            PopulateFactory();
            this.drawingCanvas = new DrawingCanvas();
            this.propertiesPanel = new PropertiesPanel(drawingCanvas);
            this.lineTool = new LineTool(drawingCanvas);
            this.circleTool = new CircleTool(drawingCanvas);
            this.rectangleTool = new RectangleTool(drawingCanvas);
            this.clearTool = new ClearTool(drawingCanvas);
            this.pointerTool = new PointerTool(drawingCanvas, propertiesPanel);
            this.minusTool = new MinusTool(drawingCanvas);
            this.compositeTool = new CompositeTool(drawingCanvas, (PointerTool)pointerTool);
            this.connectorTool = new ConnectorTool(drawingCanvas);
            this.undoTool = new UndoTool(drawingCanvas);
            this.redoTool = new RedoTool(drawingCanvas);
            this.saveBtn = new SaveTool(drawingCanvas);
            this.loadBtn = new LoadTool(drawingCanvas);

            this.toolbar = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
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
            // minusTool
            // 
            this.minusTool.BackColor = System.Drawing.Color.Gainsboro;
            this.minusTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.minusTool.Image = global::DrawingToolkit.Properties.Resources.minus;
            this.minusTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.minusTool.IsActive = false;
            this.minusTool.Name = "minusTool";
            this.minusTool.Size = new System.Drawing.Size(23, 22);
            this.minusTool.Text = "Delete Single Object";
            // 
            // compositeTool
            // 
            this.compositeTool.BackColor = System.Drawing.Color.Gainsboro;
            this.compositeTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.compositeTool.Image = global::DrawingToolkit.Properties.Resources.combine;
            this.compositeTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.compositeTool.IsActive = false;
            this.compositeTool.Name = "compositeTool";
            this.compositeTool.Size = new System.Drawing.Size(23, 22);
            this.compositeTool.Text = "Combine/Uncombine";
            // 
            // connectorTool
            // 
            this.connectorTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.connectorTool.Image = global::DrawingToolkit.Properties.Resources.connector;
            this.connectorTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.connectorTool.IsActive = false;
            this.connectorTool.Name = "connectorTool";
            this.connectorTool.Size = new System.Drawing.Size(23, 22);
            this.connectorTool.Text = "Connector Tool";
            // 
            // saveBtn
            // 
            this.saveBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveBtn.Image = global::DrawingToolkit.Properties.Resources.save;
            this.saveBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(23, 22);
            this.saveBtn.Text = "Save";
            // 
            // loadBtn
            // 
            this.loadBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.loadBtn.Image = global::DrawingToolkit.Properties.Resources.load;
            this.loadBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.loadBtn.Name = "loadBtn";
            this.loadBtn.Size = new System.Drawing.Size(23, 22);
            this.loadBtn.Text = "toolStripButton1";
            this.loadBtn.ToolTipText = "Load";
            // 
            // toolbar
            // 
            this.toolbar.BackColor = System.Drawing.Color.Gainsboro;
            this.toolbar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveBtn,
            this.loadBtn,
            this.undoTool,
            this.redoTool,
            this.toolStripSeparator1,
            this.pointerTool,
            this.lineTool,
            this.circleTool,
            this.rectangleTool,
            this.minusTool,
            this.clearTool,
            this.connectorTool,
            this.toolStripSeparator2,
            this.compositeTool});
            this.toolbar.Location = new System.Drawing.Point(0, 0);
            this.toolbar.Name = "toolbar";
            this.toolbar.Size = new System.Drawing.Size(800, 25);
            this.toolbar.Stretch = true;
            this.toolbar.TabIndex = 0;
            this.toolbar.Text = "Toolbar";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // undoBtn
            // 
            this.undoTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.undoTool.Image = global::DrawingToolkit.Properties.Resources.undo;
            this.undoTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.undoTool.Name = "undoBtn";
            this.undoTool.Size = new System.Drawing.Size(23, 22);
            this.undoTool.Text = "Undo";
            // 
            // redoBtn
            // 
            this.redoTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.redoTool.Image = global::DrawingToolkit.Properties.Resources.redo;
            this.redoTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.redoTool.Name = "redoBtn";
            this.redoTool.Size = new System.Drawing.Size(23, 22);
            this.redoTool.Text = "toolStripButton2";
            this.redoTool.ToolTipText = "Redo";
            // 
            // DrawingFrame
            // 
            this.propertiesPanel.Location = new Point(400, 430);
            this.propertiesPanel.Size = new Size(400, 20);
            this.propertiesPanel.BackColor = Color.White;
            this.propertiesPanel.BorderStyle = BorderStyle.FixedSingle;
            this.propertiesPanel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            this.Controls.Add(this.propertiesPanel);

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

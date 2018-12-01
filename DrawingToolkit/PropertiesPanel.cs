using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace DrawingToolkit{

    public class PropertiesPanel : Panel {

        private TextBox xPositionBox;
        private TextBox yPositionBox;
        private TextBox wSizeBox;
        private TextBox hSizeBox;

        Button bgColorBtn;
        Button brColorBtn;

        private TextBox dummyBox;

        public DrawingObject Drawable { get; protected set; }

        private DrawingCanvas canvas;

        public PropertiesPanel(DrawingCanvas canvas) {
            this.canvas = canvas;
            Size labelSize = new Size(30, 15);
            Size textBoxSize = new Size(50, 15);

            dummyBox = new TextBox();
            dummyBox.Size = new Size();
            this.Controls.Add(dummyBox);

            //Position Begin
            Label posLabelX = new Label();
            posLabelX.Location = new Point(0, 2);
            posLabelX.TextAlign = ContentAlignment.MiddleCenter;
            posLabelX.Text = "X";
            posLabelX.Size = labelSize;
            this.Controls.Add(posLabelX);

            xPositionBox = new TextBox();
            xPositionBox.Location = new Point(30, 0);
            xPositionBox.Size = textBoxSize;
            xPositionBox.KeyUp += UpdateDrawable;
            this.Controls.Add(xPositionBox);

            Label posLabelY = new Label();
            posLabelY.Location = new Point(80, 2);
            posLabelY.TextAlign = ContentAlignment.MiddleCenter;
            posLabelY.Text = "Y";
            posLabelY.Size = labelSize;
            this.Controls.Add(posLabelY);

            yPositionBox = new TextBox();
            yPositionBox.Location = new Point(110, 0);
            yPositionBox.Size = textBoxSize;
            yPositionBox.KeyUp += UpdateDrawable;
            this.Controls.Add(yPositionBox);

            //Size Begin
            Label sizeLabelX = new Label();
            sizeLabelX.Location = new Point(160, 2);
            sizeLabelX.TextAlign = ContentAlignment.MiddleCenter;
            sizeLabelX.Text = "W";
            sizeLabelX.Size = labelSize;
            this.Controls.Add(sizeLabelX);

            wSizeBox = new TextBox();
            wSizeBox.Location = new Point(190, 0);
            wSizeBox.Size = textBoxSize;
            wSizeBox.KeyUp += UpdateDrawable;
            this.Controls.Add(wSizeBox);

            Label sizeLabelY = new Label();
            sizeLabelY.Location = new Point(240, 2);
            sizeLabelY.TextAlign = ContentAlignment.MiddleCenter;
            sizeLabelY.Text = "H";
            sizeLabelY.Size = labelSize;
            this.Controls.Add(sizeLabelY);

            hSizeBox = new TextBox();
            hSizeBox.Location = new Point(270, 0);
            hSizeBox.Size = textBoxSize;
            hSizeBox.KeyUp += UpdateDrawable;
            this.Controls.Add(hSizeBox);

            brColorBtn = new Button();
            brColorBtn.Location = new Point(320, 0);
            brColorBtn.Size = new Size(40, 20);
            brColorBtn.Text = "BR";
            brColorBtn.Click += SelectBorderColor;
            this.Controls.Add(brColorBtn);

            bgColorBtn = new Button();
            bgColorBtn.Location = new Point(360, 0);
            bgColorBtn.Size = new Size(40, 20);
            bgColorBtn.Text = "BG";
            bgColorBtn.Click += SelectBackgroundColor;
            this.Controls.Add(bgColorBtn);
        }

        public void SetDrawable(DrawingObject drawing) {
            this.Show();
            dummyBox.Focus();
            if (Drawable != null) {
                Drawable.OnUpdate -= UpdateDrawable;
            }
            Drawable = drawing;
            Drawable.OnUpdate += UpdateDrawable;
            brColorBtn.Visible = Drawable.Modifier.HasFlag(PropertyModifier.BorderColorable);
            brColorBtn.BackColor = Drawable.BorderColor;
            bgColorBtn.Visible = Drawable.Modifier.HasFlag(PropertyModifier.BackgroundColorable);
            bgColorBtn.BackColor = Drawable.BackgroundColor;
            wSizeBox.Visible = hSizeBox.Visible = Drawable.Modifier.HasFlag(PropertyModifier.SizeAdjustable);
            UpdateDrawable();
        }

        private void SelectBackgroundColor(object obj, EventArgs events) {
            ColorDialog colorDialog = new ColorDialog();
            DialogResult result = colorDialog.ShowDialog();
            if (result == DialogResult.OK) {
                Drawable.BackgroundColor = colorDialog.Color;
                bgColorBtn.BackColor = Drawable.BackgroundColor;
            }
        }

        private void SelectBorderColor(object obj, EventArgs events)
        {
            ColorDialog colorDialog = new ColorDialog();
            DialogResult result = colorDialog.ShowDialog();
            if (result == DialogResult.OK) {
                Drawable.BorderColor = colorDialog.Color;
                brColorBtn.BackColor = Drawable.BorderColor;
            }

        }

        private void UpdateDrawable(object obj, EventArgs evt) {
            int deltaX = 0;
            int deltaY = 0;
            bool match = false;
            if (int.TryParse(xPositionBox.Text, out deltaX)) {
                if (int.TryParse(yPositionBox.Text, out deltaY)) {
                    deltaX -= Drawable.Start.X;
                    deltaY -= Drawable.Start.Y;
                    if (deltaX != 0 || deltaY != 0) {
                        match = true;
                        Drawable.Translate(deltaX, deltaY);
                    }
                }
            }
            if (Drawable.Modifier.HasFlag(PropertyModifier.SizeAdjustable)) {
                SimpleShape current = (SimpleShape)Drawable;
                if (int.TryParse(wSizeBox.Text, out deltaX)) {
                    if (int.TryParse(hSizeBox.Text, out deltaY)) {
                        deltaX = Math.Abs(deltaX);
                        deltaY = Math.Abs(deltaY);
                        deltaX -= current.Width;
                        deltaY -= current.Height;
                        if (deltaX != 0 || deltaY != 0) {
                            match = true;
                            Drawable.ResizeByTranslate(new Point(1, 1), deltaX, deltaY);
                        }
                    }
                }
            }
            
            if (match) {
                canvas.Invalidate();
            } else {
                UpdateDrawable();
            }
        }

        private void UpdateDrawable() {
            xPositionBox.Text = Drawable.Start.X.ToString();
            yPositionBox.Text = Drawable.Start.Y.ToString();
            if (Drawable.Modifier.HasFlag(PropertyModifier.SizeAdjustable)) {
                SimpleShape current = (SimpleShape)Drawable;
                wSizeBox.Text = current.Width.ToString();
                hSizeBox.Text = current.Height.ToString();
            }
        }
    }
}

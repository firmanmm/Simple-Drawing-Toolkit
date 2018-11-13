using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingToolkit
{
    [Serializable]
    public class CompositeTool : Tool
    {
        private PointerTool pointerTool;

        public CompositeTool(DrawingCanvas canvas,PointerTool pointerTool) : base(canvas)
        {
            this.pointerTool = pointerTool;
            this.Visible = false;
            pointerTool.OnCompositeReady += () => {
                this.Visible = true;
            };
            pointerTool.OnCompositeNotReady += () => {
                this.Visible = false;
            };
        }

        protected override void Tool_MouseDown(object sender, MouseEventArgs e)
        {
            pointerTool.MakeComposite();
        }
    }
}

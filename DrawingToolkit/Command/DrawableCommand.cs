using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingToolkit.Command
{
    public abstract class DrawableCommand : ICommand
    {
        protected readonly DrawingObject drawingObject;
        protected readonly DrawingCanvas canvas;

        public DrawableCommand(DrawingCanvas canvas, DrawingObject drawing) {
            this.canvas = canvas;
            drawingObject = drawing;
        }

        public abstract void Execute();
        public abstract void Unexecute();
    }
}

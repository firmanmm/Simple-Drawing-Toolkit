using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrawingToolkit.Command;

namespace DrawingToolkit
{
    public class UndoRedoManager
    {
        private DrawingCanvas canvas;
        private Stack<ICommand> undoStack;
        private Stack<ICommand> redoStack;

        public UndoRedoManager(DrawingCanvas canvas) {
            this.canvas = canvas;
            undoStack = new Stack<ICommand>();
            redoStack = new Stack<ICommand>();
        }

        public void ClearProcesses() {
            undoStack.Clear();
            redoStack.Clear();
        }

        public void AddProcess(ICommand command) {
            command.Execute();
            undoStack.Push(command);
            redoStack.Clear();
        }

        public void UndoProcess() {
            if (undoStack.Count > 0) {
                ICommand command = undoStack.Pop();
                command.Unexecute();
                redoStack.Push(command);
            }
        }

        public void RedoProcess() {
            if (redoStack.Count > 0) {
                ICommand command = redoStack.Pop();
                command.Execute();
                undoStack.Push(command);
            }
        }


    }
}

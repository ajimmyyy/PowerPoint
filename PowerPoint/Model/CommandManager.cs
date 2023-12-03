using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    public class CommandManager
    {
        Stack<ICommand> _undo = new Stack<ICommand>();
        Stack<ICommand> _redo = new Stack<ICommand>();
        public void Execute(ICommand cmd)
        {
            cmd.Execute();
            _undo.Push(cmd);
            _redo.Clear();
        }

        public void Undo()
        {
            if (_undo.Count <= 0)
                throw new Exception("Cannot Undo exception\n");
            ICommand cmd = _undo.Pop();
            _redo.Push(cmd);
            cmd.UnExecute();
        }

        public void Redo()
        {
            if (_redo.Count <= 0)
                throw new Exception("Cannot Redo exception\n");
            ICommand cmd = _redo.Pop();
            _undo.Push(cmd);
            cmd.Execute();
        }

        public bool IsRedoEnabled
        {
            get
            {
                return _redo.Count != 0;
            }
        }

        public bool IsUndoEnabled
        {
            get
            {
                return _undo.Count != 0;
            }
        }
    }
}

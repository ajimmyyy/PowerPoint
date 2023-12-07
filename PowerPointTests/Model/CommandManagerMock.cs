using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    class CommandManagerMock : CommandManager
    {
        int _executeCount = 0;
        int _undoCount = 0;
        int _redoCount = 0;

        //執行命令
        public override void Execute(ICommand command)
        {
            _executeCount++;
        }

        //操作復原
        public override void Undo()
        {
            _undoCount++;
        }

        //操作重做
        public override void Redo()
        {
            _redoCount++;
        }

        public int ExecuteCount
        {
            get
            {
                return _executeCount;
            }
        }

        public int UndoCount
        {
            get
            {
                return _undoCount;
            }
        }

        public int RedoCount
        {
            get
            {
                return _redoCount;
            }
        }
    }
}

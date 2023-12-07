using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    public class CommandMock : ICommand
    {
        int _executeCount = 0;
        int _reverseExecuteCount = 0;

        //執行命令
        public void Execute()
        {
            _executeCount++;
        }

        //執行復原命令
        public void ReverseExecute()
        {
            _reverseExecuteCount++;
        }

        public int ExecuteCount
        {
            get
            {
                return _executeCount;
            }
        }

        public int ReverseExecuteCount
        {
            get
            {
                return _reverseExecuteCount;
            }
        }
    }
}

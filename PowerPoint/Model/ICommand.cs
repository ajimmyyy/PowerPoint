using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    public interface ICommand
    {
        //執行命令
        void Execute();

        //執行復原命令
        void ReverseExecute();
    }
}

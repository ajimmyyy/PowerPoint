using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    public class DeletePageCommand : ICommand
    {
        Shapes _page;
        Model _model;

        public DeletePageCommand(Model model, Shapes page)
        {
            _model = model;
            _page = page;
        }

        //執行命令
        public void Execute()
        {
            _model.DeletePage(_page);
        }

        //執行復原命令
        public void ReverseExecute()
        {
            _model.AddPage(_page);
        }
    }
}

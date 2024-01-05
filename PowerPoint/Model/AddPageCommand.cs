using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    public class AddPageCommand : ICommand
    {
        Shapes _page;
        Model _model;

        public AddPageCommand(Model model)
        {
            _model = model;
            _page = Factory.CreateShapes();
        }

        //執行命令
        public void Execute()
        {
            _model.AddPage(_page);
        }

        //執行復原命令
        public void ReverseExecute()
        {
            _model.DeletePage(_page);
        }
    }
}

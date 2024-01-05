using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    public class DeleteCommand : ICommand
    {
        Shape _shape;
        Shapes _page;
        Model _model;

        public DeleteCommand(Model model, Shape shape, Shapes page)
        {
            shape.SetSelect(false);
            _shape = shape;
            _page = page;
            _model = model;
        }

        //執行命令
        public void Execute()
        {
            _model.DeleteShape(_shape, _page);
        }

        //執行復原命令
        public void ReverseExecute()
        {
            _model.AddShape(_shape, _page);
        }
    }
}

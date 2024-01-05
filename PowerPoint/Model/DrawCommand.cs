using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    public class DrawCommand : ICommand
    {
        Shape _shape;
        Shapes _page;
        Model _model;
        
        public DrawCommand(Model model, Shape shape, Shapes page)
        {
            _shape = shape;
            _page = page;
            _model = model;
        }

        //執行命令
        public void Execute()
        {
            _model.AddShape(_shape, _page);
        }

        //執行復原命令
        public void ReverseExecute()
        {
            _model.DeleteShape(_shape, _page);
        }
    }
}

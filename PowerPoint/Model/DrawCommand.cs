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
        Model _model;
        
        public DrawCommand(Model model, Shape shape)
        {
            _shape = shape;
            _model = model;
        }

        //執行命令
        public void Execute()
        {
            _model.AddShape(_shape);
        }

        //執行復原命令
        public void ReverseExecute()
        {
            _model.DeleteShape(_shape);
        }
    }
}

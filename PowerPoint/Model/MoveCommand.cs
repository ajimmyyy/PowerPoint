using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    public class MoveCommand : ICommand
    {
        Shape _shape;
        Shapes _page;
        Model _model;
        Coordinate _lastRange = new Coordinate();
        Coordinate _originRange = new Coordinate();

        public MoveCommand(Model model, Shape shape, Coordinate range, Shapes page)
        {
            _shape = shape;
            _model = model;
            _lastRange = shape.GetPosition().Clone();
            _originRange = range;
            _page = page;
        }

        //執行命令
        public void Execute()
        {
            _model.MoveShape(_shape, _lastRange, _page);
        }

        //執行復原命令
        public void ReverseExecute()
        {
            _model.MoveShape(_shape, _originRange, _page);
        }
    }
}

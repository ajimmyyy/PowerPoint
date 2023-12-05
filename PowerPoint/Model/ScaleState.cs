using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    public class ScaleState : IState
    {
        Shape _selection;
        Coordinate _range;
        Model _model;
        double _firstPointX;
        double _firstPointY;

        public ScaleState(Shape selection, Model model)
        {
            _selection = selection;
            _model = model;
            _range = new Coordinate();
        }

        //滑鼠被按下
        public void MouseDown(double pointX, double pointY)
        {
            _firstPointX = _selection.GetPosition()._left;
            _firstPointY = _selection.GetPosition()._top;
            _range = _selection.GetPosition().Clone();
        }

        //滑鼠移動
        public void MouseMove(double pointX, double pointY)
        {
            if (_selection != null)
            {
                _selection.SetCoordinate(_firstPointX, _firstPointY, pointX, pointY);
            }
        }

        //滑鼠釋放
        public void MouseRelease()
        {
            if (_selection != null)
            {
                _model.LogCommand(new MoveCommand(_model, _selection, _range));
            }
        }
    }
}
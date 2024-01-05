using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    public class PointState : IState
    {
        Shape _selection;
        Coordinate _range;
        Shapes _page;
        Model _model;
        double _firstPointX;
        double _firstPointY;
        double _distanceX;
        double _distanceY;

        public PointState(Shape selection, Model model, Shapes page)
        {
            _selection = selection;
            _model = model;
            _range = new Coordinate();
            _page = page;
        }

        //滑鼠被按下
        public void MouseDown(double pointX, double pointY)
        {
            if (_selection != null)
            {
                _firstPointX = pointX;
                _firstPointY = pointY;
                _range = _selection.GetPosition().Clone();
                _selection.SetSelect(true);
            }
        }

        //滑鼠移動
        public void MouseMove(double pointX, double pointY)
        {
            if (_selection != null)
            {
                _distanceX = pointX - _firstPointX;
                _distanceY = pointY - _firstPointY;

                _selection.SetCoordinate(_range._left + _distanceX, _range._top + _distanceY, _range._right + _distanceX, _range._bottom + _distanceY);
            }
        }

        //滑鼠釋放
        public void MouseRelease()
        {
            if (_selection != null)
            {
                _model.LogCommand(new MoveCommand(_model, _selection, _range, _page));
            }
        }
    }
}

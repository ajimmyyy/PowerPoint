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
        double _firstPointX;
        double _firstPointY;

        public PointState(double pointX, double pointY, Shape selection)
        {
            this._firstPointX = pointX;
            this._firstPointY = pointY;
            _selection = selection;
        }

        //滑鼠被按下
        public void MouseDown()
        {
            if (_selection != null)
            {
                _selection.SetIsSelect(true);
            }
        }

        //滑鼠移動
        public void MouseMove(double pointX, double pointY)
        {
            if (_selection != null)
            {
                Coordinate range = _selection.GetPosition();
                double distanceX = pointX - _firstPointX;
                double distanceY = pointY - _firstPointY;

                _selection.SetCoordinate(range._left + distanceX, range._top + distanceY, range._right + distanceX, range._bottom + distanceY);
                this._firstPointX = pointX;
                this._firstPointY = pointY;
            }
        }

        //滑鼠釋放
        public void MouseRelease()
        {
            if (_selection != null)
            {
                Coordinate range = _selection.GetPosition();
                _selection.SetPosition(range._left, range._top, range._right, range._bottom);
            }
        }
    }
}

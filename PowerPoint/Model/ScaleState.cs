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
        double _firstPointX;
        double _firstPointY;

        public ScaleState(double pointX, double pointY, Shape selection)
        {
            this._firstPointX = pointX;
            this._firstPointY = pointY;
            _selection = selection;
        }

        //滑鼠被按下
        public void MouseDown()
        {
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
                Coordinate range = _selection.GetPosition();
                _selection.SetPosition(range._left, range._top, range._right, range._bottom);
            }
        }
    }
}
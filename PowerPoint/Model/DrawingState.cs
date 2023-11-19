using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    public class DrawingState : IState
    {
        Model _model;
        double _pointX;
        double _pointY;

        public DrawingState(Model model, double pointX = 0, double pointY = 0)
        {
            this._model = model;
            this._pointX = pointX;
            this._pointY = pointY;
        }

        //滑鼠被按下
        public void MouseDown()
        {
            if (_pointX > 0 && _pointY > 0)
            {
                _model.CreateHint();
                _model.SetFirstPoint(_pointX, _pointY);
            }
        }

        //滑鼠移動
        public void MouseMove()
        {
            _model.SetHintPosition(_pointX, _pointY);
        }

        //滑鼠釋放
        public void MouseRelease()
        {
            _model.AddHint();
        }

        //鍵盤刪除按下
        public void DeletePress()
        {
        }
    }
}

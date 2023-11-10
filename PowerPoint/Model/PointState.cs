﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    class PointState : IState
    {
        Model _model;
        double _pointX;
        double _pointY;

        public PointState(Model model, double pointX = 0, double pointY = 0)
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
                _model.SelectShape(_pointX, _pointY);
            }
        }

        //滑鼠移動
        public void MouseMove()
        {
            _model.MoveShape(_pointX, _pointY);
        }

        //滑鼠釋放
        public void MouseRelease()
        {

        }

        //鍵盤刪除按下
        public void DeletePress()
        {
            _model.DeleteShape();
        }
    }
}

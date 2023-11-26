﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    public class DrawingState : IState
    {
        Shape _hint = null;
        double _firstPointX;
        double _firstPointY;

        public DrawingState(double pointX, double pointY, Shape hint)
        {
            this._firstPointX = pointX;
            this._firstPointY = pointY;
            _hint = hint;
        }

        //滑鼠被按下
        public void MouseDown()
        {
        }

        //滑鼠移動
        public void MouseMove(double pointX, double pointY)
        {
            _hint.SetPosition(_firstPointX, _firstPointY, pointX, pointY);
        }

        //滑鼠釋放
        public void MouseRelease()
        {
        }
    }
}
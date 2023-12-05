using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    public class DrawingState : IState
    {
        Shape _hint = null;
        Model _model;
        double _firstPointX;
        double _firstPointY;

        public DrawingState(Shape hint, Model model)
        {
            _hint = hint;
            _model = model;
        }

        //滑鼠被按下
        public void MouseDown(double pointX, double pointY)
        {
            _firstPointX = pointX;
            _firstPointY = pointY;
        }

        //滑鼠移動
        public void MouseMove(double pointX, double pointY)
        {
            _hint.SetPosition(_firstPointX, _firstPointY, pointX, pointY);
        }

        //滑鼠釋放
        public void MouseRelease()
        {
            _model.LogCommand(new DrawCommand(_model, _hint));
        }
    }
}

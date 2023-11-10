using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    class DrawingState : IState
    {
        private double _firstPointX;
        private double _firstPointY;
        private Shape _hint;
        private bool _isPressed = false;
        Model _model;

        public DrawingState(Model model)
        {
            this._model = model;
        }

        public void MouseDown(double pointX, double pointY)
        {
            if (pointX > 0 && pointY > 0)
            {
                _hint = Factory.CreateShape(_model.GetToolMode);
                _firstPointX = pointX;
                _firstPointY = pointY;
                _isPressed = true;
            }
        }

        public void MouseMove(double pointX, double pointY)
        {
            if (_isPressed)
            {
                _hint.SetPosition(_firstPointX, _firstPointY, pointX, pointY);
            }
        }

        public void MouseRelease(double pointX, double pointY)
        {
            if (_isPressed)
            {
                _isPressed = false;
                _model.GetToolMode = "";
                _hint.SetPosition(_firstPointX, _firstPointY, pointX, pointY);
                _model.GetShapes.AddShape(_hint);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    public class Selection
    {
        const double DOT_RADIUS = 5;
        Coordinate _shapePosition = new Coordinate();
        Shape _shapeSelect;

        //設定位置
        public void SetPosition(double left, double top, double right, double bottom)
        {
            if (_shapeSelect != null)
            {
                _shapeSelect.GetPosition()._left = left;
                _shapeSelect.GetPosition()._top = top;
                _shapeSelect.GetPosition()._right = right;
                _shapeSelect.GetPosition()._bottom = bottom;
                UpdatePosition();
            }
        }

        //更新資訊
        public void UpdateInfo()
        {
            if (_shapeSelect != null)
            {
                _shapeSelect.SetPosition(_shapePosition._left, _shapePosition._top, _shapePosition._right, _shapePosition._bottom);
            }
        }

        //更新位置
        public void UpdatePosition()
        {
            if (_shapeSelect != null)
            {
                _shapePosition._left = _shapeSelect.GetPosition()._left;
                _shapePosition._top = _shapeSelect.GetPosition()._top;
                _shapePosition._right = _shapeSelect.GetPosition()._right;
                _shapePosition._bottom = _shapeSelect.GetPosition()._bottom;
            }
        }

        //繪圖
        public void Draw(IGraphics graphics)
        {
            if (_shapeSelect != null)
            {
                double middlePointX = _shapePosition.middleX;
                double middlePointY = _shapePosition.middleY;

                graphics.DrawDot(_shapePosition._left, _shapePosition._top, DOT_RADIUS);
                graphics.DrawDot(_shapePosition._left, _shapePosition._bottom, DOT_RADIUS);
                graphics.DrawDot(_shapePosition._right, _shapePosition._top, DOT_RADIUS);
                graphics.DrawDot(_shapePosition._right, _shapePosition._bottom, DOT_RADIUS);
                graphics.DrawDot(middlePointX, _shapePosition._top, DOT_RADIUS);
                graphics.DrawDot(middlePointX, _shapePosition._bottom, DOT_RADIUS);
                graphics.DrawDot(_shapePosition._right, middlePointY, DOT_RADIUS);
                graphics.DrawDot(_shapePosition._left, middlePointY, DOT_RADIUS);
            }
        }

        //清除選取
        public void Unselect()
        {
            _shapeSelect = null;
        }

        //取得座標
        public Coordinate ShapeRange
        {
            get
            {
                return _shapePosition;
            }
        }

        //取得形狀
        public Shape ShapeSelect
        {
            get
            {
                return _shapeSelect;
            }
            set
            {
                _shapeSelect = value;
                UpdatePosition();
            }
        }
    }
}

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
        Coordinate _shapeRange = new Coordinate();
        Shape _shapeSelect;

        public Selection(Shape shape)
        {
            this._shapeSelect = shape;
        }

        //設定位置
        public void UpdataRange()
        {
            if (_shapeSelect != null)
            {
                _shapeRange._left = _shapeSelect.GetPosition()._left;
                _shapeRange._top = _shapeSelect.GetPosition()._top;
                _shapeRange._right = _shapeSelect.GetPosition()._right;
                _shapeRange._bottom = _shapeSelect.GetPosition()._bottom;
            }
        }

        //繪圖
        public void Draw(IGraphics graphics)
        {
            if (_shapeSelect != null)
            {
                double middlePointX = _shapeRange.middleX;
                double middlePointY = _shapeRange.middleY;

                graphics.DrawDot(_shapeRange._left, _shapeRange._top, DOT_RADIUS);
                graphics.DrawDot(_shapeRange._left, _shapeRange._bottom, DOT_RADIUS);
                graphics.DrawDot(_shapeRange._right, _shapeRange._top, DOT_RADIUS);
                graphics.DrawDot(_shapeRange._right, _shapeRange._bottom, DOT_RADIUS);
                graphics.DrawDot(middlePointX, _shapeRange._top, DOT_RADIUS);
                graphics.DrawDot(middlePointX, _shapeRange._bottom, DOT_RADIUS);
                graphics.DrawDot(_shapeRange._right, middlePointY, DOT_RADIUS);
                graphics.DrawDot(_shapeRange._left, middlePointY, DOT_RADIUS);
            }
        }

        public void Unselect()
        {
            _shapeSelect = null;
        }

        //取得座標
        public Coordinate ShapeRange
        {
            get
            {
                return _shapeRange;
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
                UpdataRange();
            }
        }
    }
}

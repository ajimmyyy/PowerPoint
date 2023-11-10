using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    public class Border
    {
        const double DOT_RADIUS = 5;
        Coordinate _position = new Coordinate();
        Shape _shape;

        public Border(Shape shape)
        {
            this._shape = shape;
            SetBorder(shape.GetPosition()._left, shape.GetPosition()._top, shape.GetPosition()._right, shape.GetPosition()._bottom);
        }

        //設定位置
        public void SetBorder(double left, double top, double right, double bottom)
        {
            _position._left = left;
            _position._top = top;
            _position._right = right;
            _position._bottom = bottom;
            _shape.SetPosition(left, top, right, bottom);
        }

        //繪圖
        public void Draw(IGraphics graphics)
        {
            double middlePointX = _position.middleX;
            double middlePointY = _position.middleY;

            graphics.DrawDot(_position._left, _position._top, DOT_RADIUS);
            graphics.DrawDot(_position._left, _position._bottom, DOT_RADIUS);
            graphics.DrawDot(_position._right, _position._top, DOT_RADIUS);
            graphics.DrawDot(_position._right, _position._bottom, DOT_RADIUS);
            graphics.DrawDot(middlePointX, _position._top, DOT_RADIUS);
            graphics.DrawDot(middlePointX, _position._bottom, DOT_RADIUS);
            graphics.DrawDot(_position._right, middlePointY, DOT_RADIUS);
            graphics.DrawDot(_position._left, middlePointY, DOT_RADIUS);
            _shape.Draw(graphics);
        }

        //取得座標
        public Coordinate GetPosition()
        {
            return _position;
        }

        //取得形狀
        public Shape GetShape()
        {
            return _shape;
        }
    }
}

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
        const int SQUARE = 2;
        Coordinate _position = new Coordinate();

        //設定位置
        public void SetPosition(Coordinate position)
        {
            _position = position;
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
        }

        //是否在拉選區域
        public bool IsScaleArea(double pointX, double pointY, double ratio = 1)
        {
            double distanceX = pointX - _position._right;
            double distanceY = pointY - _position._bottom;
            double distanceSquareX = Math.Pow(distanceX, SQUARE);
            double distanceSquareY = Math.Pow(distanceY, SQUARE);

            if (Math.Sqrt(distanceSquareX + distanceSquareY) <= DOT_RADIUS * ratio)
            {
                return true;
            }

            return false;
        }
    }
}

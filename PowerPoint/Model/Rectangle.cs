using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    public class Rectangle : Shape
    {
        const string INFO_FORMAT = "({0}, {1})";
        Coordinate _topLeft = new Coordinate();
        Coordinate _bottomRight = new Coordinate();

        public Rectangle(double left, double top, double right, double bottom)
        {
            ShapeName = ModeType.RECTANGLE_NAME;
            SetPosition(left, top, right, bottom);
        }

        //設定位置
        public override void SetPosition(double left, double top, double right, double bottom)
        {
            _topLeft._coordinateX = left < right ? left : right;
            _topLeft._coordinateY = top < bottom ? top : bottom;
            _bottomRight._coordinateX = right < left ? left : right;
            _bottomRight._coordinateY = bottom < top ? top : bottom;
            Info = string.Format(INFO_FORMAT, _topLeft.ToString(), _bottomRight.ToString());
        }

        //繪圖
        public override void Draw(IGraphics graphics)
        {
            graphics.DrawRectangle(_topLeft._coordinateX, _topLeft._coordinateY, _bottomRight._coordinateX, _bottomRight._coordinateY);
        }
    }
}

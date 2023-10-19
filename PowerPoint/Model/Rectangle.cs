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

        //取得圖形資訊
        public string GetInfo()
        {
            return string.Format(INFO_FORMAT, _topLeft.ToString(), _bottomRight.ToString());
        }

        //取得圖形名稱
        public string GetShapeName()
        {
            return ShapeType.RECTANGLE_NAME;
        }

        //設定初始位置
        public void SetInitialPosition(double left, double top, double right, double bottom)
        {
            _topLeft._coordinateX = left < right ? left : right;
            _topLeft._coordinateY = top < bottom ? top : bottom;
            _bottomRight._coordinateX = right < left ? left : right;
            _bottomRight._coordinateY = bottom < top ? top : bottom;
        }

        //繪圖
        public void Draw(IGraphics graphics)
        {
            graphics.DrawRectangle(_topLeft._coordinateX, _topLeft._coordinateY, _bottomRight._coordinateX, _bottomRight._coordinateY);
        }
    }
}

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
        public Coordinate _topLeft = new Coordinate();
        public Coordinate _bottomRight = new Coordinate();

        //取得圖形資訊(重載)
        public string GetInfo()
        {
            return string.Format(INFO_FORMAT, _topLeft.ToString(), _bottomRight.ToString());
        }

        //取得圖形名稱(重載)
        public string GetShapeName()
        {
            return ShapeType.RECTANGLE_NAME;
        }

        public void SetInitialPosition(params double[] pos)
        {
            _topLeft._coordinateX = pos[0] < pos[2] ? pos[0] : pos[2];
            _topLeft._coordinateY = pos[1] < pos[3] ? pos[1] : pos[3];
            _bottomRight._coordinateX = pos[2] < pos[0] ? pos[0] : pos[2];
            _bottomRight._coordinateY = pos[3] < pos[1] ? pos[1] : pos[3];
        }

        public void Draw(IGraphics graphics)
        {
            graphics.DrawRectangle(_topLeft._coordinateX, _topLeft._coordinateY, _bottomRight._coordinateX, _bottomRight._coordinateY);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    public class Line : Shape
    {
        const string INFO_FORMAT = "({0}, {1})";
        Coordinate _topLeft;
        Coordinate _bottomRight;

        public Line(int top, int left, int bottom, int right)
        {
            _topLeft = new Coordinate(left, top);
            _bottomRight = new Coordinate(right, bottom);
        }

        //取得圖形資訊(重載)
        public string GetInfo()
        {
            return string.Format(INFO_FORMAT, _topLeft.ToString(), _bottomRight.ToString());
        }

        //取得圖形名稱(重載)
        public string GetShapeName()
        {
            return ShapeType.LINE_NAME;
        }
    }
}

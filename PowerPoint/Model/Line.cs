using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    public class Line : Shape
    {
        const string INFO_FORMAT = "(({0}, {1}),({2}, {3}))";
        Coordinate _position = new Coordinate();

        public Line(double left, double top, double right, double bottom)
        {
            SetPosition(left, top, right, bottom);
        }

        //取得圖形資訊
        public string GetInfo()
        {
            return string.Format(INFO_FORMAT, _position._left, _position._top, _position._right, _position._bottom);
        }

        //取得圖形名稱
        public string GetShapeName()
        {
            return ModeType.LINE_NAME;
        }

        //設定位置
        public void SetPosition(double left, double top, double right, double bottom)
        {
            _position._left = left;
            _position._top = top;
            _position._right = right;
            _position._bottom = bottom;
        }

        //取的座標
        public Coordinate GetPosition()
        {
            return _position;
        }

        //繪圖
        public void Draw(IGraphics graphics)
        {
            graphics.DrawLine(_position._left, _position._top, _position._right, _position._bottom);
        }
    }
}

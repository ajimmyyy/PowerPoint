using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    public class Circle : Shape
    {
        Coordinate _position = new Coordinate();

        public Circle(double left, double top, double right, double bottom)
        {
            ShapeName = ModeType.CIRCLE_NAME;
            SetPosition(left, top, right, bottom);
        }

        //設定位置
        public override void SetPosition(double left, double top, double right, double bottom)
        {
            _position._left = left;
            _position._top = top;
            _position._right = right;
            _position._bottom = bottom;
            Info = _position.ToString();
        }

        //取得座標
        public override Coordinate GetPosition()
        {
            return _position;
        }

        //繪圖
        public override void Draw(IGraphics graphics)
        {
            graphics.DrawCircle(_position._left, _position._top, _position._right, _position._bottom);
        }
    }
}

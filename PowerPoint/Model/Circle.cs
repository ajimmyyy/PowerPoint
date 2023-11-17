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
            SetPosition(left, top, right, bottom);
        }

        //取得圖形資訊
        public string GetInfo()
        {
            return _position.ToString();
        }

        //取得圖形名稱
        public string GetShapeName()
        {
            return ModeType.CIRCLE_NAME;
        }

        //設定位置
        public void SetPosition(double left, double top, double right, double bottom)
        {
            _position._left = left;
            _position._top = top;
            _position._right = right;
            _position._bottom = bottom;
        }

        //取得座標
        public Coordinate GetPosition()
        {
            return _position;
        }

        //繪圖
        public void Draw(IGraphics graphics)
        {
            graphics.DrawCircle(_position._left, _position._top, _position._right, _position._bottom);
        }
    }
}

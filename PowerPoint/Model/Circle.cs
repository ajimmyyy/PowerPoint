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

        public Circle(double left, double top, double right, double bottom, double ratio = 1)
        {
            ShapeName = ModeType.CIRCLE_NAME;
            SetPosition(left, top, right, bottom);
            _selection.SetPosition(_position);
            _ratio = ratio;
        }

        //設定位置
        public override void SetPosition(double left, double top, double right, double bottom)
        {
            SetCoordinate(left, top, right, bottom);
            SetInfo(_position);
        }

        //設定座標(不改變Info)
        public override void SetCoordinate(double left, double top, double right, double bottom)
        {
            _position._left = Math.Min(left, right);
            _position._top = Math.Min(top, bottom);
            _position._right = Math.Max(left, right);
            _position._bottom = Math.Max(top, bottom);
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

            if (_isSelect)
            {
                _selection.Draw(graphics);
            }
        }
    }
}

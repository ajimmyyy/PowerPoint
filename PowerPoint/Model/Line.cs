using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    public class Line : Shape
    {
        Coordinate _position = new Coordinate();

        public Line(double left, double top, double right, double bottom)
        {
            ShapeName = ModeType.LINE_NAME;
            SetPosition(left, top, right, bottom);
            _selection.SetPosition(_position);
        }

        //設定位置
        public override void SetPosition(double left, double top, double right, double bottom)
        {
            SetCoordinate(left, top, right, bottom);
            Info = _position.ToString();
        }

        //設定座標(不改變Info)
        public override void SetCoordinate(double left, double top, double right, double bottom)
        {
            _position._left = left;
            _position._top = top;
            _position._right = right;
            _position._bottom = bottom;
        }

        public override void ScalePosition(double ratio)
        {
            _position._left *= ratio;
            _position._top *= ratio;
            _position._right *= ratio;
            _position._bottom *= ratio;
        }

        //取的座標
        public override Coordinate GetPosition()
        {
            return _position;
        }

        //繪圖
        public override void Draw(IGraphics graphics)
        {
            graphics.DrawLine(_position._left, _position._top, _position._right, _position._bottom);

            if (_isSelect)
            {
                _selection.Draw(graphics);
            }
        }
    }
}

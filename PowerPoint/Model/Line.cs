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

        public Line(double left, double top, double right, double bottom, double ratio = 1)
        {
            ShapeName = ModeType.LINE_NAME;
            SetPosition(left, top, right, bottom);
            _selection.SetPosition(_position);
            _ratio = ratio;
        }

        //設定位置
        public override void SetPosition(double left, double top, double right, double bottom)
        {
            if (top > bottom)
                SetCoordinate(right, bottom, left, top);
            else
                SetCoordinate(left, top, right, bottom);
            SetInfo(_position);
        }

        //設定座標(不改變Info)
        public override void SetCoordinate(double left, double top, double right, double bottom)
        {
            _position._left = left;
            _position._top = top;
            _position._right = right;
            _position._bottom = bottom;
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

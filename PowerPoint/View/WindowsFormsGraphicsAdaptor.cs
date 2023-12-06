using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PowerPoint
{
    class WindowsFormsGraphicsAdaptor : IGraphics
    {
        const int TWICE = 2;
        double _ratio;
        Graphics _graphics;

        public WindowsFormsGraphicsAdaptor(Graphics graphics, double ratio)
        {
            this._graphics = graphics;
            this._ratio = ratio;
        }

        //清除所有圖形
        public void ClearAll()
        {

        }

        //畫線
        public void DrawLine(double x1, double y1, double x2, double y2)
        {
            _graphics.DrawLine(Pens.Red, (float)(x1 * _ratio), (float)(y1 * _ratio), (float)(x2 * _ratio), (float)(y2 * _ratio));
        }

        //畫矩形
        public void DrawRectangle(double x1, double y1, double x2, double y2)
        {
            _graphics.DrawRectangle(Pens.Red, (float)(x1 * _ratio), (float)(y1 * _ratio), (float)((x2 - x1) * _ratio), (float)((y2 - y1) * _ratio));
        }

        //畫圓形
        public void DrawCircle(double x1, double y1, double x2, double y2)
        {
            _graphics.DrawEllipse(Pens.Red, (float)(x1 * _ratio), (float)(y1 * _ratio), (float)((x2 - x1) * _ratio), (float)((y2 - y1) * _ratio));
        }

        //畫小圓點
        public void DrawDot(double centerX, double centerY, double radius)
        {
            _graphics.DrawEllipse(Pens.Black, (float)((centerX * _ratio - radius)), (float)((centerY * _ratio - radius)), (float)(TWICE * radius), (float)(TWICE * radius));
        }
    }
}

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
        Graphics _graphics;
        public WindowsFormsGraphicsAdaptor(Graphics graphics)
        {
            this._graphics = graphics;
        }

        //清除所有圖形
        public void ClearAll()
        {

        }

        //畫線
        public void DrawLine(double x1, double y1, double x2, double y2)
        {
            _graphics.DrawLine(Pens.Red, (float)x1, (float)y1, (float)x2, (float)y2);
        }

        //畫矩形
        public void DrawRectangle(double x1, double y1, double x2, double y2)
        {
            _graphics.DrawRectangle(Pens.Red, (float)x1, (float)y1, (float)(x2 - x1), (float)(y2 - y1));
        }

        //畫圓形
        public void DrawCircle(double x1, double y1, double x2, double y2)
        {
            _graphics.DrawEllipse(Pens.Red, (float)x1, (float)y1, (float)(x2 - x1), (float)(y2 - y1));
        }

        //畫小圓點
        public void DrawDot(double centerX, double centerY, double radius)
        {
            _graphics.DrawEllipse(Pens.Black, (float)(centerX - radius), (float)(centerY - radius), (float)(TWICE * radius), (float)(TWICE * radius));
        }
    }
}

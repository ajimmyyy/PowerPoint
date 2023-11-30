using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PowerPoint
{
    class SlideFormsGraphicsAdaptor : IGraphics
    {
        float RESIZE;
        Graphics _graphics;
        public SlideFormsGraphicsAdaptor(Graphics graphics, float resize)
        {
            this._graphics = graphics;
            RESIZE = resize;
        }

        //清除所有圖形
        public void ClearAll()
        {

        }

        //畫線
        public void DrawLine(double x1, double y1, double x2, double y2)
        {
            _graphics.DrawLine(Pens.Red, (float)(x1 * RESIZE), (float)(y1 * RESIZE), (float)(x2 * RESIZE), (float)(y2 * RESIZE));
        }

        //畫矩形
        public void DrawRectangle(double x1, double y1, double x2, double y2)
        {
            _graphics.DrawRectangle(Pens.Red, (float)(x1 * RESIZE), (float)(y1 * RESIZE), (float)(x2 - x1) * RESIZE, (float)(y2 - y1) * RESIZE);
        }

        //畫圓形
        public void DrawCircle(double x1, double y1, double x2, double y2)
        {
            _graphics.DrawEllipse(Pens.Red, (float)(x1 * RESIZE), (float)(y1 * RESIZE), (float)(x2 - x1) * RESIZE, (float)(y2 - y1) * RESIZE);
        }

        //畫小圓點
        public void DrawDot(double centerX, double centerY, double radius)
        { 
        }
    }
}

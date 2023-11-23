using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    class IGraphicsMock : IGraphics
    {
        int _clearAllCount = 0;
        int _drawLineCount = 0;
        int _drawRectangleCount = 0;
        int _drawCircleCount = 0;
        int _drawDotCount = 0;
        
        //清除所有圖形
        public void ClearAll()
        {
            _clearAllCount++;
        }

        //畫線
        public void DrawLine(double x1, double y1, double x2, double y2)
        {
            _drawLineCount++;
        }

        //畫矩形
        public void DrawRectangle(double x1, double y1, double x2, double y2)
        {
            _drawRectangleCount++;
        }

        //畫圓形
        public void DrawCircle(double x1, double y1, double x2, double y2)
        {
            _drawCircleCount++;
        }

        //畫小圓點
        public void DrawDot(double centerX, double centerY, double radius)
        {
            _drawDotCount++;
        }

        public int ClearAllCount
        {
            get
            {
                return _clearAllCount;
            }
        }

        public int DrawLineCount
        {
            get
            {
                return _drawLineCount;
            }
        }

        public int DrawRectangleCount
        {
            get
            {
                return _drawRectangleCount;
            }
        }

        public int DrawCircleCount
        {
            get
            {
                return _drawCircleCount;
            }
        }

        public int DrawDotCount
        {
            get
            {
                return _drawDotCount;
            }
        }
    }
}

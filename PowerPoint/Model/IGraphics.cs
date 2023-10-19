using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    public interface IGraphics
    {
        //清除所有圖形
        void ClearAll();

        //畫線
        void DrawLine(double x1, double y1, double x2, double y2);
        
        //畫矩形
        void DrawRectangle(double x1, double y1, double x2, double y2);

        //畫圓形
        void DrawCircle(double x1, double y1, double x2, double y2);
    }
}

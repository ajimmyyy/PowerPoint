using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace PowerPoint
{
    public interface Shape
    {
        //取得圖形資訊
        string GetInfo();

        //取得圖形名稱
        string GetShapeName();

        //設定位置
        void SetPosition(double left, double top, double right, double bottom);

        //取得位置
        Coordinate GetPosition();

        //繪圖
        void Draw(IGraphics graphics);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    public interface Shape
    {
        //取得圖形資訊
        string GetInfo();

        //取得圖形名稱
        string GetShapeName();
    }
}

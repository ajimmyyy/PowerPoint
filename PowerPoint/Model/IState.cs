using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    public interface IState
    {
        //滑鼠被按下
        void MouseDown();
        //滑鼠移動
        void MouseMove();
        //滑鼠釋放
        void MouseRelease();
        //鍵盤刪除按下
        void DeletePress();
    }
}

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
        void MouseMove(double pointX, double pointY);

        //滑鼠釋放
        void MouseRelease();
    }
}

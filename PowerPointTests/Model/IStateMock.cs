using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    public class IStateMock : IState
    {
        int _mouseDownCount = 0;
        int _mouseMoveCount = 0;
        int _mouseReleaseCount = 0;

        //滑鼠被按下
        public void MouseDown(double pointX, double pointY)
        {
            _mouseDownCount++;
        }

        //滑鼠移動
        public void MouseMove(double pointX, double pointY)
        {
            _mouseMoveCount++;
        }

        //滑鼠釋放
        public void MouseRelease()
        {
            _mouseReleaseCount++;
        }

        public int MouseDownCount
        {
            get
            {
                return _mouseDownCount;
            }
        }
        public int MouseMoveCount
        {
            get
            {
                return _mouseMoveCount;
            }
        }
        public int MouseReleaseCount
        {
            get
            {
                return _mouseReleaseCount;
            }
        }
    }
}

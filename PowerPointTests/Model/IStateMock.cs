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
        int _deletePressCount = 0;

        //滑鼠被按下
        public void MouseDown()
        {
            _mouseDownCount++;
        }

        //滑鼠移動
        public void MouseMove()
        {
            _mouseMoveCount++;
        }

        //滑鼠釋放
        public void MouseRelease()
        {
            _mouseReleaseCount++;
        }

        //鍵盤刪除按下
        public void DeletePress()
        {
            _deletePressCount++;
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
        public int DeletePressCount
        {
            get
            {
                return _deletePressCount;
            }
        }
    }
}

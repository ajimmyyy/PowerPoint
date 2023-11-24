using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    public class ModelMock : Model
    {
        int _drawCount = 0;
        int _pressCount = 0;
        int _moveCount = 0;
        int _releaseCount = 0;
        int _deleteCount = 0;

        //畫出所有形狀和即時形狀
        public override void Draw(IGraphics graphics)
        {
            _drawCount++;
        }

        //滑鼠被按下
        public override void PressPointer(IState state)
        {
            _pressCount++;
        }

        //滑鼠移動
        public override void MovePointer(IState state)
        {
            _moveCount++;
        }

        //滑鼠釋放
        public override void ReleasePointer(IState state)
        {
            _releaseCount++;
        }

        //鍵盤刪除按下
        public override void PressDelete(IState state)
        {
            _deleteCount++;
        }

        public int DrawCount
        {
            get
            {
                return _drawCount;
            }
        }

        public int PressCount
        {
            get
            {
                return _pressCount;
            }
        }

        public int MoveCount
        {
            get
            {
                return _moveCount;
            }
        }

        public int ReleaseCount
        {
            get
            {
                return _releaseCount;
            }
        }

        public int DeleteCount
        {
            get
            {
                return _deleteCount;
            }
        }
    }
}

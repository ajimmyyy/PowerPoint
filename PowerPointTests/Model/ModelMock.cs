using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    public class ModelMock : Model
    {
        int _addButtonCount = 0;
        int _deleteButtonCount = 0;
        int _drawCount = 0;
        int _pressCount = 0;
        int _moveCount = 0;
        int _releaseCount = 0;
        int _deleteCount = 0;
        int _undoCount = 0;
        int _redoCount = 0;
        int _inScaleAreaCount = 0;
        int _setToolCount = 0;

        //當DataGridView新增按鈕被按下的處理
        public override void AddButtonClickEvent(string shapeType, double ratio)
        {
            _addButtonCount++;
        }

        //當DataGridView刪除按鈕被按下的處理
        public override void DeleteButtonClickEvent(int rowIndex, int columnIndex)
        {
            _deleteButtonCount++;
        }

        //畫出所有形狀和即時形狀
        public override void Draw(IGraphics graphics)
        {
            _drawCount++;
        }

        //滑鼠被按下
        public override void PressPointer(double pointX, double pointY)
        {
            _pressCount++;
        }

        //滑鼠移動
        public override void MovePointer(double pointX, double pointY)
        {
            _moveCount++;
        }

        //滑鼠釋放
        public override void ReleasePointer()
        {
            _releaseCount++;
        }

        //鍵盤刪除按下
        public override void PressDelete()
        {
            _deleteCount++;
        }

        //操作復原
        public override void Undo()
        {
            _undoCount++;
        }

        //操作重做
        public override void Redo()
        {
            _redoCount++;
        }

        //設定繪圖模式
        public override void SetToolMode(string shapeType)
        {
            _setToolCount++;
        }

        //是否在縮放區域
        public override bool IsInScaleArea(double pointX, double pointY, double ratio)
        {
            _inScaleAreaCount++;
            return true;
        }

        public int AddButtonCount
        {
            get
            {
                return _addButtonCount;
            }
        }

        public int DeleteButtonCount
        {
            get
            {
                return _deleteButtonCount;
            }
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

        public int UndoCount
        {
            get
            {
                return _undoCount;
            }
        }

        public int RedoCount
        {
            get
            {
                return _redoCount;
            }
        }

        public int InScaleAreaCount
        {
            get
            {
                return _inScaleAreaCount;
            }
        }

        public int SetToolCount
        {
            get
            {
                return _setToolCount;
            }
        }
    }
}

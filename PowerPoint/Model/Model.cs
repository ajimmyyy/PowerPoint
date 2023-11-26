using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace PowerPoint
{
    public class Model
    {
        public event ModelChangedEventHandler _modelChanged;
        public delegate void ModelChangedEventHandler();
        private string _toolModePressed = "";
        private bool _isPressed = false;
        private bool _isInScaleArea = false;
        private Shape _hint;
        private Shape _selection;
        private Shapes _shapes = new Shapes();
        private IState _state;

        //當DataGridView新增按鈕被按下的處理
        public void AddButtonClickEvent(string shapeType)
        {
            if (shapeType != "")
            {
                _shapes.AddNewShape(shapeType);
                NotifyModelChanged();
            }
        }

        //當DataGridView刪除按鈕被按下的處理
        public void DeleteButtonClickEvent(int rowIndex, int columnIndex)
        {
            _selection = null;

            if (rowIndex >= 0 && columnIndex == 0)
            {
                _shapes.DeleteShape(rowIndex);
            }

            NotifyModelChanged();
        }

        //滑鼠被按下
        public virtual void PressPointer()
        {
            _isPressed = true;
            _state.MouseDown();
        }

        //滑鼠移動
        public virtual void MovePointer(double pointX, double pointY)
        {
            if (_isPressed)
            {
                _state.MouseMove(pointX, pointY);
                NotifyModelChanged();
            }
        }

        //滑鼠釋放
        public virtual void ReleasePointer()
        {
            if (_isPressed)
            {
                _state.MouseRelease();

                _shapes.AddShape(_hint);

                _hint = null;
                _state = null;
                _isPressed = false;
                _toolModePressed = "";
                NotifyModelChanged();
            }
        }

        //鍵盤刪除按下
        public virtual void PressDelete()
        {
            _shapes.DeleteShape(_selection);
            _selection = null;
            NotifyModelChanged();
        }

        //改變操作模式
        public void ChangeState(double pointX, double pointY)
        {
            if (_isInScaleArea)
            {
                _state = new ScaleState(_selection.GetPosition()._left, _selection.GetPosition()._top, _selection);
            }
            else if (_toolModePressed != ModeType.SELECT_NAME)
            {
                _hint = Factory.CreateShape(_toolModePressed);
                _state = new DrawingState(pointX, pointY, _hint);
            }
            else
            {
                SelectShape(pointX, pointY);
                _state = new PointState(pointX, pointY, _selection);
            } 
        }

        //選取圖形
        public void SelectShape(double pointX, double pointY)
        {
            if (_selection != null)
            {
                _selection.SetIsSelect(false);
            }

            _selection = _shapes.FindShape(pointX, pointY);
        }

        //畫出所有形狀和即時形狀
        public virtual void Draw(IGraphics graphics)
        {
            graphics.ClearAll();
            _shapes.Draw(graphics);

            if (_isPressed && _hint != null)
                _hint.Draw(graphics);                
        }

        //通知模型改變
        void NotifyModelChanged()
        {
            if (_modelChanged != null)
                _modelChanged();
        }

        //設定繪圖模式
        public virtual void SetToolMode(string shapeType)
        {
            _toolModePressed = shapeType;
        }

        //是否在縮放區域
        public virtual bool IsInScaleArea(double pointX, double pointY)
        {
            if (_selection == null)
            {
                return _isInScaleArea = false;
            }
            
            return _isInScaleArea = _selection.GetSelection().IsScaleArea(pointX, pointY);
        }

        //取得binding List
        public BindingList<Shape> ShapeList
        {
            get
            {
                return _shapes.GetShapeList;
            }
        }
    }
}

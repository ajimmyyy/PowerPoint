using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    public class Model
    {
        public event ModelChangedEventHandler _modelChanged;
        public event ModelChangedEventHandler _gridViewChanged;
        public delegate void ModelChangedEventHandler();
        private string _toolModePressed = "";
        private double _firstPointX;
        private double _firstPointY;
        private bool _isPressed = false;
        private Shape _hint;
        private Shapes _shapes = new Shapes();
        
        //當DataGridView新增按鈕被按下的處理
        public void AddButtonClickEvent(string shapeType)
        {
            if (shapeType == "")
            {
                return;
            }

            _shapes.AddNewShape(shapeType);
            NotifyModelChanged();
            NotifyGridViewChanged();
        }

        //當DataGridView刪除按鈕被按下的處理
        public void DeleteButtonClickEvent(int rowIndex, int columnIndex)
        {
            if (rowIndex >= 0 && columnIndex == 0)
            {
                _shapes.DeleteShape(rowIndex);
            }

            NotifyModelChanged();
            NotifyGridViewChanged();
        }

        //回傳list裡的資訊做顯示
        public List<ShapeGridViewModel> GetShapesDisplay()
        {
            return _shapes.GetShapeListInfo();
        }

        //繪圖滑鼠被按下
        public void PressPointer(double pointX, double pointY)
        {
            if (pointX > 0 && pointY > 0)
            {
                _hint = Factory.CreateShape(_toolModePressed);
                _firstPointX = pointX;
                _firstPointY = pointY;
                _isPressed = true;
            }
        }

        //繪圖滑鼠移動
        public void MovePointer(double pointX, double pointY)
        {
            if (_isPressed)
            {
                _hint.SetInitialPosition(_firstPointX, _firstPointY, pointX, pointY);
                NotifyModelChanged();
            }
        }

        //繪圖滑鼠釋放
        public void ReleasePointer(double pointX, double pointY)
        {
            if (_isPressed)
            {
                _isPressed = false;
                _toolModePressed = "";
                _hint.SetInitialPosition(_firstPointX, _firstPointY, pointX, pointY);
                _shapes.AddShape(_hint);
                NotifyModelChanged();
                NotifyGridViewChanged();
            }
        }

        //畫出所有形狀和即時形狀
        public void Draw(IGraphics graphics)
        {
            graphics.ClearAll();
            _shapes.Draw(graphics);

            if (_isPressed)
                _hint.Draw(graphics);
        }

        //通知模型改變
        void NotifyModelChanged()
        {
            if (_modelChanged != null)
                _modelChanged();
        }

        //通知DataGridView改變
        void NotifyGridViewChanged()
        {
            if (_gridViewChanged != null)
                _gridViewChanged();
        }

        //設定繪圖模式
        public void SetToolMode(string shapeType)
        {
            _toolModePressed = shapeType;
        }
    }
}

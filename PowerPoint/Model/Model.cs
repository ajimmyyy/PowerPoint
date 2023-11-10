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
        private double _firstPointX;
        private double _firstPointY;
        private Shape _hint;
        private bool _isPressed = false;
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
        }

        //當DataGridView刪除按鈕被按下的處理
        public void DeleteButtonClickEvent(int rowIndex, int columnIndex)
        {
            if (rowIndex >= 0 && columnIndex == 0)
            {
                _shapes.DeleteShape(rowIndex);
            }

            NotifyModelChanged();
        }

        //繪圖滑鼠被按下
        public void PressPointer(double pointX, double pointY)
        {
            
        }

        //繪圖滑鼠移動
        public void MovePointer(double pointX, double pointY)
        {
            NotifyModelChanged();
        }

        //繪圖滑鼠釋放
        public void ReleasePointer(double pointX, double pointY)
        {
            NotifyModelChanged();
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

        //設定繪圖模式
        public void SetToolMode(string shapeType)
        {
            _toolModePressed = shapeType;
        }

        public BindingList<Shape> ShapeList
        {
            get
            { 
                return _shapes.GetShapeList; 
            }
        }

        public Shapes GetShapes
        {
            get
            {
                return _shapes;
            }
        }

        public string GetToolMode
        {
            get
            {
                return _toolModePressed;
            }
            set
            {
                _toolModePressed = value;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    public class Model
    {
        private bool _isLinePressed = false;
        private bool _isRectanglePressed = false;
        private bool _isCirclePressed = false;
        private string _toolModePressed = "";

        public event ModelChangedEventHandler _modelChanged;
        public delegate void ModelChangedEventHandler();
        private double _firstPointX;
        private double _firstPointY;
        private bool _isPressed = false;
        private Shape _hint;

        private Shapes _shapes = new Shapes();
        private Dictionary<string, Action> _shapePressed;

        public Model()
        {
            _shapePressed = new Dictionary<string, Action>
            {
                { ShapeType.LINE_NAME, () => _isLinePressed = true },
                { ShapeType.RECTANGLE_NAME, () => _isRectanglePressed = true },
                { ShapeType.CIRCLE_NAME, () => _isCirclePressed = true }
            };
        }

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

        public void SetDrawingMode(string shapeType)
        {
            _isLinePressed = false;
            _isRectanglePressed = false;
            _isCirclePressed = false;
            _toolModePressed = shapeType;
            _shapePressed[shapeType]();
        }

        //回傳list裡的資訊做顯示
        public List<ShapeGridViewModel> GetShapesDisplay()
        {
            return _shapes.GetShapeListInfo();
        }

        public void PointerPressed(double x, double y)
        {
            if (x > 0 && y > 0)
            {
                _hint = Factory.CreateShape(_toolModePressed);
                _firstPointX = x;
                _firstPointY = y;
                _isPressed = true;
            }
        }

        public void PointerMoved(double x, double y)
        {
            if (_isPressed)
            {
                _hint.SetInitialPosition(_firstPointX, _firstPointY, x, y);
                NotifyModelChanged();
            }
        }

        public void PointerReleased(double x, double y)
        {
            if (_isPressed)
            {
                _isPressed = false;
                _isLinePressed = false;
                _isRectanglePressed = false;
                _isCirclePressed = false;
                _shapes.AddShape(_hint);
                NotifyModelChanged();
            }
        }

        public void Draw(IGraphics graphics)
        {
            _shapes.Draw(graphics);

            if (_isPressed)
                _hint.Draw(graphics);
        }

        void NotifyModelChanged()
        {
            if (_modelChanged != null)
                _modelChanged();
        }

        public bool IsLinePressed
        {
            get {
                return _isLinePressed;
            }
        }

        public bool IsRectanglePressed
        {
            get
            {
                return _isRectanglePressed;
            }
        }

        public bool IsCirclePressed
        {
            get
            {
                return _isCirclePressed;
            }
        }
    }
}

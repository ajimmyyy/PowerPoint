using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowerPoint
{
    public class PresentationModel
    {
        public event ButtonClickEventHandler _toolButtonClick;
        public delegate void ButtonClickEventHandler(bool chicked1, bool chicked2, bool chicked3);
        private bool _isLinePressed;
        private bool _isRectanglePressed;
        private bool _isCirclePressed;
        private Dictionary<string, Action> _shapePressed;
        Model _model;
       
        public PresentationModel(Model model)
        {
            this._model = model;
            _shapePressed = new Dictionary<string, Action>
            {
                { 
                    ShapeType.LINE_NAME, () => _isLinePressed = true 
                },
                { 
                    ShapeType.RECTANGLE_NAME, () => _isRectanglePressed = true 
                },
                { 
                    ShapeType.CIRCLE_NAME, () => _isCirclePressed = true 
                }
            };
            RefreshClickState();
        }

        //設定繪圖模式
        public void SetDrawingMode(string shapeType)
        {
            _isLinePressed = false;
            _isRectanglePressed = false;
            _isCirclePressed = false;
            _model.SetToolMode(shapeType);
            _shapePressed[shapeType]();
        }

        //設定tool按鈕狀態
        public void RefreshClickState()
        {
            if (_toolButtonClick != null)
            {
                _toolButtonClick(_isLinePressed, _isRectanglePressed, _isCirclePressed);
            }
        }

        //當tool按鈕被按下
        public void ToolButtonClickHandler(string shapeType)
        {
            SetDrawingMode(shapeType);
            RefreshClickState();
        }

        //更新鼠標
        public Cursor UpdateCursor()
        {
            if (IsToolButtonPressed())
                return Cursors.Cross;
            else
                return Cursors.Default;
        }

        //當滑鼠被按下
        public void CanvasPressedHandler(int pointX, int pointY)
        {
            if (IsToolButtonPressed())
            {
                _model.PressPointer(pointX, pointY);
            }
        }

        //當滑鼠釋放
        public void CanvasReleasedHandler(int pointX, int pointY)
        {
            _isLinePressed = false;
            _isRectanglePressed = false;
            _isCirclePressed = false;
            _model.ReleasePointer(pointX, pointY);
            RefreshClickState();
        }

        //tool按鈕是否被按下
        private bool IsToolButtonPressed()
        {
            return _isLinePressed || _isRectanglePressed || _isCirclePressed;
        }
        
        //繪圖
        public void Draw(System.Drawing.Graphics graphics)
        {
            _model.Draw(new WindowsFormsGraphicsAdaptor(graphics));
        }
    }
}

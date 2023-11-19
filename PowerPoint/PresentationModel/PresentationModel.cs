using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PowerPoint
{
    public class PresentationModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        const string CURSOR_DEFAULT = "Default";
        const string CURSOR_CROSS = "Cross";
        private bool _isLinePressed;
        private bool _isRectanglePressed;
        private bool _isCirclePressed;
        private bool _isSelectPressed;
        private Dictionary<string, Action> _shapePressed;
        Model _model;
        string _cursorType = CURSOR_DEFAULT;
        public Cursor CursorNow
        {
            get;
            set;
        }

        public bool IsLinePressed
        {
            get
            {
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

        public bool IsSelectPressed
        {
            get
            {
                return _isSelectPressed;
            }
        }

        public PresentationModel(Model model)
        {
            this._model = model;
            _shapePressed = new Dictionary<string, Action>
            {
                { 
                    ModeType.LINE_NAME, () => _isLinePressed = true 
                },
                { 
                    ModeType.RECTANGLE_NAME, () => _isRectanglePressed = true 
                },
                { 
                    ModeType.CIRCLE_NAME, () => _isCirclePressed = true 
                },
                {
                    ModeType.SELECT_NAME, () => _isSelectPressed = true
                }
            };
        }

        //當tool按鈕被按下
        public void ToolButtonClickHandler(string shapeType)
        {
            ToolButtonReset();
            _model.SetToolMode(shapeType);
            _shapePressed[shapeType]();
            NotifyPropertyChanged();
        }

        //更新鼠標
        public void UpdateCursor()
        {
            if (IsToolButtonPressed())
            {
                CursorNow = Cursors.Cross;
                _cursorType = CURSOR_CROSS;
            }
            else
            {
                CursorNow = Cursors.Default;
                _cursorType = CURSOR_DEFAULT;
            }  
        }

        //當滑鼠被按下
        public void CanvasPressedHandler(int pointX, int pointY)
        {
            if (_isSelectPressed)
            {
                _model.PressPointer(new PointState(_model, pointX, pointY));
            }
            else if (IsToolButtonPressed())
            {
                _model.PressPointer(new DrawingState(_model, pointX, pointY));
            }
        }

        //當滑鼠移動
        public void CanvasMoveHandler(int pointX, int pointY)
        {
            if (_isSelectPressed)
            {
                _model.MovePointer(new PointState(_model, pointX, pointY));
            }
            else if (IsToolButtonPressed())
            {
                _model.MovePointer(new DrawingState(_model, pointX, pointY));
            }
        }

        //當滑鼠釋放
        public void CanvasReleasedHandler(int pointX, int pointY)
        {
            if (_isSelectPressed)
            {
                _model.ReleasePointer(new PointState(_model, pointX, pointY));
            }
            else if (IsToolButtonPressed())
            {
                _model.ReleasePointer(new DrawingState(_model, pointX, pointY));
            }
            ToolButtonReset();
            _isSelectPressed = true;
            NotifyPropertyChanged();
        }

        //當鍵盤刪除按下
        public void PressKeyboardHandler(Keys keyPress)
        {
            if (keyPress == Keys.Delete)
            {
                if (_isSelectPressed)
                {
                    _model.PressDelete(new PointState(_model));
                }
                else if (IsToolButtonPressed())
                {
                    _model.PressDelete(new DrawingState(_model));
                }
            }
        }

        //tool按鈕是否被按下
        private bool IsToolButtonPressed()
        {
            return _isLinePressed || _isRectanglePressed || _isCirclePressed;
        }

        //重置tool按鈕
        private void ToolButtonReset()
        {
            _isLinePressed = false;
            _isRectanglePressed = false;
            _isCirclePressed = false;
            _isSelectPressed = false;
        }
        
        //繪畫區繪圖
        public void CanvasDraw(System.Drawing.Graphics graphics)
        {
            _model.Draw(new WindowsFormsGraphicsAdaptor(graphics));
        }

        //縮圖區繪圖
        public void SlideDraw(System.Drawing.Graphics graphics)
        {
            _model.Draw(new SlideFormsGraphicsAdaptor(graphics));
        }

        //通知tool按鈕屬性改變
        void NotifyPropertyChanged()
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(null));
            }
        }

        //取得鼠標樣式名
        public string GetCursorType()
        {
            return _cursorType;
        }
    }
}

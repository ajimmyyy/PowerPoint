﻿using System;
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
        public event CursorChangedEventHandler _cursorChanged;
        public delegate void CursorChangedEventHandler();
        const double WINDOW_RATIO = 9.0 / 16.0;
        const double HALF = 0.5;
        private bool _isLinePressed;
        private bool _isRectanglePressed;
        private bool _isCirclePressed;
        private bool _isSelectPressed;
        private bool _isInScaleArea;
        private bool _isUndoEnabled;
        private bool _isRedoEnabled;
        private int _lastWindowWidth = 1;
        private Dictionary<string, Action> _shapePressed;
        Model _model;

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

        public bool IsUndoEnabled
        {
            get
            {
                return _isUndoEnabled;
            }
        }
        public bool IsRedoEnabled
        {
            get
            {
                return _isRedoEnabled;
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
            _model.SetToolMode(shapeType);

            ToolButtonReset();
            _shapePressed[shapeType]();
            ToolButtonEnabledCheck();
        }

        //更新鼠標
        public void UpdateCursor()
        {
            if (_isInScaleArea)
            {
                CursorNow = Cursors.SizeNWSE;
            }
            else if (IsToolButtonPressed())
            {
                CursorNow = Cursors.Cross;
            }
            else
            {
                CursorNow = Cursors.Default;
            }
            NotifyCursorChanged();
        }

        public void AddButtonClickHandler(string shapeType)
        {
            _model.AddButtonClickEvent(shapeType);
            ToolButtonEnabledCheck();
        }

        public void DeleteCellClickHandler(int rowIndex, int columnIndex)
        {
            _model.DeleteButtonClickEvent(rowIndex, columnIndex);
            ToolButtonEnabledCheck();
        }

        //當滑鼠被按下
        public void CanvasPressedHandler(int pointX, int pointY)
        {
            if (pointX > 0 && pointY > 0)
            {
                _model.ChangeState(pointX, pointY);
                _model.PressPointer(pointX, pointY);
            }
        }

        //當滑鼠移動
        public void CanvasMoveHandler(int pointX, int pointY)
        {
            _isInScaleArea = _model.IsInScaleArea(pointX, pointY);
            UpdateCursor();
            _model.MovePointer(pointX, pointY);
        }

        //當滑鼠釋放
        public void CanvasReleasedHandler(int pointX, int pointY)
        {
            _model.ReleasePointer();

            ToolButtonReset();
            _isSelectPressed = true;
            ToolButtonEnabledCheck();
            _model.SetToolMode(ModeType.SELECT_NAME);
        }

        //當鍵盤刪除按下
        public void PressKeyboardHandler(Keys keyPress)
        {
            if (keyPress == Keys.Delete)
            {
                _model.PressDelete();

                ToolButtonEnabledCheck();
            }
        }

        public void UndoToolButtonClickHandler()
        {
            if (_isUndoEnabled)
            {
                _model.Undo();

                ToolButtonEnabledCheck();
            }
        }

        public void RedoToolButtonClickHandler()
        {
            if (_isRedoEnabled)
            {
                _model.Redo();

                ToolButtonEnabledCheck();
            }
        }

        public int ResizeWindow(int width)
        {
            return (int)(width * WINDOW_RATIO + 1);
        }

        public int RepositionWindow(int containerHeight, int panelHeight)
        {
            return (int)((containerHeight - panelHeight) * HALF);
        }

        public void DrawWindowResize(int width)
        {
            _model.ShapeResize((double)width / _lastWindowWidth);
            _lastWindowWidth = width;
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

        private void ToolButtonEnabledCheck()
        {
            _isUndoEnabled = _model.IsUndoEnabled;
            _isRedoEnabled = _model.IsRedoEnabled;
            NotifyPropertyChanged();
        }   

        //繪畫區繪圖
        public void CanvasDraw(System.Drawing.Graphics graphics)
        {
            _model.Draw(new WindowsFormsGraphicsAdaptor(graphics));
        }

        //縮圖區繪圖
        public void SlideDraw(System.Drawing.Graphics graphics, float drawWidth, float slideWidth)
        {
            _model.Draw(new SlideFormsGraphicsAdaptor(graphics, slideWidth / drawWidth));
        }

        //通知tool按鈕屬性改變
        void NotifyPropertyChanged()
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(null));
            }
        }

        //通知鼠標屬性改變
        void NotifyCursorChanged()
        {
            if (_cursorChanged != null)
            {
                _cursorChanged();
            }
        }
    }
}

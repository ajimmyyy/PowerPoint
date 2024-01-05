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
        public delegate void ModelChangedEventHandler(int index);
        public event PageAddEventHandler _pageAdd;
        public delegate void PageAddEventHandler();
        public event PageDeleteEventHandler _pageDelete;
        public delegate void PageDeleteEventHandler(int index);
        private string _toolModePressed = ModeType.SELECT_NAME;
        private bool _isPressed = false;
        private bool _isInScaleArea = false;
        private Shape _hint;
        private Shape _selection;
        private Pages _pages = new Pages();
        private Shapes _shapes;
        private IState _state;
        private CommandManager _commandManager = new CommandManager();

        public Model()
        {
            _shapes = Factory.CreateShapes();
            _pages.AddPage(_shapes);
        }

        //當DataGridView新增按鈕被按下的處理
        public virtual void AddButtonClickEvent(string shapeType, int[] coordinate)
        {
            LogCommand(new AddCommand(this, shapeType, coordinate, _shapes));
            NotifyModelChanged();
        }

        //當DataGridView刪除按鈕被按下的處理
        public virtual void DeleteButtonClickEvent(int rowIndex, int columnIndex)
        {
            _selection = null;

            if (rowIndex >= 0 && columnIndex == 0)
            {
                LogCommand(new DeleteCommand(this, _shapes.FindShape(rowIndex), _shapes));
            }

            NotifyModelChanged();
        }

        //滑鼠被按下
        public virtual void PressPointer(double pointX, double pointY)
        {
            _isPressed = true;
            _state.MouseDown(pointX, pointY);
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
            if (_selection != null)
            {
                LogCommand(new DeleteCommand(this, _selection, _shapes));
                _selection = null;
                NotifyModelChanged();
            }
        }

        public void ClickNewPage()
        {
            LogCommand(new AddPageCommand(this));
        }

        public void ClickDeletePage(int index)
        {
            LogCommand(new DeletePageCommand(this, _pages.GetPage(index)));
            if (index == 0)
                ChangePage(0);
            else
                ChangePage(index - 1);
        }

        public void ChangePage(int index)
        {
            _shapes = _pages.GetPage(index);
            NotifyModelChanged();
        }

        //紀錄命令
        public void LogCommand(ICommand command)
        {
            _commandManager.Execute(command);
        }

        //加入形狀
        public void AddShape(Shape shape, Shapes page)
        {
            _shapes = page;
            page.AddShape(shape);
        }

        //刪除形狀
        public void DeleteShape(Shape shape, Shapes page)
        {
            _shapes = page;
            page.DeleteShape(shape);
        }

        //移動形狀
        public void MoveShape(Shape shape, Coordinate range, Shapes page)
        {
            _shapes = page;
            shape.SetPosition(range._left, range._top, range._right, range._bottom);
        }

        public void AddPage(Shapes page)
        {
            _shapes = page;
            _pages.AddPage(page);
            NotifyPageAdd();
        }

        public void DeletePage(Shapes page)
        {
            int index = _pages.GetPageIndex(page);

            _pages.DeletePage(page);
            _shapes = _pages.GetPage(0);

            NotifyPageDelete(index);
        }

        //改變操作模式
        public void ChangeState(double pointX, double pointY)
        {
            if (_isInScaleArea)
            {
                _state = new ScaleState(_selection, this, _shapes);
            }
            else if (_toolModePressed != ModeType.SELECT_NAME)
            {
                _hint = Factory.CreateShape(_toolModePressed);
                _state = new DrawingState(_hint, this, _shapes);
            }
            else
            {
                SelectShape(pointX, pointY);
                _state = new PointState(_selection, this, _shapes);
            } 
        }

        //選取形狀
        public void SelectShape(double pointX, double pointY)
        {
            if (_selection != null)
            {
                _selection.SetSelect(false);
            }

            _selection = _shapes.FindShape(pointX, pointY);
        }

        //操作復原
        public virtual void Undo()
        {
            _commandManager.Undo();
            NotifyModelChanged();
        }

        //操作重做
        public virtual void Redo()
        {
            _commandManager.Redo();
            NotifyModelChanged();
        }

        //畫出所有形狀和即時形狀
        public virtual void Draw(IGraphics graphics)
        {
            graphics.ClearAll();
            _shapes.Draw(graphics);

            if (_isPressed && _hint != null)
                _hint.Draw(graphics);                
        }

        public virtual void DrawSlide(IGraphics graphics, int index)
        {
            graphics.ClearAll();
            _pages.GetPage(index).Draw(graphics);

            if (_isPressed && _hint != null)
                _hint.Draw(graphics);
        }

        //通知模型改變
        void NotifyModelChanged()
        {
            if (_modelChanged != null)
                _modelChanged(_pages.GetPageIndex(_shapes));
        }

        void NotifyPageAdd()
        {
            if (_pageAdd != null)
            {
                _pageAdd();
            }
        }

        void NotifyPageDelete(int index)
        {
            if (_pageDelete != null)
            {
                _pageDelete(index);
            }
        }

        //設定繪圖模式
        public virtual void SetToolMode(string shapeType)
        {
            _toolModePressed = shapeType;
        }

        //是否在縮放區域
        public virtual bool IsInScaleArea(double pointX, double pointY, double ratio)
        {
            if (_selection == null)
            {
                return _isInScaleArea = false;
            }
            
            return _isInScaleArea = _selection.GetSelection().IsScaleArea(pointX, pointY, ratio);
        }

        public bool IsUndoEnabled
        {
            get
            {
                return _commandManager.IsUndoEnabled;
            }
        }

        public bool IsRedoEnabled
        {
            get
            {
                return _commandManager.IsRedoEnabled;
            }
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

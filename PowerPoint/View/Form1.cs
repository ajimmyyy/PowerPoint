using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowerPoint
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        const string TOOL_BUTTON_CHECK = "Checked";
        const string TOOL_BUTTON_ENABLE = "Enabled";
        const string TOOL_BUTTON_LINE = "IsLinePressed";
        const string TOOL_BUTTON_RECTANGLE = "IsRectanglePressed";
        const string TOOL_BUTTON_CIRCLE = "IsCirclePressed";
        const string TOOL_BUTTON_SELECT = "IsSelectPressed";
        const string TOOL_BUTTON_UNDO = "IsUndoEnabled";
        const string TOOL_BUTTON_REDO = "IsRedoEnabled";
        const int WINDOW_PADDING = 10;

        private Model _model;
        private PresentationModel _presentationModel;

        public Form1()
        {
            InitializeComponent();
            _canvas.MouseEnter += EnterFromMouse;
            _canvas.MouseLeave += LeaveFromMouse;
            _canvas.MouseDown += CanvasPressed;
            _canvas.MouseUp += ReleasedCanvas;
            _canvas.MouseMove += CanvasMoved;
            _canvas.Paint += CanvasPaint;
            _slideButton.Paint += SlidePaint;
            _slideButton.Click += SlideClick;
            _slideButton.MouseEnter += EnterSlideMouse;
            _slideButton.MouseLeave += LeaveSlideMouse;

            _shapeDataGridView.CellClick += new DataGridViewCellEventHandler(DeleteCellClick);

            this.Resize += ResizeWindow;
            _windowSplitContainer.SplitterMoved += ResizeWindow;
            _drawSplitContainer.SplitterMoved += ResizeWindow;

            _model = new Model();
            _presentationModel = new PresentationModel(_model);
            _shapeDataGridView.DataSource = _model.ShapeList;
            _lineToolButton.DataBindings.Add(TOOL_BUTTON_CHECK, _presentationModel, TOOL_BUTTON_LINE);
            _rectangleToolButton.DataBindings.Add(TOOL_BUTTON_CHECK, _presentationModel, TOOL_BUTTON_RECTANGLE);
            _circleToolButton.DataBindings.Add(TOOL_BUTTON_CHECK, _presentationModel, TOOL_BUTTON_CIRCLE);
            _selectToolButton.DataBindings.Add(TOOL_BUTTON_CHECK, _presentationModel, TOOL_BUTTON_SELECT);
            _undoToolButton.DataBindings.Add(TOOL_BUTTON_ENABLE, _presentationModel, TOOL_BUTTON_UNDO);
            _redoToolButton.DataBindings.Add(TOOL_BUTTON_ENABLE, _presentationModel, TOOL_BUTTON_REDO);

            _model._modelChanged += ChangeModel;
            _model._pageAdd += AddPage;
            _model._pageDelete += DeletePage;
        }

        //DataGridView新增按鈕被按下
        private void AddButtonClick(object sender, EventArgs e)
        {
            using (CoordinateDialog modalDialog = new CoordinateDialog())
            {
                DialogResult result = modalDialog.ShowDialog();
                _presentationModel.AddButtonClickHandler(_shapeComboBox.Text, result, modalDialog.GetCoordinate());
            }
        }

        //DataGridView刪除按鈕被按下
        private void DeleteCellClick(object sender, DataGridViewCellEventArgs e)
        {
            _presentationModel.DeleteCellClickHandler(e.RowIndex, e.ColumnIndex);
        }

        //圖形工具按鈕被按下
        private void ToolButtonClick(object sender, EventArgs e)
        {
            ToolStripButton button = sender as ToolStripButton;
            _presentationModel.ToolButtonClickHandler(button.Text);
        }

        //滑鼠進入繪圖區
        private void EnterFromMouse(object sender, EventArgs e)
        {
            this.KeyDown += PressKeyboardKey;
        }

        //滑鼠離開繪圖區
        private void LeaveFromMouse(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
            this.KeyDown -= PressKeyboardKey;
        }

        //滑鼠被按下
        public void CanvasPressed(object sender, MouseEventArgs e)
        {
            _presentationModel.CanvasPressedHandler(e.X, e.Y, _canvas.Width);
        }

        //滑鼠移動
        public void CanvasMoved(object sender, MouseEventArgs e)
        {
            _presentationModel.CanvasMoveHandler(e.X, e.Y, _canvas.Width);
            Cursor = _presentationModel.UpdateCursor();
        }

        //滑鼠釋放
        public void ReleasedCanvas(object sender, MouseEventArgs e)
        {
            _presentationModel.CanvasReleasedHandler(e.X, e.Y);
        }

        //在繪圖區內鍵盤按下
        private void PressKeyboardKey(object sender, KeyEventArgs e)
        {
            _presentationModel.PressKeyboardHandler(e.KeyCode);
        }

        //滑鼠進入縮圖區
        private void EnterSlideMouse(object sender, EventArgs e)
        {
            this.KeyDown += PressKeyboardKeySlide;
        }

        //滑鼠離開縮圖區
        private void LeaveSlideMouse(object sender, EventArgs e)
        {
            this.KeyDown -= PressKeyboardKeySlide;
        }

        //復原按鈕被按下
        private void UndoToolButtonClick(object sender, EventArgs e)
        {
            _presentationModel.UndoToolButtonClickHandler();
        }

        //重做按鈕被按下
        private void RedoToolButtonClick(object sender, EventArgs e)
        {
            _presentationModel.RedoToolButtonClickHandler();
        }

        //縮圖被按下
        public void SlideClick(object sender, EventArgs e)
        {
            SlideButton clickedButton = sender as SlideButton;
            foreach (Control control in _flowLayoutPanel.Controls)
            {
                SlideButton button = control as SlideButton;
                button.Checked = false;
            }
            clickedButton.Checked = true;
            _presentationModel.ClickSlideButtonHandler(_flowLayoutPanel.Controls.IndexOf(clickedButton));
            _shapeDataGridView.DataSource = _model.ShapeList;
        }

        //建立新頁面按鈕被按下
        private void ClickNewPageButton(object sender, EventArgs e)
        {
            _presentationModel.ClickNewPageButtonHandler();
        }

        //在縮圖區內鍵盤按下
        private void PressKeyboardKeySlide(object sender, KeyEventArgs e)
        {
            int total = _flowLayoutPanel.Controls.Count;
            for (int i = total - 1; i >= 0; i--)
            {
                SlideButton button = (SlideButton)_flowLayoutPanel.Controls[i];
                _presentationModel.PressKeyboardSlideHandler(e.KeyCode, button.Checked, i, total);
            }
        }

        //載入按鈕被按下
        private void ClickLoadToolButton(object sender, EventArgs e)
        {
            using (LoadDialog loadDialog = new LoadDialog(_model))
            {
                DialogResult result = loadDialog.ShowDialog();
            }
        }

        //儲存按鈕被按下
        private async void ClickSaveToolButton(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                using (SaveDialog loadDialog = new SaveDialog(_model))
                {
                    DialogResult result = loadDialog.ShowDialog();
                }
            });
        }

        //視窗大小重新繪製
        private void ResizeWindow(object sender, EventArgs e)
        {
            foreach (Control control in _flowLayoutPanel.Controls)
            {
                SlideButton button = control as SlideButton;
                int[] size = _presentationModel.ResizeSlide(_flowLayoutPanel.Width);
                button.Width = size[0];
                button.Height = size[1];
            }
            _canvas.Height = _presentationModel.ResizeWindow(_canvas.Width);
            _drawSplitContainer.Panel1.Padding = new Padding(WINDOW_PADDING, _presentationModel.RepositionWindow(_drawSplitContainer.Height, _canvas.Height), WINDOW_PADDING, 0);
            _canvas.Invalidate(true);
        }

        //繪圖區重繪製
        public void CanvasPaint(object sender, PaintEventArgs e)
        {
            _presentationModel.CanvasDraw(e.Graphics, _canvas.Width);
        }

        //縮圖區重繪製
        public void SlidePaint(object sender, PaintEventArgs e)
        {
            SlideButton button = sender as SlideButton;
            _presentationModel.SlideDraw(e.Graphics, _slideButton.Width, _flowLayoutPanel.Controls.IndexOf(button));
        }

        //加入頁面
        public void AddPage()
        {
            SlideButton newButton = new SlideButton();
            newButton.Paint += SlidePaint;
            newButton.Click += SlideClick;
            newButton.MouseEnter += EnterSlideMouse;
            newButton.MouseLeave += LeaveSlideMouse;
            _flowLayoutPanel.Controls.Add(newButton);
            foreach (Control control in _flowLayoutPanel.Controls)
            {
                SlideButton button = control as SlideButton;
                int[] size = _presentationModel.ResizeSlide(_flowLayoutPanel.Width);
                button.Width = size[0];
                button.Height = size[1];
                button.Checked = false;
            }
            newButton.Checked = true;
        }

        //刪除頁面
        public void DeletePage(int index)
        {
            _flowLayoutPanel.Controls.RemoveAt(index);
        }

        //模型改變
        public void ChangeModel(int index)
        {
            _canvas.Invalidate(true);
            _flowLayoutPanel.Controls[index].Invalidate(true);
        }
    }
}

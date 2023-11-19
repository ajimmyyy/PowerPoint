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
        const string TOOL_BUTTON_LINE = "IsLinePressed";
        const string TOOL_BUTTON_RECTANGLE = "IsRectanglePressed";
        const string TOOL_BUTTON_CIRCLE = "IsCirclePressed";
        const string TOOL_BUTTON_SELECT = "IsSelectPressed";

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
            _canvas.KeyDown += PressKeyboardKey;
            Controls.Add(_canvas);

            _slideButton.Paint += SlidePaint;

            this.KeyDown += PressKeyboardKey;
            _shapeDataGridView.CellClick += new DataGridViewCellEventHandler(DeleteCellClick);

            _model = new Model();
            _presentationModel = new PresentationModel(_model);
            _shapeDataGridView.DataSource = _model.ShapeList;
            _lineToolButton.DataBindings.Add(TOOL_BUTTON_CHECK, _presentationModel, TOOL_BUTTON_LINE);
            _rectangleToolButton.DataBindings.Add(TOOL_BUTTON_CHECK, _presentationModel, TOOL_BUTTON_RECTANGLE);
            _circleToolButton.DataBindings.Add(TOOL_BUTTON_CHECK, _presentationModel, TOOL_BUTTON_CIRCLE);
            _selectToolButton.DataBindings.Add(TOOL_BUTTON_CHECK, _presentationModel, TOOL_BUTTON_SELECT);
            _model._modelChanged += ChangeModel;
        }

        //DataGridView新增按鈕被按下
        private void AddButtonClick(object sender, EventArgs e)
        {
            _model.AddButtonClickEvent(_shapeComboBox.Text);
        }

        //DataGridView刪除按鈕被按下
        private void DeleteCellClick(object sender, DataGridViewCellEventArgs e)
        {
            _model.DeleteButtonClickEvent(e.RowIndex, e.ColumnIndex);
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
            _presentationModel.UpdateCursor();
            Cursor = _presentationModel.CursorNow;
        }

        //滑鼠離開繪圖區
        private void LeaveFromMouse(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        //滑鼠被按下
        public void CanvasPressed(object sender, MouseEventArgs e)
        {
            _presentationModel.CanvasPressedHandler(e.X, e.Y);
        }

        //滑鼠移動
        public void CanvasMoved(object sender, MouseEventArgs e)
        {
            _presentationModel.CanvasMoveHandler(e.X, e.Y);
        }

        //滑鼠釋放
        public void ReleasedCanvas(object sender, MouseEventArgs e)
        {
            _presentationModel.CanvasReleasedHandler(e.X, e.Y);
            Cursor = Cursors.Default;
        }

        //鍵盤按下
        private void PressKeyboardKey(object sender, KeyEventArgs e)
        {
            _presentationModel.PressKeyboardHandler(e.KeyCode);
        }

        //繪圖區重繪製
        public void CanvasPaint(object sender, PaintEventArgs e)
        {
            _presentationModel.CanvasDraw(e.Graphics);
        }

        //縮圖區重繪製
        public void SlidePaint(object sender, PaintEventArgs e)
        {
            _presentationModel.SlideDraw(e.Graphics);
        }

        //模型改變
        public void ChangeModel()
        {
            _canvas.Invalidate(true);
            _slideButton.Invalidate(true);
        }
    }
}

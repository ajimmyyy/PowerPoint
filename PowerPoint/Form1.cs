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
        private Model _model;
        private PresentationModel _presentationModel;
        Panel _canvas = new DoubleBufferedPanel();

        public Form1()
        {
            InitializeComponent();

            _canvas.Dock = DockStyle.Fill;
            _canvas.MouseEnter += FromMouseEnter;
            _canvas.MouseLeave += FromMouseLeave;
            _canvas.MouseDown += CanvasPressed;
            _canvas.MouseUp += CanvasReleased;
            _canvas.MouseMove += CanvasMoved;
            _canvas.Paint += CanvasPaint;
            Controls.Add(_canvas);

            _shapeDataGridView.CellClick += new DataGridViewCellEventHandler(DeleteCellClick);

            _model = new Model();
            _presentationModel = new PresentationModel(_model);
            _model._modelChanged += ModelChanged;
            _presentationModel._toolButtonClick += ToolButtonUpdated;
        }

        //DataGridView新增按鈕被按下
        private void AddButtonClick(object sender, EventArgs e)
        {
            _model.AddButtonClickEvent(_shapeComboBox.Text);
            _shapeDataGridView.DataSource = _model.GetShapesDisplay();
        }

        //DataGridView刪除按鈕被按下
        private void DeleteCellClick(object sender, DataGridViewCellEventArgs e)
        {
            _model.DeleteButtonClickEvent(e.RowIndex, e.ColumnIndex);
            _shapeDataGridView.DataSource = _model.GetShapesDisplay();
        }

        //圖形工具按鈕被按下
        private void ToolButtonClick(object sender, EventArgs e)
        {
            ToolStripButton button = sender as ToolStripButton;
            _presentationModel.ToolButtonClickHandler(button.Text);
        }

        //圖形工具按鈕狀態更新
        private void ToolButtonUpdated(bool chicked1, bool chicked2, bool chicked3)
        {
            _lineToolButton.Checked = chicked1;
            _rectangleToolButton.Checked = chicked2;
            _circleToolButton.Checked = chicked3;
        }

        //滑鼠進入繪圖區
        private void FromMouseEnter(object sender, EventArgs e)
        {
            _presentationModel.UpdateCursor();
            Cursor = _presentationModel.CurrentCursor;
        }

        //滑鼠離開繪圖區
        private void FromMouseLeave(object sender, EventArgs e)
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
            _model.PointerMoved(e.X, e.Y);
        }

        ////滑鼠釋放
        public void CanvasReleased(object sender, MouseEventArgs e)
        {
            _presentationModel.CanvasReleasedHandler(e.X, e.Y);
            _shapeDataGridView.DataSource = _model.GetShapesDisplay();
            Cursor = Cursors.Default;
        }

        public void CanvasPaint(object sender, PaintEventArgs e)
        {
            _presentationModel.Draw(e.Graphics);
        }

        public void ModelChanged()
        {
            Invalidate(true);
        }
    }
}

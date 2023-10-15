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

        public Form1()
        {
            InitializeComponent();
            this._shapeDataGridView.CellClick += new DataGridViewCellEventHandler(DeleteCellClick);
            this._model = new Model();
            this._presentationModel = new PresentationModel(_model);
            this._presentationModel._toolButtonClick += ToolButtonUpdated;
            this.MouseEnter += FromMouseEnter;
            this.MouseLeave += FromMouseLeave;
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

        private void ToolButtonClick(object sender, EventArgs e)
        {
            ToolStripButton button = sender as ToolStripButton;
            _presentationModel.ToolButtonClickHandler(button.Text);
        }

        private void ToolButtonUpdated(bool chicked1, bool chicked2, bool chicked3)
        {
            _lineToolButton.Checked = chicked1;
            _rectangleToolButton.Checked = chicked2;
            _circleToolButton.Checked = chicked3;
        }

        private void FromMouseEnter(object sender, EventArgs e)
        {
            _presentationModel.UpdateCursor();
            Cursor = _presentationModel.CurrentCursor;
        }

        private void FromMouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }
    }
}

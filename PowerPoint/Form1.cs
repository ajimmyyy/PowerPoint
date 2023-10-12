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

        public Form1(Model model)
        {
            InitializeComponent();
            this._shapeDataGridView.CellClick += new DataGridViewCellEventHandler(DeleteCellClick);
            this._model = model;
        }

        //新增按鈕被按下
        private void AddButtonClick(object sender, EventArgs e)
        {
            _model.AddButtonClickEvent(_shapeComboBox.Text);
            _shapeDataGridView.DataSource = _model.GetShapesDisplay();
        }

        //刪除按鈕被按下
        private void DeleteCellClick(object sender, DataGridViewCellEventArgs e)
        {
            _model.DeleteButtonClickEvent(e.RowIndex, e.ColumnIndex);
            _shapeDataGridView.DataSource = _model.GetShapesDisplay();
        }
    }
}

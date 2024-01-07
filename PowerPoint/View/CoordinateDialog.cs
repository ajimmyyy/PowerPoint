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
    public partial class CoordinateDialog : System.Windows.Forms.Form
    {
        const int WINDOW_WIDTH = 1980;
        const int WINDOW_HEIGHT = 1080;
        DialogPresentationModel _presentationModel;

        public CoordinateDialog()
        {
            InitializeComponent();
            _leftTopXBox.TextChanged += CheckTextBoxChange;
            _leftTopYBox.TextChanged += CheckTextBoxChange;
            _rightBottomXBox.TextChanged += CheckTextBoxChange;
            _rightBottomYBox.TextChanged += CheckTextBoxChange;
            _presentationModel = new DialogPresentationModel();
        }

        //按下OK按鈕
        private void ClickOkButton(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
        
        //案下取消按鈕
        private void ClickCancelButton(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        //輸入改變
        private void CheckTextBoxChange(object sender, EventArgs e)
        {
            string[] coordinate = new string[]
            { 
                _leftTopXBox.Text,
                _leftTopYBox.Text,
                _rightBottomXBox.Text,
                _rightBottomYBox.Text };
            int[] maxRange = new int[]
            { 
                WINDOW_WIDTH,
                WINDOW_HEIGHT,
                WINDOW_WIDTH,
                WINDOW_HEIGHT };
            _okButton.Enabled = _presentationModel.IsValidNumber(coordinate, maxRange);
        }

        //取得輸入座標
        public string[] GetCoordinate()
        {
            return new string[]
            {
                _leftTopXBox.Text,
                _leftTopYBox.Text,
                _rightBottomXBox.Text,
                _rightBottomYBox.Text
            };
        }
    }
}

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

        private void ClickOkButton(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void ClickCancelButton(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

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

        public int[] GetCoordinate()
        {
            return new int[]
            {
                int.Parse(_leftTopXBox.Text),
                int.Parse(_leftTopYBox.Text),
                int.Parse(_rightBottomXBox.Text),
                int.Parse(_rightBottomYBox.Text)
            };
        }
    }
}

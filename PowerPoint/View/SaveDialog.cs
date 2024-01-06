using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PowerPoint
{
    public partial class SaveDialog : Form
    {
        private string _saveFileName;
        GoogleDriveService _service;
        Model _model;

        public SaveDialog(Model model)
        {
            const string APPLICATION_NAME = "DrawAnywhere";
            const string CLIENT_SECRET_FILE_NAME = "clientSecret.json";
            InitializeComponent();
            _model = model;
            _saveFileNameTextBox.TextChanged += ChangeFileNameText;
            _saveButton.Enabled = false;
            _service = new GoogleDriveService(APPLICATION_NAME, CLIENT_SECRET_FILE_NAME);
        }

        //按鈕是否可按下
        private void ChangeFileNameText(object sender, EventArgs e)
        {
            _saveButton.Enabled = !string.IsNullOrEmpty(_saveFileNameTextBox.Text);
        }

        //儲存按鈕被按下
        private void ClickSaveButton(object sender, EventArgs e)
        {
            const string CONTENT_TYPE = "application/json";
            const string FILE_TYPE = ".json";
            string fileName = _saveFileNameTextBox.Text + FILE_TYPE;
            string currentDirectory = System.IO.Directory.GetCurrentDirectory();
            _saveFileName = System.IO.Path.Combine(currentDirectory, fileName);
            _model.SavePages(_saveFileName);
            _service.UploadFile(_saveFileName, CONTENT_TYPE);
            DialogResult = DialogResult.OK;
            Close();
        }

        //取消案按鈕被按下
        private void ClickCancelButton(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}

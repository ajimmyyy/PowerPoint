using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace PowerPoint
{
    public partial class LoadDialog : Form
    {
        private string _loadPath;
        GoogleDriveService _service;
        Model _model;
        const int WAIT_TIME = 1000;

        public LoadDialog(Model model)
        {
            const string APPLICATION_NAME = "DrawAnywhere";
            const string CLIENT_SECRET_FILE_NAME = "clientSecret.json";
            InitializeComponent();
            _model = model;
            _loadButton.Enabled = false;
            _service = new GoogleDriveService(APPLICATION_NAME, CLIENT_SECRET_FILE_NAME);
        }

        //列出跟目錄被按下
        private void ClickListFileOnRootButton(object sender, EventArgs e)
        {
            const string DISPLAY_MEMBER = "Title";
            const string VALUE_MEMBER = "Id";
            const string FILE_TYPE = @"application/vnd.google-apps.folder";
            List<Google.Apis.Drive.v2.Data.File> rootFiles = _service.ListRootFileAndFolder();
            rootFiles.RemoveAll(removeItem =>
            {
                return removeItem.MimeType == FILE_TYPE;
            });

            _fileListBox.DisplayMember = DISPLAY_MEMBER;
            _fileListBox.ValueMember = VALUE_MEMBER;
            _fileListBox.DataSource = rootFiles;
            _loadButton.Enabled = true;
        }

        //載入按鈕被按下
        private void ClickLoadButton(object sender, EventArgs e)
        {
            Google.Apis.Drive.v2.Data.File selectedFile = _fileListBox.SelectedItem as Google.Apis.Drive.v2.Data.File;
            _loadPath = System.IO.Directory.GetCurrentDirectory();
            _service.DownloadFile(selectedFile, _loadPath);
            _model.LoadPages(System.IO.Path.Combine(_loadPath, selectedFile.Title));

            Thread.Sleep(WAIT_TIME);

            DialogResult = DialogResult.OK;
            Close();
        }

        //取消按鈕被按下
        private void ClickCancelButton(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}

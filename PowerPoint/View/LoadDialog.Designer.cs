
namespace PowerPoint
{
    partial class LoadDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._loadGroupBox = new System.Windows.Forms.GroupBox();
            this._loadPanel = new System.Windows.Forms.Panel();
            this._loadTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this._cancelButton = new System.Windows.Forms.Button();
            this._loadButton = new System.Windows.Forms.Button();
            this._fileListBox = new System.Windows.Forms.ListBox();
            this._listFileOnRootButton = new System.Windows.Forms.Button();
            this._loadGroupBox.SuspendLayout();
            this._loadPanel.SuspendLayout();
            this._loadTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _loadGroupBox
            // 
            this._loadGroupBox.Controls.Add(this._loadPanel);
            this._loadGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._loadGroupBox.Location = new System.Drawing.Point(0, 0);
            this._loadGroupBox.Margin = new System.Windows.Forms.Padding(4);
            this._loadGroupBox.Name = "_loadGroupBox";
            this._loadGroupBox.Padding = new System.Windows.Forms.Padding(4);
            this._loadGroupBox.Size = new System.Drawing.Size(300, 226);
            this._loadGroupBox.TabIndex = 2;
            this._loadGroupBox.TabStop = false;
            this._loadGroupBox.Text = "Load";
            // 
            // _loadPanel
            // 
            this._loadPanel.Controls.Add(this._loadTableLayoutPanel);
            this._loadPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._loadPanel.Location = new System.Drawing.Point(4, 26);
            this._loadPanel.Margin = new System.Windows.Forms.Padding(4);
            this._loadPanel.Name = "_loadPanel";
            this._loadPanel.Size = new System.Drawing.Size(292, 196);
            this._loadPanel.TabIndex = 0;
            // 
            // _loadTableLayoutPanel
            // 
            this._loadTableLayoutPanel.ColumnCount = 2;
            this._loadTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this._loadTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this._loadTableLayoutPanel.Controls.Add(this._cancelButton, 1, 2);
            this._loadTableLayoutPanel.Controls.Add(this._loadButton, 1, 1);
            this._loadTableLayoutPanel.Controls.Add(this._fileListBox, 0, 0);
            this._loadTableLayoutPanel.Controls.Add(this._listFileOnRootButton, 1, 0);
            this._loadTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._loadTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this._loadTableLayoutPanel.Margin = new System.Windows.Forms.Padding(4);
            this._loadTableLayoutPanel.Name = "_loadTableLayoutPanel";
            this._loadTableLayoutPanel.RowCount = 3;
            this._loadTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._loadTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this._loadTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._loadTableLayoutPanel.Size = new System.Drawing.Size(292, 196);
            this._loadTableLayoutPanel.TabIndex = 0;
            // 
            // _cancelButton
            // 
            this._cancelButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this._cancelButton.Location = new System.Drawing.Point(176, 124);
            this._cancelButton.Margin = new System.Windows.Forms.Padding(4);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(112, 68);
            this._cancelButton.TabIndex = 8;
            this._cancelButton.Text = "Cancel";
            this._cancelButton.UseVisualStyleBackColor = true;
            this._cancelButton.Click += new System.EventHandler(this.ClickCancelButton);
            // 
            // _loadButton
            // 
            this._loadButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this._loadButton.Location = new System.Drawing.Point(176, 79);
            this._loadButton.Margin = new System.Windows.Forms.Padding(4);
            this._loadButton.Name = "_loadButton";
            this._loadButton.Size = new System.Drawing.Size(112, 37);
            this._loadButton.TabIndex = 3;
            this._loadButton.Text = "Load";
            this._loadButton.UseVisualStyleBackColor = true;
            this._loadButton.Click += new System.EventHandler(this.ClickLoadButton);
            // 
            // _fileListBox
            // 
            this._fileListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._fileListBox.FormattingEnabled = true;
            this._fileListBox.ItemHeight = 18;
            this._fileListBox.Location = new System.Drawing.Point(4, 4);
            this._fileListBox.Margin = new System.Windows.Forms.Padding(4);
            this._fileListBox.Name = "_fileListBox";
            this._loadTableLayoutPanel.SetRowSpan(this._fileListBox, 3);
            this._fileListBox.Size = new System.Drawing.Size(164, 188);
            this._fileListBox.TabIndex = 5;
            // 
            // _listFileOnRootButton
            // 
            this._listFileOnRootButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this._listFileOnRootButton.Location = new System.Drawing.Point(176, 4);
            this._listFileOnRootButton.Margin = new System.Windows.Forms.Padding(4);
            this._listFileOnRootButton.Name = "_listFileOnRootButton";
            this._listFileOnRootButton.Size = new System.Drawing.Size(112, 67);
            this._listFileOnRootButton.TabIndex = 7;
            this._listFileOnRootButton.Text = "List Files On Root ";
            this._listFileOnRootButton.UseVisualStyleBackColor = true;
            this._listFileOnRootButton.Click += new System.EventHandler(this.ClickListFileOnRootButton);
            // 
            // LoadDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 226);
            this.Controls.Add(this._loadGroupBox);
            this.Name = "LoadDialog";
            this.Text = "Load";
            this._loadGroupBox.ResumeLayout(false);
            this._loadPanel.ResumeLayout(false);
            this._loadTableLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox _loadGroupBox;
        private System.Windows.Forms.Panel _loadPanel;
        private System.Windows.Forms.TableLayoutPanel _loadTableLayoutPanel;
        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.Button _loadButton;
        private System.Windows.Forms.ListBox _fileListBox;
        private System.Windows.Forms.Button _listFileOnRootButton;
    }
}
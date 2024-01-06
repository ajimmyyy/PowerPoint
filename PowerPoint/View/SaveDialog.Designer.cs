
namespace PowerPoint
{
    partial class SaveDialog
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
            this._saveTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this._cancelButton = new System.Windows.Forms.Button();
            this._saveLabel = new System.Windows.Forms.Label();
            this._saveFileNameTextBox = new System.Windows.Forms.TextBox();
            this._saveButton = new System.Windows.Forms.Button();
            this._saveTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _saveTableLayoutPanel
            // 
            this._saveTableLayoutPanel.ColumnCount = 3;
            this._saveTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this._saveTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._saveTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this._saveTableLayoutPanel.Controls.Add(this._cancelButton, 2, 1);
            this._saveTableLayoutPanel.Controls.Add(this._saveLabel, 0, 0);
            this._saveTableLayoutPanel.Controls.Add(this._saveFileNameTextBox, 1, 0);
            this._saveTableLayoutPanel.Controls.Add(this._saveButton, 2, 0);
            this._saveTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._saveTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this._saveTableLayoutPanel.Margin = new System.Windows.Forms.Padding(4);
            this._saveTableLayoutPanel.Name = "_saveTableLayoutPanel";
            this._saveTableLayoutPanel.RowCount = 2;
            this._saveTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._saveTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._saveTableLayoutPanel.Size = new System.Drawing.Size(300, 266);
            this._saveTableLayoutPanel.TabIndex = 2;
            // 
            // _cancelButton
            // 
            this._cancelButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this._cancelButton.Location = new System.Drawing.Point(229, 137);
            this._cancelButton.Margin = new System.Windows.Forms.Padding(4);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(67, 125);
            this._cancelButton.TabIndex = 4;
            this._cancelButton.Text = "Cancel";
            this._cancelButton.UseVisualStyleBackColor = true;
            this._cancelButton.Click += new System.EventHandler(this.ClickCancelButton);
            // 
            // _saveLabel
            // 
            this._saveLabel.AutoSize = true;
            this._saveLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this._saveLabel.Location = new System.Drawing.Point(12, 0);
            this._saveLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._saveLabel.Name = "_saveLabel";
            this._saveLabel.Size = new System.Drawing.Size(59, 133);
            this._saveLabel.TabIndex = 0;
            this._saveLabel.Text = "File Name :";
            this._saveLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _saveFileNameTextBox
            // 
            this._saveFileNameTextBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._saveFileNameTextBox.Location = new System.Drawing.Point(79, 100);
            this._saveFileNameTextBox.Margin = new System.Windows.Forms.Padding(4);
            this._saveFileNameTextBox.Name = "_saveFileNameTextBox";
            this._saveFileNameTextBox.Size = new System.Drawing.Size(142, 29);
            this._saveFileNameTextBox.TabIndex = 1;
            // 
            // _saveButton
            // 
            this._saveButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this._saveButton.Location = new System.Drawing.Point(229, 4);
            this._saveButton.Margin = new System.Windows.Forms.Padding(4);
            this._saveButton.Name = "_saveButton";
            this._saveButton.Size = new System.Drawing.Size(67, 125);
            this._saveButton.TabIndex = 3;
            this._saveButton.Text = "Save";
            this._saveButton.UseVisualStyleBackColor = true;
            this._saveButton.Click += new System.EventHandler(this.ClickSaveButton);
            // 
            // SaveDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 266);
            this.Controls.Add(this._saveTableLayoutPanel);
            this.Name = "SaveDialog";
            this.Text = "Save";
            this._saveTableLayoutPanel.ResumeLayout(false);
            this._saveTableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel _saveTableLayoutPanel;
        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.Label _saveLabel;
        private System.Windows.Forms.TextBox _saveFileNameTextBox;
        private System.Windows.Forms.Button _saveButton;
    }
}
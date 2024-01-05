
namespace PowerPoint
{
    partial class CoordinateDialog
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
            this._leftTopXBox = new System.Windows.Forms.TextBox();
            this._leftTopYBox = new System.Windows.Forms.TextBox();
            this._rightBottomYBox = new System.Windows.Forms.TextBox();
            this._rightBottomXBox = new System.Windows.Forms.TextBox();
            this._okButton = new System.Windows.Forms.Button();
            this._cancelButton = new System.Windows.Forms.Button();
            this._leftTopXLabel = new System.Windows.Forms.Label();
            this._leftTopYLabel = new System.Windows.Forms.Label();
            this._rightBottomXLabel = new System.Windows.Forms.Label();
            this._rightBottomYLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _leftTopXBox
            // 
            this._leftTopXBox.Location = new System.Drawing.Point(29, 68);
            this._leftTopXBox.Margin = new System.Windows.Forms.Padding(20, 3, 20, 3);
            this._leftTopXBox.Name = "_leftTopXBox";
            this._leftTopXBox.Size = new System.Drawing.Size(147, 29);
            this._leftTopXBox.TabIndex = 0;
            // 
            // _leftTopYBox
            // 
            this._leftTopYBox.Location = new System.Drawing.Point(216, 68);
            this._leftTopYBox.Margin = new System.Windows.Forms.Padding(20, 3, 20, 3);
            this._leftTopYBox.Name = "_leftTopYBox";
            this._leftTopYBox.Size = new System.Drawing.Size(147, 29);
            this._leftTopYBox.TabIndex = 1;
            // 
            // _rightBottomYBox
            // 
            this._rightBottomYBox.Location = new System.Drawing.Point(216, 168);
            this._rightBottomYBox.Margin = new System.Windows.Forms.Padding(20, 3, 20, 3);
            this._rightBottomYBox.Name = "_rightBottomYBox";
            this._rightBottomYBox.Size = new System.Drawing.Size(147, 29);
            this._rightBottomYBox.TabIndex = 3;
            // 
            // _rightBottomXBox
            // 
            this._rightBottomXBox.Location = new System.Drawing.Point(29, 168);
            this._rightBottomXBox.Margin = new System.Windows.Forms.Padding(20, 3, 20, 3);
            this._rightBottomXBox.Name = "_rightBottomXBox";
            this._rightBottomXBox.Size = new System.Drawing.Size(147, 29);
            this._rightBottomXBox.TabIndex = 2;
            // 
            // _okButton
            // 
            this._okButton.Enabled = false;
            this._okButton.Location = new System.Drawing.Point(29, 250);
            this._okButton.Name = "_okButton";
            this._okButton.Size = new System.Drawing.Size(147, 34);
            this._okButton.TabIndex = 4;
            this._okButton.Text = "OK";
            this._okButton.UseVisualStyleBackColor = true;
            this._okButton.Click += new System.EventHandler(this.ClickOkButton);
            // 
            // _cancelButton
            // 
            this._cancelButton.Location = new System.Drawing.Point(216, 250);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(147, 34);
            this._cancelButton.TabIndex = 5;
            this._cancelButton.Text = "Cancel";
            this._cancelButton.UseVisualStyleBackColor = true;
            this._cancelButton.Click += new System.EventHandler(this.ClickCancelButton);
            // 
            // _leftTopXLabel
            // 
            this._leftTopXLabel.AutoSize = true;
            this._leftTopXLabel.BackColor = System.Drawing.SystemColors.Control;
            this._leftTopXLabel.Font = new System.Drawing.Font("微軟正黑體", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._leftTopXLabel.Location = new System.Drawing.Point(24, 40);
            this._leftTopXLabel.Name = "_leftTopXLabel";
            this._leftTopXLabel.Size = new System.Drawing.Size(125, 25);
            this._leftTopXLabel.TabIndex = 6;
            this._leftTopXLabel.Text = "左上角座標X";
            // 
            // _leftTopYLabel
            // 
            this._leftTopYLabel.AutoSize = true;
            this._leftTopYLabel.BackColor = System.Drawing.SystemColors.Control;
            this._leftTopYLabel.Font = new System.Drawing.Font("微軟正黑體", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._leftTopYLabel.Location = new System.Drawing.Point(211, 40);
            this._leftTopYLabel.Name = "_leftTopYLabel";
            this._leftTopYLabel.Size = new System.Drawing.Size(124, 25);
            this._leftTopYLabel.TabIndex = 7;
            this._leftTopYLabel.Text = "左上角座標Y";
            // 
            // _rightBottomXLabel
            // 
            this._rightBottomXLabel.AutoSize = true;
            this._rightBottomXLabel.BackColor = System.Drawing.SystemColors.Control;
            this._rightBottomXLabel.Font = new System.Drawing.Font("微軟正黑體", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._rightBottomXLabel.Location = new System.Drawing.Point(24, 140);
            this._rightBottomXLabel.Name = "_rightBottomXLabel";
            this._rightBottomXLabel.Size = new System.Drawing.Size(125, 25);
            this._rightBottomXLabel.TabIndex = 8;
            this._rightBottomXLabel.Text = "右下角座標X";
            // 
            // _rightBottomYLabel
            // 
            this._rightBottomYLabel.AutoSize = true;
            this._rightBottomYLabel.BackColor = System.Drawing.SystemColors.Control;
            this._rightBottomYLabel.Font = new System.Drawing.Font("微軟正黑體", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._rightBottomYLabel.Location = new System.Drawing.Point(211, 140);
            this._rightBottomYLabel.Name = "_rightBottomYLabel";
            this._rightBottomYLabel.Size = new System.Drawing.Size(124, 25);
            this._rightBottomYLabel.TabIndex = 9;
            this._rightBottomYLabel.Text = "右下角座標Y";
            // 
            // CoordinateDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 302);
            this.Controls.Add(this._rightBottomYLabel);
            this.Controls.Add(this._rightBottomXLabel);
            this.Controls.Add(this._leftTopYLabel);
            this.Controls.Add(this._leftTopXLabel);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this._okButton);
            this.Controls.Add(this._rightBottomYBox);
            this.Controls.Add(this._rightBottomXBox);
            this.Controls.Add(this._leftTopYBox);
            this.Controls.Add(this._leftTopXBox);
            this.Name = "CoordinateDialog";
            this.Text = "CoordinateDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox _leftTopXBox;
        private System.Windows.Forms.TextBox _leftTopYBox;
        private System.Windows.Forms.TextBox _rightBottomYBox;
        private System.Windows.Forms.TextBox _rightBottomXBox;
        private System.Windows.Forms.Button _okButton;
        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.Label _leftTopXLabel;
        private System.Windows.Forms.Label _leftTopYLabel;
        private System.Windows.Forms.Label _rightBottomXLabel;
        private System.Windows.Forms.Label _rightBottomYLabel;
    }
}
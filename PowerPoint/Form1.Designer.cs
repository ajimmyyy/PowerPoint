
namespace PowerPoint
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this._functionMenu = new System.Windows.Forms.MenuStrip();
            this._illustrateMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._aboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._slideDataGridView = new System.Windows.Forms.DataGridView();
            this._dataGroupBox = new System.Windows.Forms.GroupBox();
            this._addButton = new System.Windows.Forms.Button();
            this._shapeComboBox = new System.Windows.Forms.ComboBox();
            this._shapeDataGridView = new System.Windows.Forms.DataGridView();
            this._deleteColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this._shapeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._infoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._slideButton1 = new System.Windows.Forms.Button();
            this._slideButton2 = new System.Windows.Forms.Button();
            this._functionMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._slideDataGridView)).BeginInit();
            this._dataGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._shapeDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // _functionMenu
            // 
            this._functionMenu.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this._functionMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this._functionMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._illustrateMenuItem});
            this._functionMenu.Location = new System.Drawing.Point(0, 0);
            this._functionMenu.Name = "_functionMenu";
            this._functionMenu.Size = new System.Drawing.Size(800, 36);
            this._functionMenu.TabIndex = 0;
            this._functionMenu.Text = "menuStrip1";
            // 
            // _illustrateMenuItem
            // 
            this._illustrateMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._aboutMenuItem});
            this._illustrateMenuItem.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this._illustrateMenuItem.Name = "_illustrateMenuItem";
            this._illustrateMenuItem.Size = new System.Drawing.Size(62, 30);
            this._illustrateMenuItem.Text = "說明";
            // 
            // _aboutMenuItem
            // 
            this._aboutMenuItem.Name = "_aboutMenuItem";
            this._aboutMenuItem.Size = new System.Drawing.Size(270, 34);
            this._aboutMenuItem.Text = "關於";
            // 
            // _slideDataGridView
            // 
            this._slideDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._slideDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._slideDataGridView.Dock = System.Windows.Forms.DockStyle.Left;
            this._slideDataGridView.Location = new System.Drawing.Point(0, 36);
            this._slideDataGridView.Name = "_slideDataGridView";
            this._slideDataGridView.RowHeadersWidth = 62;
            this._slideDataGridView.RowTemplate.Height = 31;
            this._slideDataGridView.Size = new System.Drawing.Size(161, 467);
            this._slideDataGridView.TabIndex = 1;
            // 
            // _dataGroupBox
            // 
            this._dataGroupBox.BackColor = System.Drawing.SystemColors.Window;
            this._dataGroupBox.Controls.Add(this._addButton);
            this._dataGroupBox.Controls.Add(this._shapeComboBox);
            this._dataGroupBox.Controls.Add(this._shapeDataGridView);
            this._dataGroupBox.Dock = System.Windows.Forms.DockStyle.Right;
            this._dataGroupBox.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._dataGroupBox.Location = new System.Drawing.Point(561, 36);
            this._dataGroupBox.Name = "_dataGroupBox";
            this._dataGroupBox.Padding = new System.Windows.Forms.Padding(3, 50, 3, 3);
            this._dataGroupBox.Size = new System.Drawing.Size(239, 467);
            this._dataGroupBox.TabIndex = 4;
            this._dataGroupBox.TabStop = false;
            this._dataGroupBox.Text = "資料顯示";
            // 
            // _addButton
            // 
            this._addButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this._addButton.FlatAppearance.BorderSize = 0;
            this._addButton.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._addButton.Location = new System.Drawing.Point(6, 20);
            this._addButton.Name = "_addButton";
            this._addButton.Size = new System.Drawing.Size(60, 39);
            this._addButton.TabIndex = 0;
            this._addButton.Text = "新增";
            this._addButton.UseVisualStyleBackColor = false;
            this._addButton.Click += new System.EventHandler(this.AddButtonClick);
            // 
            // _shapeComboBox
            // 
            this._shapeComboBox.FormattingEnabled = true;
            this._shapeComboBox.Items.AddRange(new object[] {
            "矩形",
            "線"});
            this._shapeComboBox.Location = new System.Drawing.Point(72, 28);
            this._shapeComboBox.Name = "_shapeComboBox";
            this._shapeComboBox.Size = new System.Drawing.Size(121, 31);
            this._shapeComboBox.TabIndex = 1;
            // 
            // _shapeDataGridView
            // 
            this._shapeDataGridView.AllowUserToAddRows = false;
            this._shapeDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._shapeDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._deleteColumn,
            this._shapeColumn,
            this._infoColumn});
            this._shapeDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._shapeDataGridView.Location = new System.Drawing.Point(3, 74);
            this._shapeDataGridView.Name = "_shapeDataGridView";
            this._shapeDataGridView.RowHeadersVisible = false;
            this._shapeDataGridView.RowHeadersWidth = 62;
            this._shapeDataGridView.RowTemplate.Height = 31;
            this._shapeDataGridView.Size = new System.Drawing.Size(233, 390);
            this._shapeDataGridView.TabIndex = 2;
            // 
            // _deleteColumn
            // 
            this._deleteColumn.DataPropertyName = "_column1";
            this._deleteColumn.HeaderText = "刪除";
            this._deleteColumn.MinimumWidth = 8;
            this._deleteColumn.Name = "_deleteColumn";
            this._deleteColumn.ReadOnly = true;
            this._deleteColumn.Width = 40;
            // 
            // _shapeColumn
            // 
            this._shapeColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this._shapeColumn.DataPropertyName = "_column2";
            this._shapeColumn.HeaderText = "形狀";
            this._shapeColumn.MinimumWidth = 8;
            this._shapeColumn.Name = "_shapeColumn";
            this._shapeColumn.ReadOnly = true;
            this._shapeColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this._shapeColumn.Width = 40;
            // 
            // _infoColumn
            // 
            this._infoColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this._infoColumn.DataPropertyName = "_column3";
            this._infoColumn.HeaderText = "資訊";
            this._infoColumn.MinimumWidth = 8;
            this._infoColumn.Name = "_infoColumn";
            this._infoColumn.ReadOnly = true;
            this._infoColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this._infoColumn.Width = 150;
            // 
            // _slideButton1
            // 
            this._slideButton1.FlatAppearance.BorderSize = 0;
            this._slideButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._slideButton1.Location = new System.Drawing.Point(0, 34);
            this._slideButton1.Name = "_slideButton1";
            this._slideButton1.Size = new System.Drawing.Size(146, 86);
            this._slideButton1.TabIndex = 5;
            this._slideButton1.UseVisualStyleBackColor = true;
            // 
            // _slideButton2
            // 
            this._slideButton2.FlatAppearance.BorderSize = 0;
            this._slideButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._slideButton2.Location = new System.Drawing.Point(0, 126);
            this._slideButton2.Name = "_slideButton2";
            this._slideButton2.Size = new System.Drawing.Size(146, 86);
            this._slideButton2.TabIndex = 6;
            this._slideButton2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(800, 503);
            this.Controls.Add(this._slideButton2);
            this.Controls.Add(this._slideButton1);
            this.Controls.Add(this._dataGroupBox);
            this.Controls.Add(this._slideDataGridView);
            this.Controls.Add(this._functionMenu);
            this.MainMenuStrip = this._functionMenu;
            this.Name = "Form1";
            this.Text = "HW2";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this._functionMenu.ResumeLayout(false);
            this._functionMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._slideDataGridView)).EndInit();
            this._dataGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._shapeDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip _functionMenu;
        private System.Windows.Forms.ToolStripMenuItem _illustrateMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _aboutMenuItem;
        private System.Windows.Forms.DataGridView _slideDataGridView;
        private System.Windows.Forms.GroupBox _dataGroupBox;
        private System.Windows.Forms.Button _addButton;
        private System.Windows.Forms.ComboBox _shapeComboBox;
        private System.Windows.Forms.DataGridView _shapeDataGridView;
        private System.Windows.Forms.Button _slideButton1;
        private System.Windows.Forms.Button _slideButton2;
        private System.Windows.Forms.DataGridViewButtonColumn _deleteColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn _shapeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn _infoColumn;
    }
}


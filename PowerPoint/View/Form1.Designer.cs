
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this._functionMenu = new System.Windows.Forms.MenuStrip();
            this._illustrateMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._aboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._dataGroupBox = new System.Windows.Forms.GroupBox();
            this._addButton = new System.Windows.Forms.Button();
            this._shapeComboBox = new System.Windows.Forms.ComboBox();
            this._shapeDataGridView = new System.Windows.Forms.DataGridView();
            this._deleteColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this._shapeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._infoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._windowSplitContainer = new System.Windows.Forms.SplitContainer();
            this._slideButton = new System.Windows.Forms.Button();
            this._drawSplitContainer = new System.Windows.Forms.SplitContainer();
            this._toolBar = new System.Windows.Forms.ToolStrip();
            this._backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this._canvas = new PowerPoint.DoubleBufferedPanel();
            this._lineToolButton = new PowerPoint.BindingToolStripButton();
            this._rectangleToolButton = new PowerPoint.BindingToolStripButton();
            this._circleToolButton = new PowerPoint.BindingToolStripButton();
            this._selectToolButton = new PowerPoint.BindingToolStripButton();
            this._undoToolButton = new PowerPoint.BindingToolStripButton();
            this._redoToolButton = new PowerPoint.BindingToolStripButton();
            this._functionMenu.SuspendLayout();
            this._dataGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._shapeDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._windowSplitContainer)).BeginInit();
            this._windowSplitContainer.Panel1.SuspendLayout();
            this._windowSplitContainer.Panel2.SuspendLayout();
            this._windowSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._drawSplitContainer)).BeginInit();
            this._drawSplitContainer.Panel1.SuspendLayout();
            this._drawSplitContainer.Panel2.SuspendLayout();
            this._drawSplitContainer.SuspendLayout();
            this._toolBar.SuspendLayout();
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
            this._illustrateMenuItem.Size = new System.Drawing.Size(62, 32);
            this._illustrateMenuItem.Text = "說明";
            // 
            // _aboutMenuItem
            // 
            this._aboutMenuItem.Name = "_aboutMenuItem";
            this._aboutMenuItem.Size = new System.Drawing.Size(146, 34);
            this._aboutMenuItem.Text = "關於";
            // 
            // _dataGroupBox
            // 
            this._dataGroupBox.BackColor = System.Drawing.SystemColors.Window;
            this._dataGroupBox.Controls.Add(this._addButton);
            this._dataGroupBox.Controls.Add(this._shapeComboBox);
            this._dataGroupBox.Controls.Add(this._shapeDataGridView);
            this._dataGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dataGroupBox.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._dataGroupBox.Location = new System.Drawing.Point(0, 0);
            this._dataGroupBox.Name = "_dataGroupBox";
            this._dataGroupBox.Padding = new System.Windows.Forms.Padding(3, 50, 3, 3);
            this._dataGroupBox.Size = new System.Drawing.Size(224, 429);
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
            this._shapeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._shapeComboBox.FormattingEnabled = true;
            this._shapeComboBox.Items.AddRange(new object[] {
            "線",
            "矩形",
            "圓形"});
            this._shapeComboBox.Location = new System.Drawing.Point(72, 28);
            this._shapeComboBox.Name = "_shapeComboBox";
            this._shapeComboBox.Size = new System.Drawing.Size(146, 31);
            this._shapeComboBox.TabIndex = 1;
            // 
            // _shapeDataGridView
            // 
            this._shapeDataGridView.AllowUserToAddRows = false;
            this._shapeDataGridView.AllowUserToDeleteRows = false;
            this._shapeDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._shapeDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._deleteColumn,
            this._shapeColumn,
            this._infoColumn});
            this._shapeDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._shapeDataGridView.Location = new System.Drawing.Point(3, 74);
            this._shapeDataGridView.Name = "_shapeDataGridView";
            this._shapeDataGridView.ReadOnly = true;
            this._shapeDataGridView.RowHeadersVisible = false;
            this._shapeDataGridView.RowHeadersWidth = 62;
            this._shapeDataGridView.RowTemplate.Height = 31;
            this._shapeDataGridView.Size = new System.Drawing.Size(218, 352);
            this._shapeDataGridView.TabIndex = 2;
            // 
            // _deleteColumn
            // 
            this._deleteColumn.DataPropertyName = "_column1";
            this._deleteColumn.HeaderText = "刪除";
            this._deleteColumn.MinimumWidth = 8;
            this._deleteColumn.Name = "_deleteColumn";
            this._deleteColumn.ReadOnly = true;
            this._deleteColumn.Text = "刪除";
            this._deleteColumn.UseColumnTextForButtonValue = true;
            this._deleteColumn.Width = 40;
            // 
            // _shapeColumn
            // 
            this._shapeColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this._shapeColumn.DataPropertyName = "ShapeName";
            this._shapeColumn.HeaderText = "形狀";
            this._shapeColumn.MinimumWidth = 8;
            this._shapeColumn.Name = "_shapeColumn";
            this._shapeColumn.ReadOnly = true;
            this._shapeColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this._shapeColumn.Width = 40;
            // 
            // _infoColumn
            // 
            this._infoColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this._infoColumn.DataPropertyName = "Info";
            this._infoColumn.HeaderText = "資訊";
            this._infoColumn.MinimumWidth = 8;
            this._infoColumn.Name = "_infoColumn";
            this._infoColumn.ReadOnly = true;
            this._infoColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // _windowSplitContainer
            // 
            this._windowSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this._windowSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this._windowSplitContainer.Location = new System.Drawing.Point(0, 74);
            this._windowSplitContainer.Name = "_windowSplitContainer";
            // 
            // _windowSplitContainer.Panel1
            // 
            this._windowSplitContainer.Panel1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this._windowSplitContainer.Panel1.Controls.Add(this._slideButton);
            this._windowSplitContainer.Panel1MinSize = 214;
            // 
            // _windowSplitContainer.Panel2
            // 
            this._windowSplitContainer.Panel2.Controls.Add(this._drawSplitContainer);
            this._windowSplitContainer.Size = new System.Drawing.Size(800, 429);
            this._windowSplitContainer.SplitterDistance = 214;
            this._windowSplitContainer.TabIndex = 0;
            // 
            // _slideButton
            // 
            this._slideButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._slideButton.BackColor = System.Drawing.SystemColors.Window;
            this._slideButton.FlatAppearance.BorderSize = 0;
            this._slideButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._slideButton.Location = new System.Drawing.Point(3, 3);
            this._slideButton.Name = "_slideButton";
            this._slideButton.Size = new System.Drawing.Size(208, 117);
            this._slideButton.TabIndex = 5;
            this._slideButton.UseVisualStyleBackColor = false;
            // 
            // _drawSplitContainer
            // 
            this._drawSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this._drawSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this._drawSplitContainer.Location = new System.Drawing.Point(0, 0);
            this._drawSplitContainer.Name = "_drawSplitContainer";
            // 
            // _drawSplitContainer.Panel1
            // 
            this._drawSplitContainer.Panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this._drawSplitContainer.Panel1.Controls.Add(this._canvas);
            this._drawSplitContainer.Panel1.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this._drawSplitContainer.Panel1MinSize = 20;
            // 
            // _drawSplitContainer.Panel2
            // 
            this._drawSplitContainer.Panel2.Controls.Add(this._dataGroupBox);
            this._drawSplitContainer.Panel2MinSize = 224;
            this._drawSplitContainer.Size = new System.Drawing.Size(582, 429);
            this._drawSplitContainer.SplitterDistance = 354;
            this._drawSplitContainer.TabIndex = 0;
            // 
            // _toolBar
            // 
            this._toolBar.GripMargin = new System.Windows.Forms.Padding(0);
            this._toolBar.ImageScalingSize = new System.Drawing.Size(24, 24);
            this._toolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._lineToolButton,
            this._rectangleToolButton,
            this._circleToolButton,
            this._selectToolButton,
            this._undoToolButton,
            this._redoToolButton});
            this._toolBar.Location = new System.Drawing.Point(0, 36);
            this._toolBar.Name = "_toolBar";
            this._toolBar.Size = new System.Drawing.Size(800, 38);
            this._toolBar.TabIndex = 7;
            this._toolBar.Text = "toolStrip1";
            // 
            // _canvas
            // 
            this._canvas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._canvas.BackColor = System.Drawing.SystemColors.Window;
            this._canvas.Location = new System.Drawing.Point(10, 0);
            this._canvas.Margin = new System.Windows.Forms.Padding(0);
            this._canvas.Name = "_canvas";
            this._canvas.Size = new System.Drawing.Size(334, 188);
            this._canvas.TabIndex = 0;
            // 
            // _lineToolButton
            // 
            this._lineToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._lineToolButton.Image = ((System.Drawing.Image)(resources.GetObject("_lineToolButton.Image")));
            this._lineToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._lineToolButton.Name = "_lineToolButton";
            this._lineToolButton.Size = new System.Drawing.Size(34, 33);
            this._lineToolButton.Text = "線";
            this._lineToolButton.Click += new System.EventHandler(this.ToolButtonClick);
            // 
            // _rectangleToolButton
            // 
            this._rectangleToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._rectangleToolButton.Image = ((System.Drawing.Image)(resources.GetObject("_rectangleToolButton.Image")));
            this._rectangleToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._rectangleToolButton.Name = "_rectangleToolButton";
            this._rectangleToolButton.Size = new System.Drawing.Size(34, 33);
            this._rectangleToolButton.Text = "矩形";
            this._rectangleToolButton.Click += new System.EventHandler(this.ToolButtonClick);
            // 
            // _circleToolButton
            // 
            this._circleToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._circleToolButton.Image = ((System.Drawing.Image)(resources.GetObject("_circleToolButton.Image")));
            this._circleToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._circleToolButton.Name = "_circleToolButton";
            this._circleToolButton.Size = new System.Drawing.Size(34, 33);
            this._circleToolButton.Text = "圓形";
            this._circleToolButton.Click += new System.EventHandler(this.ToolButtonClick);
            // 
            // _selectToolButton
            // 
            this._selectToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._selectToolButton.Image = ((System.Drawing.Image)(resources.GetObject("_selectToolButton.Image")));
            this._selectToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._selectToolButton.Name = "_selectToolButton";
            this._selectToolButton.Size = new System.Drawing.Size(34, 33);
            this._selectToolButton.Text = "選取";
            this._selectToolButton.Click += new System.EventHandler(this.ToolButtonClick);
            // 
            // _undoToolButton
            // 
            this._undoToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._undoToolButton.Enabled = false;
            this._undoToolButton.Image = ((System.Drawing.Image)(resources.GetObject("_undoToolButton.Image")));
            this._undoToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._undoToolButton.Name = "_undoToolButton";
            this._undoToolButton.Size = new System.Drawing.Size(34, 33);
            this._undoToolButton.Text = "復原";
            this._undoToolButton.Click += new System.EventHandler(this.UndoToolButtonClick);
            // 
            // _redoToolButton
            // 
            this._redoToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._redoToolButton.Enabled = false;
            this._redoToolButton.Image = ((System.Drawing.Image)(resources.GetObject("_redoToolButton.Image")));
            this._redoToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._redoToolButton.Name = "_redoToolButton";
            this._redoToolButton.Size = new System.Drawing.Size(34, 33);
            this._redoToolButton.Text = "重做";
            this._redoToolButton.Click += new System.EventHandler(this.RedoToolButtonClick);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(800, 503);
            this.Controls.Add(this._windowSplitContainer);
            this.Controls.Add(this._toolBar);
            this.Controls.Add(this._functionMenu);
            this.KeyPreview = true;
            this.MainMenuStrip = this._functionMenu;
            this.Name = "Form1";
            this.Text = "HW2";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this._functionMenu.ResumeLayout(false);
            this._functionMenu.PerformLayout();
            this._dataGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._shapeDataGridView)).EndInit();
            this._windowSplitContainer.Panel1.ResumeLayout(false);
            this._windowSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._windowSplitContainer)).EndInit();
            this._windowSplitContainer.ResumeLayout(false);
            this._drawSplitContainer.Panel1.ResumeLayout(false);
            this._drawSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._drawSplitContainer)).EndInit();
            this._drawSplitContainer.ResumeLayout(false);
            this._toolBar.ResumeLayout(false);
            this._toolBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip _functionMenu;
        private System.Windows.Forms.ToolStripMenuItem _illustrateMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _aboutMenuItem;
        private System.Windows.Forms.GroupBox _dataGroupBox;
        private System.Windows.Forms.Button _addButton;
        private System.Windows.Forms.ComboBox _shapeComboBox;
        private System.Windows.Forms.DataGridView _shapeDataGridView;
        private System.Windows.Forms.ToolStrip _toolBar;
        private BindingToolStripButton _lineToolButton;
        private BindingToolStripButton _rectangleToolButton;
        private BindingToolStripButton _circleToolButton;
        private BindingToolStripButton _selectToolButton;
        private System.ComponentModel.BackgroundWorker _backgroundWorker;
        private DoubleBufferedPanel _canvas;
        private System.Windows.Forms.SplitContainer _windowSplitContainer;
        private System.Windows.Forms.Button _slideButton;
        private System.Windows.Forms.DataGridViewButtonColumn _deleteColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn _shapeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn _infoColumn;
        private System.Windows.Forms.SplitContainer _drawSplitContainer;
        private BindingToolStripButton _undoToolButton;
        private BindingToolStripButton _redoToolButton;
    }
}


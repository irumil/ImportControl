namespace ImpCtrlClientForm
{
    partial class ImpCtrlForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImpCtrlForm));
            this.serverInfoDataGridView = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.onTopButton = new System.Windows.Forms.Button();
            this.opasityTrackBar = new System.Windows.Forms.TrackBar();
            this.saveButton = new System.Windows.Forms.Button();
            this.delButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.getStatusButton = new System.Windows.Forms.Button();
            this.disconnectButton = new System.Windows.Forms.Button();
            this.connectButton = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.logStatusStrip = new System.Windows.Forms.StatusStrip();
            this.logToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.timeToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.localTimeTimer = new System.Windows.Forms.Timer(this.components);
            this.protocolClosableTabs = new PL.TabControl.ClosableTab();
            ((System.ComponentModel.ISupportInitialize)(this.serverInfoDataGridView)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.opasityTrackBar)).BeginInit();
            this.logStatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // serverInfoDataGridView
            // 
            this.serverInfoDataGridView.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.serverInfoDataGridView.AllowUserToAddRows = false;
            this.serverInfoDataGridView.AllowUserToDeleteRows = false;
            this.serverInfoDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.serverInfoDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.serverInfoDataGridView.Location = new System.Drawing.Point(5, 45);
            this.serverInfoDataGridView.Name = "serverInfoDataGridView";
            this.serverInfoDataGridView.RowHeadersWidth = 20;
            this.serverInfoDataGridView.Size = new System.Drawing.Size(764, 225);
            this.serverInfoDataGridView.TabIndex = 0;
            this.serverInfoDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.serverInfoDataGridView_CellClick);
            this.serverInfoDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.serverInfoDataGridView_DataError);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.onTopButton);
            this.panel1.Controls.Add(this.opasityTrackBar);
            this.panel1.Controls.Add(this.saveButton);
            this.panel1.Controls.Add(this.delButton);
            this.panel1.Controls.Add(this.addButton);
            this.panel1.Controls.Add(this.getStatusButton);
            this.panel1.Controls.Add(this.disconnectButton);
            this.panel1.Controls.Add(this.connectButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(774, 37);
            this.panel1.TabIndex = 9;
            // 
            // onTopButton
            // 
            this.onTopButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.onTopButton.Image = ((System.Drawing.Image)(resources.GetObject("onTopButton.Image")));
            this.onTopButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.onTopButton.Location = new System.Drawing.Point(735, 6);
            this.onTopButton.Name = "onTopButton";
            this.onTopButton.Size = new System.Drawing.Size(31, 26);
            this.onTopButton.TabIndex = 15;
            this.toolTip1.SetToolTip(this.onTopButton, "Поверх всех окон");
            this.onTopButton.UseVisualStyleBackColor = true;
            this.onTopButton.Click += new System.EventHandler(this.onTopButton_Click);
            // 
            // opasityTrackBar
            // 
            this.opasityTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.opasityTrackBar.Location = new System.Drawing.Point(525, 7);
            this.opasityTrackBar.Maximum = 100;
            this.opasityTrackBar.Minimum = 30;
            this.opasityTrackBar.Name = "opasityTrackBar";
            this.opasityTrackBar.Size = new System.Drawing.Size(207, 45);
            this.opasityTrackBar.TabIndex = 14;
            this.opasityTrackBar.TickFrequency = 5;
            this.opasityTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.toolTip1.SetToolTip(this.opasityTrackBar, "Прозрачность");
            this.opasityTrackBar.Value = 100;
            this.opasityTrackBar.Scroll += new System.EventHandler(this.opasityTrackBar_Scroll);
            // 
            // saveButton
            // 
            this.saveButton.Image = ((System.Drawing.Image)(resources.GetObject("saveButton.Image")));
            this.saveButton.Location = new System.Drawing.Point(63, 6);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(28, 26);
            this.saveButton.TabIndex = 13;
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // delButton
            // 
            this.delButton.Image = ((System.Drawing.Image)(resources.GetObject("delButton.Image")));
            this.delButton.Location = new System.Drawing.Point(36, 6);
            this.delButton.Name = "delButton";
            this.delButton.Size = new System.Drawing.Size(28, 26);
            this.delButton.TabIndex = 12;
            this.delButton.UseVisualStyleBackColor = true;
            this.delButton.Click += new System.EventHandler(this.delButton_Click);
            // 
            // addButton
            // 
            this.addButton.Image = ((System.Drawing.Image)(resources.GetObject("addButton.Image")));
            this.addButton.Location = new System.Drawing.Point(8, 6);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(29, 26);
            this.addButton.TabIndex = 11;
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // getStatusButton
            // 
            this.getStatusButton.Location = new System.Drawing.Point(189, 7);
            this.getStatusButton.Name = "getStatusButton";
            this.getStatusButton.Size = new System.Drawing.Size(75, 24);
            this.getStatusButton.TabIndex = 10;
            this.getStatusButton.Text = "Статус";
            this.getStatusButton.UseVisualStyleBackColor = true;
            this.getStatusButton.Click += new System.EventHandler(this.getStatusButton_Click);
            // 
            // disconnectButton
            // 
            this.disconnectButton.Location = new System.Drawing.Point(265, 7);
            this.disconnectButton.Name = "disconnectButton";
            this.disconnectButton.Size = new System.Drawing.Size(92, 24);
            this.disconnectButton.TabIndex = 9;
            this.disconnectButton.Text = "Отключение";
            this.disconnectButton.UseVisualStyleBackColor = true;
            this.disconnectButton.Visible = false;
            this.disconnectButton.Click += new System.EventHandler(this.disconnectButton_Click);
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(96, 7);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(92, 24);
            this.connectButton.TabIndex = 8;
            this.connectButton.Text = "Подключение";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(192, 74);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(497, 224);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "tabPage4";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // logStatusStrip
            // 
            this.logStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.timeToolStripStatusLabel,
            this.logToolStripStatusLabel});
            this.logStatusStrip.Location = new System.Drawing.Point(0, 467);
            this.logStatusStrip.Name = "logStatusStrip";
            this.logStatusStrip.Size = new System.Drawing.Size(774, 22);
            this.logStatusStrip.TabIndex = 13;
            // 
            // logToolStripStatusLabel
            // 
            this.logToolStripStatusLabel.Name = "logToolStripStatusLabel";
            this.logToolStripStatusLabel.Size = new System.Drawing.Size(30, 17);
            this.logToolStripStatusLabel.Text = "Лог:";
            // 
            // timeToolStripStatusLabel
            // 
            this.timeToolStripStatusLabel.Name = "timeToolStripStatusLabel";
            this.timeToolStripStatusLabel.Size = new System.Drawing.Size(42, 17);
            this.timeToolStripStatusLabel.Text = "Время";
            // 
            // localTimeTimer
            // 
            this.localTimeTimer.Enabled = true;
            this.localTimeTimer.Interval = 1000;
            this.localTimeTimer.Tick += new System.EventHandler(this.localTimeTimer_Tick);
            // 
            // protocolClosableTabs
            // 
            this.protocolClosableTabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.protocolClosableTabs.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.protocolClosableTabs.ImageHitArea = new System.Drawing.Point(13, 3);
            this.protocolClosableTabs.ImageLocation = new System.Drawing.Point(15, 6);
            this.protocolClosableTabs.Location = new System.Drawing.Point(5, 276);
            this.protocolClosableTabs.Name = "protocolClosableTabs";
            this.protocolClosableTabs.Padding = new System.Drawing.Point(12, 3);
            this.protocolClosableTabs.SelectedIndex = 0;
            this.protocolClosableTabs.SetImage = ((System.Drawing.Image)(resources.GetObject("protocolClosableTabs.SetImage")));
            this.protocolClosableTabs.Size = new System.Drawing.Size(764, 188);
            this.protocolClosableTabs.TabIndex = 12;
            // 
            // ImpCtrlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 489);
            this.Controls.Add(this.logStatusStrip);
            this.Controls.Add(this.protocolClosableTabs);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.serverInfoDataGridView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(790, 500);
            this.Name = "ImpCtrlForm";
            this.Text = "Импорт контроль клиент";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ImpCtrlForm_FormClosing);
            this.Load += new System.EventHandler(this.ImpCtrlForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.serverInfoDataGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.opasityTrackBar)).EndInit();
            this.logStatusStrip.ResumeLayout(false);
            this.logStatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView serverInfoDataGridView;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button delButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button getStatusButton;
        private System.Windows.Forms.Button disconnectButton;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.TrackBar opasityTrackBar;
        private System.Windows.Forms.Button onTopButton;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage1;
        private PL.TabControl.ClosableTab protocolClosableTabs;
        private System.Windows.Forms.StatusStrip logStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel logToolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel timeToolStripStatusLabel;
        private System.Windows.Forms.Timer localTimeTimer;
    }
}


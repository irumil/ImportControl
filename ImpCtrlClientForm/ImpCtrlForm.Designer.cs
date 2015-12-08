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
            this.logingTabControl = new System.Windows.Forms.TabControl();
            this.logTabPage = new System.Windows.Forms.TabPage();
            this.logListBox = new System.Windows.Forms.ListBox();
            this.ProtokolTabPage = new System.Windows.Forms.TabPage();
            this.protocolTextBox = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.serverInfoDataGridView)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.opasityTrackBar)).BeginInit();
            this.logingTabControl.SuspendLayout();
            this.logTabPage.SuspendLayout();
            this.ProtokolTabPage.SuspendLayout();
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
            this.serverInfoDataGridView.Size = new System.Drawing.Size(786, 225);
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
            this.panel1.Size = new System.Drawing.Size(796, 37);
            this.panel1.TabIndex = 9;
            // 
            // onTopButton
            // 
            this.onTopButton.Image = ((System.Drawing.Image)(resources.GetObject("onTopButton.Image")));
            this.onTopButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.onTopButton.Location = new System.Drawing.Point(755, 6);
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
            this.opasityTrackBar.Location = new System.Drawing.Point(547, 7);
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
            // logingTabControl
            // 
            this.logingTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logingTabControl.Controls.Add(this.logTabPage);
            this.logingTabControl.Controls.Add(this.ProtokolTabPage);
            this.logingTabControl.Location = new System.Drawing.Point(5, 276);
            this.logingTabControl.Name = "logingTabControl";
            this.logingTabControl.SelectedIndex = 0;
            this.logingTabControl.Size = new System.Drawing.Size(786, 278);
            this.logingTabControl.TabIndex = 10;
            // logTabPage
            // 
            this.logTabPage.Controls.Add(this.logListBox);
            this.logTabPage.Location = new System.Drawing.Point(4, 22);
            this.logTabPage.Name = "logTabPage";
            this.logTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.logTabPage.Size = new System.Drawing.Size(778, 252);
            this.logTabPage.TabIndex = 0;
            this.logTabPage.Text = "Лог";
            this.logTabPage.UseVisualStyleBackColor = true;
            // 
            // logListBox
            // 
            this.logListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logListBox.FormattingEnabled = true;
            this.logListBox.Location = new System.Drawing.Point(3, 3);
            this.logListBox.Name = "logListBox";
            this.logListBox.Size = new System.Drawing.Size(772, 246);
            this.logListBox.TabIndex = 3;
            this.logListBox.DoubleClick += new System.EventHandler(this.logListBox_DoubleClick);
            // 
            // ProtokolTabPage
            // 
            this.ProtokolTabPage.Controls.Add(this.protocolTextBox);
            this.ProtokolTabPage.Location = new System.Drawing.Point(4, 22);
            this.ProtokolTabPage.Name = "ProtokolTabPage";
            this.ProtokolTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.ProtokolTabPage.Size = new System.Drawing.Size(778, 252);
            this.ProtokolTabPage.TabIndex = 1;
            this.ProtokolTabPage.Text = "Протокол Импорта";
            this.ProtokolTabPage.UseVisualStyleBackColor = true;
            // 
            // protocolTextBox
            // 
            this.protocolTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.protocolTextBox.Location = new System.Drawing.Point(3, 3);
            this.protocolTextBox.Multiline = true;
            this.protocolTextBox.Name = "protocolTextBox";
            this.protocolTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.protocolTextBox.Size = new System.Drawing.Size(772, 246);
            this.protocolTextBox.TabIndex = 1;
            // 
            // ImpCtrlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 560);
            this.Controls.Add(this.logingTabControl);
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
            this.logingTabControl.ResumeLayout(false);
            this.logTabPage.ResumeLayout(false);
            this.ProtokolTabPage.ResumeLayout(false);
            this.ProtokolTabPage.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.TabControl logingTabControl;
        private System.Windows.Forms.TabPage logTabPage;
        private System.Windows.Forms.ListBox logListBox;
        private System.Windows.Forms.TabPage ProtokolTabPage;
        private System.Windows.Forms.TextBox protocolTextBox;
        private System.Windows.Forms.Button onTopButton;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}


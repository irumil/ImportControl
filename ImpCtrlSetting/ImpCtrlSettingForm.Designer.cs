namespace ImpCtrlSetting
{
    partial class ImpCtrlSettingForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.importPathTextBox = new System.Windows.Forms.TextBox();
            this.workCheckBox = new System.Windows.Forms.CheckBox();
            this.WorkLogImportCheckBox = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.intervalWorkUpDown = new System.Windows.Forms.NumericUpDown();
            this.intervalLogImportUpDown = new System.Windows.Forms.NumericUpDown();
            this.KillNoRespondСheckBox = new System.Windows.Forms.CheckBox();
            this.countRespondUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.closeCopyImportCheckBox = new System.Windows.Forms.CheckBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.intervalWorkUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.intervalLogImportUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.countRespondUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Путь к Импорту";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(230, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Интервал";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(230, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Интервал";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(220, 138);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 26);
            this.label7.TabIndex = 6;
            this.label7.Text = "Количество запросов \r\nк зависшему Импорту";
            // 
            // importPathTextBox
            // 
            this.importPathTextBox.Location = new System.Drawing.Point(118, 57);
            this.importPathTextBox.Name = "importPathTextBox";
            this.importPathTextBox.Size = new System.Drawing.Size(275, 20);
            this.importPathTextBox.TabIndex = 2;
            this.importPathTextBox.DoubleClick += new System.EventHandler(this.importPathTextBox_DoubleClick);
            // 
            // workCheckBox
            // 
            this.workCheckBox.AutoSize = true;
            this.workCheckBox.Location = new System.Drawing.Point(28, 25);
            this.workCheckBox.Name = "workCheckBox";
            this.workCheckBox.Size = new System.Drawing.Size(139, 17);
            this.workCheckBox.TabIndex = 0;
            this.workCheckBox.Text = "Следить за Импортом";
            this.workCheckBox.UseVisualStyleBackColor = true;
            // 
            // WorkLogImportCheckBox
            // 
            this.WorkLogImportCheckBox.AutoSize = true;
            this.WorkLogImportCheckBox.Location = new System.Drawing.Point(28, 93);
            this.WorkLogImportCheckBox.Name = "WorkLogImportCheckBox";
            this.WorkLogImportCheckBox.Size = new System.Drawing.Size(195, 17);
            this.WorkLogImportCheckBox.TabIndex = 3;
            this.WorkLogImportCheckBox.Text = "Следить за протоколом Импорта";
            this.WorkLogImportCheckBox.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(365, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "сек.";
            // 
            // intervalWorkUpDown
            // 
            this.intervalWorkUpDown.Location = new System.Drawing.Point(287, 22);
            this.intervalWorkUpDown.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.intervalWorkUpDown.Name = "intervalWorkUpDown";
            this.intervalWorkUpDown.Size = new System.Drawing.Size(72, 20);
            this.intervalWorkUpDown.TabIndex = 1;
            // 
            // intervalLogImportUpDown
            // 
            this.intervalLogImportUpDown.Location = new System.Drawing.Point(288, 90);
            this.intervalLogImportUpDown.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.intervalLogImportUpDown.Name = "intervalLogImportUpDown";
            this.intervalLogImportUpDown.Size = new System.Drawing.Size(71, 20);
            this.intervalLogImportUpDown.TabIndex = 4;
            // 
            // KillNoRespondСheckBox
            // 
            this.KillNoRespondСheckBox.AutoSize = true;
            this.KillNoRespondСheckBox.Location = new System.Drawing.Point(28, 139);
            this.KillNoRespondСheckBox.Name = "KillNoRespondСheckBox";
            this.KillNoRespondСheckBox.Size = new System.Drawing.Size(177, 17);
            this.KillNoRespondСheckBox.TabIndex = 5;
            this.KillNoRespondСheckBox.Text = "Закрывать повисший Импорт";
            this.KillNoRespondСheckBox.UseVisualStyleBackColor = true;
            // 
            // countRespondUpDown
            // 
            this.countRespondUpDown.Location = new System.Drawing.Point(346, 138);
            this.countRespondUpDown.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.countRespondUpDown.Name = "countRespondUpDown";
            this.countRespondUpDown.Size = new System.Drawing.Size(47, 20);
            this.countRespondUpDown.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(365, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "сек.";
            // 
            // closeCopyImportCheckBox
            // 
            this.closeCopyImportCheckBox.AutoSize = true;
            this.closeCopyImportCheckBox.Location = new System.Drawing.Point(28, 185);
            this.closeCopyImportCheckBox.Name = "closeCopyImportCheckBox";
            this.closeCopyImportCheckBox.Size = new System.Drawing.Size(216, 17);
            this.closeCopyImportCheckBox.TabIndex = 7;
            this.closeCopyImportCheckBox.Text = "Закрывать открытые копии Импорта";
            this.closeCopyImportCheckBox.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(177, 219);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 20;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "C:\\ASUSS\\Import.exe";
            // 
            // impCtrlSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 255);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.closeCopyImportCheckBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.countRespondUpDown);
            this.Controls.Add(this.KillNoRespondСheckBox);
            this.Controls.Add(this.intervalLogImportUpDown);
            this.Controls.Add(this.intervalWorkUpDown);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.WorkLogImportCheckBox);
            this.Controls.Add(this.workCheckBox);
            this.Controls.Add(this.importPathTextBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ImpCtrlSettingForm";
            this.Text = "Настройка Импорт контроля";
            this.Load += new System.EventHandler(this.impCtrlSettingForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.intervalWorkUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.intervalLogImportUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.countRespondUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox importPathTextBox;
        private System.Windows.Forms.CheckBox workCheckBox;
        private System.Windows.Forms.CheckBox WorkLogImportCheckBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown intervalWorkUpDown;
        private System.Windows.Forms.NumericUpDown intervalLogImportUpDown;
        private System.Windows.Forms.CheckBox KillNoRespondСheckBox;
        private System.Windows.Forms.NumericUpDown countRespondUpDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox closeCopyImportCheckBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}


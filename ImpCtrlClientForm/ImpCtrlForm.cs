using ImpCtrlClientManager;
using System;
using System.Windows.Forms;

namespace ImpCtrlClientForm
{
    public partial class ImpCtrlForm : Form
    {
        private ImpCtrlManger _impCtrlManager;

        public ImpCtrlForm()
        {
            InitializeComponent();
        }
        
       private void ImpCtrlForm_Load(object sender, EventArgs e)
        {
            _impCtrlManager = new ImpCtrlManger();
            serverInfoDataGridView.DataSource = _impCtrlManager.GetServerList();

            serverInfoDataGridView.Columns[0].Width = 25;
            serverInfoDataGridView.Columns[1].Width = 80;
            serverInfoDataGridView.Columns[2].Width = 120;
            serverInfoDataGridView.Columns[3].Width = 400;

            serverInfoDataGridView.Columns.Add(new DataGridViewButtonColumn()
            {
                Text = "↓",
                UseColumnTextForButtonValue = true
            });
            serverInfoDataGridView.Columns[4].Width = 30;
            serverInfoDataGridView.Columns[4].HeaderText = @"Лог";
           
            serverInfoDataGridView.Columns.Add(new DataGridViewButtonColumn()
            {
                Text = "↓↓",
                UseColumnTextForButtonValue = true
            });
            serverInfoDataGridView.Columns[5].Width = 60;
            serverInfoDataGridView.Columns[5].HeaderText = @"Протокол";

            _impCtrlManager.UpdateLog += AppendLogToListBox;
        }

        private void AppendLogToListBox(string info)
        {
            logListBox.Items.Add(info);
            logListBox.SelectedIndex = logListBox.Items.Count - 1;
        }

        private void disconnectButton_Click(object sender, EventArgs e)
        {
            _impCtrlManager.Disconnect();
        }

        private void serverInfoDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // Exclude
        }

        private void SetTransparentWindow(int value)
        {
            Opacity = (double)value / 100;
        }

        private void serverInfoDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var dataGridView = sender as DataGridView;

            if (dataGridView == null) return;

            switch (e.ColumnIndex)
            {
                case 4:
                {
                    logingTabControl.SelectedIndex = 0;

                    logListBox.Items.Add(new string('-', 50));
                    logListBox.Items.AddRange(_impCtrlManager.GetFullLogWork(dataGridView.CurrentRow.Index));
                    logListBox.Items.Add(new string('-', 50));

                    logListBox.SelectedIndex = logListBox.Items.Count - 1;
                }
                    break;
                case 5:
                {
                    string importProtokol = _impCtrlManager.GetImportProtocolByServer(dataGridView.CurrentRow.Index);

                    if (importProtokol == String.Empty) return;

                    logingTabControl.SelectedIndex = 1;
                    protocolTextBox.AppendText(importProtokol);
                    ScrollToBottom(protocolTextBox);
                }
                    break;
                case 6:
                    {
                        _impCtrlManager.GetScreenShotByIndex(dataGridView.CurrentRow.Index); 
                    }break;

            }
        }

        private void getStatusButton_Click(object sender, EventArgs e)
        {
            _impCtrlManager.GetStatus();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            _impCtrlManager.AddServer();
        }

        private void delButton_Click(object sender, EventArgs e)
        {
            try
            {
                var result = MessageBox.Show(@"Удалить", @"Подтвердить",
                                             MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if ((result == DialogResult.Yes) && (serverInfoDataGridView.CurrentRow != null))
                {
                    _impCtrlManager.DeleteServer(serverInfoDataGridView.CurrentRow.Index);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Ошибка {0} {1}", ex.Message, ex.InnerException.Message));
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            _impCtrlManager.SaveServerList();
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            _impCtrlManager.ConnectToService();
        }
       
        private void opasityTrackBar_Scroll(object sender, EventArgs e)
        {
            SetTransparentWindow(((TrackBar)sender).Value);
        }

        private void logListBox_DoubleClick(object sender, EventArgs e)
        {
            ((ListBox) sender).Items.Clear();
        }

        private void ImpCtrlForm_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (!_impCtrlManager.IsServerListChanged) return;

            var result = MessageBox.Show(@"Список серверов был изменен, сохранить изменения?", @"Подтвердить",
                                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                _impCtrlManager.SaveServerList();
            }
        }
           
        [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        private static extern int SendMessage(System.IntPtr hWnd, int wMsg, System.IntPtr wParam, System.IntPtr lParam);
       
        /// <summary>
        /// Scrolls the vertical scroll bar of a multi-line text box to the bottom.
        /// </summary>
        /// <param name="textBox">The text box to scroll</param>
        public static void ScrollToBottom(TextBox textBox)
        {
            const int WM_VSCROLL = 0x115;
            const int SB_BOTTOM = 7;
            if (Environment.OSVersion.Platform != PlatformID.Unix)
                SendMessage(textBox.Handle, WM_VSCROLL, new IntPtr(SB_BOTTOM), IntPtr.Zero);
        }

        private void onTopButton_Click(object sender, EventArgs e)
        {
            TopMost = !TopMost;
        }
       
    }
}

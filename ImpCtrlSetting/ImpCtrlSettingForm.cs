using System;
using System.Windows.Forms;
using ImpStatusLibrary;

namespace ImpCtrlSetting
{
    public partial class ImpCtrlSettingForm : Form
    {
        public ImpCtrlSettingForm()
        {
            InitializeComponent();
        }

        private ImportControlSetting _impCtrlSettings;
        
        private void impCtrlSettingForm_Load(object sender, EventArgs e)
        {
            _impCtrlSettings = ImportControlSetting.GetSettings();

            workCheckBox.Checked = _impCtrlSettings.WorkIt;
            intervalWorkUpDown.Value = (decimal) _impCtrlSettings.Interval;

            importPathTextBox.Text = _impCtrlSettings.ImportPath;
            
            WorkLogImportCheckBox.Checked = _impCtrlSettings.WorkLogImport;
            intervalLogImportUpDown.Value = (decimal) _impCtrlSettings.IntervalLogImport;

            KillNoRespondСheckBox.Checked = _impCtrlSettings.KillNoRespondProc;

            countRespondUpDown.Value = _impCtrlSettings.CountForRespondToProc;

            closeCopyImportCheckBox.Checked = _impCtrlSettings.CloseCopyImport;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            _impCtrlSettings.WorkIt = workCheckBox.Checked ;
            _impCtrlSettings.Interval = (double) intervalWorkUpDown.Value;

            _impCtrlSettings.ImportPath= importPathTextBox.Text;

            _impCtrlSettings.WorkLogImport =  WorkLogImportCheckBox.Checked;
            _impCtrlSettings.IntervalLogImport = (double) intervalLogImportUpDown.Value;

            _impCtrlSettings.KillNoRespondProc =  KillNoRespondСheckBox.Checked;

            _impCtrlSettings.CountForRespondToProc =  (int) countRespondUpDown.Value;

            _impCtrlSettings.CloseCopyImport = closeCopyImportCheckBox.Checked;

            _impCtrlSettings.Save();
            MessageBox.Show(@"После изменения настроек перезапустите службу");

            Close();
        }

        private void importPathTextBox_DoubleClick(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                importPathTextBox.Text = openFileDialog1.FileName;
            }
        }
    }
}

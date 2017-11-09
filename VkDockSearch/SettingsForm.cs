using System;
using System.Net;
using System.Windows.Forms;

namespace VkDockSearch
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            numericUpDown1.Value = User.Default.ConnectionCount;
            checkBox1.Checked = User.Default.startToEnd;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            User.Default.ConnectionCount = (int)numericUpDown1.Value;
            ServicePointManager.DefaultConnectionLimit = (int)numericUpDown1.Value;
        }

        private void checkStartToEnd_CheckedChanged(object sender, EventArgs e)
        {
            User.Default.startToEnd = ((CheckBox)sender).Checked;
        }
    }
}

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
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            User.Default.ConnectionCount = (int)numericUpDown1.Value;
            ServicePointManager.DefaultConnectionLimit = (int)numericUpDown1.Value;
        }
    }
}

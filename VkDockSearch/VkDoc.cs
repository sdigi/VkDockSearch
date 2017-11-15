using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace VkDockSearch
{
    public partial class VkDoc : Form
    {
        public VkDoc()
        {
            InitializeComponent();
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                isStop = false;

                if (int.TryParse(tUserId.Text, out userID))
                {
                    if (int.TryParse(tDocIDStart.Text, out docStarId) && int.TryParse(tDocIDEnd.Text, out docEndId))
                    {
                        count = docEndId - docStarId;
                        progressDoc.Maximum = count;
                        docEndId += offset;
                        int[] param = { userID, docStarId, docEndId };
                        await ParsingDocUserIdAync(param);
                    }
                }
                else
                {
                    MessageBox.Show("Укажите ID пользователя");
                }
            }
            catch (Exception er)
            {
                Logger.log(er);
                tDocIDStart.Text = toolStripStatusLabel1.Text.Split('_').Last();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists("docs"))
            {
                Directory.CreateDirectory("docs");
            }
            var users = Directory.GetDirectories("docs").Select(
                a => a.Replace("docs\\id", "")).ToArray();
            tUserId.Items.AddRange(users);

            ServicePointManager.DefaultConnectionLimit = User.Default.ConnectionCount;
            tUserId.SelectedItem = User.Default.UserId;

            lPercent.BackColor = Color.FromArgb(132, progressDoc.BackColor);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            isStop = true;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            User.Default.ConnectionCount = ServicePointManager.DefaultConnectionLimit;
            User.Default.UserId = tUserId.Text;
            User.Default.Save();
        }

        private void settingsMenuStrip_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.ShowDialog();
        }
    }
}

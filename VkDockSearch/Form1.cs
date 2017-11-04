using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VkDockSearch
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                int userID, docStarId, docEndId;

                if (int.TryParse(tUserId.Text, out userID))
                {
                    if (int.TryParse(tDocIDStart.Text, out docStarId) && int.TryParse(tDocIDEnd.Text, out docEndId))
                    {
                        int[] param = { userID, docStarId, docEndId };
                        await ParsingDocUserIdAync(param);
                    }
                }
                else
                {
                    MessageBox.Show("Укажите ID пользователя");
                }
            }catch(Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private async Task ParsingDocUserIdAync(object inParam)
        {
            await Task.Run(()=> {
                int[] param = inParam as int[];

                string url = "https://vk.com/doc";
                int count = param[2] - param[1];

                if (!Directory.Exists("docs/id" + param[0])) Directory.CreateDirectory("docs/id" + param[0]);

                Invoke((MethodInvoker)(() =>
                {
                    progressDoc.Maximum = count;
                }));

                while (param[1] <= param[2])
                {
                    string doc = url + param[0] + "_" + param[1];
                    string respnse = Get(doc);

                    Invoke((MethodInvoker)(() =>
                    {
                        progressDoc.PerformStep();
                        toolStripStatusLabel1.Text = "Проверка: " + doc;
                    }));

                    if (!respnse.Contains("/badbrowser.php"))
                    {
                        StreamWriter writer = new StreamWriter("docs/id" + param[0] + "/" + param[1] + ".html");
                        writer.WriteLine(respnse);
                        writer.Flush();
                        writer.Close();
                    }
                    param[1]++;
                }
            });
        }

        public string Get(string url)
        {
            WebRequest webRequest = WebRequest.Create(url);
            WebResponse response = webRequest.GetResponse();
            Stream responseStream = response.GetResponseStream();
            if (responseStream != null)
            {
                StreamReader streamReader = new StreamReader(responseStream);
                string result = streamReader.ReadToEnd();
                streamReader.Close();
                return result;
            }
            return null;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists("docs"))
            {
                Directory.CreateDirectory("docs");
            }
        }
    }
}

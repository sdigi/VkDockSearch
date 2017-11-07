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
            await Task.Run(() =>
            {
                int[] param = inParam as int[];

                string url = "https://vk.com/doc";
                int count = param[2] - param[1];

                if (!Directory.Exists("docs/id" + param[0])) Directory.CreateDirectory("docs/id" + param[0]);

                Invoke((MethodInvoker)(() =>
                {
                    progressDoc.Maximum = count;
                }));

                Parallel.For(param[1],param[2], (i) =>
                 {
                     string doc = url + param[0] + "_" + i;
                     string respnse = Get(doc);

                     Invoke((MethodInvoker)(() =>
                     {
                         progressDoc.PerformStep();
                         toolStripStatusLabel1.Text = "Проверка: " + doc;
                     }));

                     if (!respnse.Contains("/badbrowser.php") && !string.IsNullOrEmpty(respnse))
                     {
                         StreamWriter writer = new StreamWriter("docs/id" + param[0] + "/" + i + ".html");
                         writer.WriteLine(respnse);
                         writer.Flush();
                         writer.Close();
                     }
                 });
            });
        }

        public string Get(string url)
        {
            try
            {
                WebRequest webRequest = WebRequest.Create(url);
                webRequest.Timeout = 2000;
                WebResponse response = webRequest.GetResponse();
                if (((HttpWebResponse)response).StatusCode != HttpStatusCode.OK)
                {
                    Thread.Sleep(3000);
                    Get(url);
                }
                Stream responseStream = response.GetResponseStream();
                if (responseStream != null)
                {
                    StreamReader streamReader = new StreamReader(responseStream);
                    string result = streamReader.ReadToEnd();
                    streamReader.Close();
                    return result;
                }
                response.Close();
                responseStream.Close();
                return string.Empty;
            }catch(Exception er)
            {
                log(er);
            }
            return string.Empty;
        }

        private static void log(Exception er)
        {
            StreamWriter streamWriter = new StreamWriter("log.txt", true);
            streamWriter.WriteLine("[er]: \t" + er.Source + "\r\t" + er.Message + "\r\t" + er.StackTrace);
            streamWriter.Flush();
            streamWriter.Close();
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

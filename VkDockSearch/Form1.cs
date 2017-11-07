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

        bool isStop;
        private async void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                isStop = false;
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
            }
            catch (Exception er)
            {
                log(er);
                tDocIDStart.Text = toolStripStatusLabel1.Text.Split('_').Last();
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
                    progressDoc.Value = 0;
                    lPercent.Text = string.Empty;
                }));

                Parallel.For(param[1], param[2], (i, state) =>
                    {
                        if (isStop)
                        {
                            state.Break();
                            tDocIDStart.Text = i.ToString();
                        }
                        string doc = url + param[0] + "_" + i;
                        string respnse = Get(doc);

                        Invoke((MethodInvoker)(() =>
                        {
                            progressDoc.PerformStep();
                            toolStripStatusLabel1.Text = "Проверка: " + doc;
                            lPercent.Text = String.Format("{0:0.####} %", (((float)progressDoc.Value / progressDoc.Maximum) * 100));
                        }));

                        if (!respnse.Contains("/badbrowser.php") && !string.IsNullOrEmpty(respnse))
                        {
                            StreamWriter writer = new StreamWriter("docs/id" + param[0] + "/" + i + ".html");
                            writer.WriteLine(respnse);
                            writer.Flush();
                            writer.Close();
                        }
                        if (i % 80000 == 0) Thread.Sleep(5000);
                    });
            });
        }

        public static Int32 GetPercent(Int32 b, Int32 a)
        {
            if (b == 0) return 0;

            return (Int32)(a / (b / 100M));
        }

        public string Get(string url)
        {
            try
            {
                WebRequest webRequest = WebRequest.Create(url);
                webRequest.Timeout = 7000;
                using (WebResponse response = webRequest.GetResponse())
                {
                    if (((HttpWebResponse)response).StatusCode != HttpStatusCode.OK)
                    {
                        Thread.Sleep(3000);
                        Get(url);
                    }
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        if (responseStream != null)
                        {
                            StreamReader streamReader = new StreamReader(responseStream);
                            string result = streamReader.ReadToEnd();
                            streamReader.Close();
                            return result;
                        }
                        response.Close();
                        responseStream.Close();
                    }
                    return string.Empty;
                }
            }
            catch (Exception er)
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

        private void btnStop_Click(object sender, EventArgs e)
        {
            isStop = true;
        }
    }
}

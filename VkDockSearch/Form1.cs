using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;

namespace VkDockSearch
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Thread myThread;

        List<Thread> list = new List<Thread>();

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                int userID, docStarId, docEndId;

                if (int.TryParse(tUserId.Text, out userID))
                {
                    if (int.TryParse(tDocIDStart.Text, out docStarId) && int.TryParse(tDocIDEnd.Text, out docEndId))
                    {
                        
                        int[] param = { userID, docStarId, docEndId };
                        myThread = new Thread(startID);
                        myThread.Start(param);
                    }
                }
                else
                {
                    MessageBox.Show("Укажите ID пользователя");
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void startID(object param)
        {
            int[] p = param as int[];
            decimal taskCount = numericUpDown1.Value;
            int docCount = p[2] - p[1];
            int docStarId = p[1];

            Invoke((MethodInvoker)(()=>{
                progressDoc.Maximum = docCount;
            }));
            
            decimal offset = Math.Ceiling(docCount / taskCount);
            for (int i = 0; i < taskCount; i++)
            {
                Thread thread = new Thread(ParsingDocUserIdAync);
                p[1] = docStarId;
                p[2] += (int)offset;
                thread.Start(param);
                docStarId = p[2]+1;
                list.Add(thread);
            }
        }

        private void ParsingDocUserIdAync(object inParam)
        {
            int[] param = inParam as int[];
            string token = " поток-" + Thread.CurrentThread.ManagedThreadId;
            string url = "https://vk.com/doc";

            if (!Directory.Exists("docs/id" + param[0])) Directory.CreateDirectory("docs/id" + param[0]);

            while (param[1] <= param[2])
            {
                string doc = url + param[0] + "_" + param[1];
                string respnse = Get(doc);

                Invoke((MethodInvoker)(() =>
                {
                    progressDoc.PerformStep();
                    rLog.Text += "Проверка: " + doc + token + Environment.NewLine;

                    rLog.SelectionStart = rLog.Text.Length;
                    rLog.ScrollToCaret();
                }));

                if (!respnse.Contains("/badbrowser.php"))
                {
                    StreamWriter writer = new StreamWriter("docs/id" + param[0] + "/" + param[1] + ".html");
                    writer.WriteLine(respnse);
                    writer.Flush();
                    writer.Close();

                    Invoke((MethodInvoker)(() =>
                    {
                        rLog.Text += "Найден: " + doc + Environment.NewLine;
                        user.Default.startDocID = param[1].ToString();
                    }));
                }
                param[1]++;
            }
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

            tUserId.Text = user.Default.user_id;
            tDocIDStart.Text = user.Default.startDocID;
            tDocIDEnd.Text = user.Default.endDocID;
            numericUpDown1.Value = user.Default.taskCount;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            user.Default.user_id = tUserId.Text;
            user.Default.endDocID = tDocIDEnd.Text;
            user.Default.taskCount = numericUpDown1.Value;
            user.Default.Save();

            foreach(var th in list.Where(th=>th.IsAlive == true))
            {
                th.Join();
            }
        }
    }
}

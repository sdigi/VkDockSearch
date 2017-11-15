using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VkDockSearch
{
    public partial class VkDoc
    {
        bool isStop;
        int count = 0;
        int offset = 100000;
        int userID, docStarId, docEndId;

        /// <summary>
        /// Запуск сканирование диапазона документов
        /// </summary>
        /// <param name="inParam">Парамметры [0] - id юзеря, [1] - начала диапазоня, [2] - конец диапазона</param>
        /// <returns></returns>
        private async Task ParsingDocUserIdAync(object inParam)
        {
            await Task.Run(() =>
            {
                int[] param = inParam as int[];

                string url = "https://vk.com/doc";
                //int count = param[2] - param[1];
                int sum = param[2] + param[1];
                string pathD = "docs/id" + param[0] + "";

                if (!Directory.Exists(pathD)) Directory.CreateDirectory(pathD);

                Invoke((MethodInvoker)(() =>
                {
                    //progressDoc.Maximum = count;
                    progressDoc.Value = 0;
                    lPercent.Text = string.Empty;
                }));

                var loop = Parallel.For(param[1], param[2], (i, state) =>
                 {
                     int docId = (User.Default.startToEnd) ? sum - i : i;
                     if (isStop)
                     {
                         state.Break();
                         tDocIDStart.Text = docId.ToString();
                     }
                     string doc = url + param[0] + "_" + docId;
                     string respnse = Get(doc);

                     Invoke((MethodInvoker)(() =>
                     {
                         progressDoc.PerformStep();
                         var percent = (((float)progressDoc.Value / progressDoc.Maximum) * 100);
                         toolStripStatusLabel1.Text = "Проверка: " + doc;
                         lPercent.Text = String.Format("{0:0.####} %", percent);
                     }));

                     if (!(respnse.Contains("/badbrowser.php") || string.IsNullOrEmpty(respnse) || File.Exists(pathD + "/" + docId + ".html")))
                     {
                         StreamWriter writer = new StreamWriter(pathD + "/" + docId + ".html");
                         writer.WriteLine(respnse);
                         writer.Flush();
                         writer.Close();
                         Invoke((MethodInvoker)(() =>
                         {
                             lFindCount.Text = (int.Parse(lFindCount.Text) + 1).ToString();
                         }));
                     }
                 });

                if (loop.IsCompleted) CheckEndValue(param);
            });
        }

        private async void CheckEndValue(int[] param)
        {
            if (progressDoc.Value < progressDoc.Maximum)
            {
                docStarId = docEndId;
                docEndId += offset;
                await ParsingDocUserIdAync(new int[] { param[0], docStarId, docEndId });
            }
        }

        /// <summary>
        /// Посмотреть данные
        /// </summary>
        /// <param name="url">Ссылка</param>
        /// <returns>Строка</returns>
        internal string Get(string url)
        {
            try
            {
                WebRequest webRequest = WebRequest.Create(url);
                webRequest.Timeout = 120000;
                using (WebResponse response = webRequest.GetResponse())
                {
                    if (((HttpWebResponse)response).StatusCode != HttpStatusCode.OK)
                    {
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
                Logger.log(er);
            }
            return string.Empty;
        }
    }
}

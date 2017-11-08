using System;
using System.IO;

namespace VkDockSearch
{
    public static class Logger
    {

        public static void log(Exception er)
        {
            StreamWriter streamWriter = new StreamWriter("log.txt", true);
            streamWriter.WriteLine("[er]: \t" + er.Source + "\r\t" + er.Message + "\r\t" + er.StackTrace);
            streamWriter.Flush();
            streamWriter.Close();
        }
    }
}

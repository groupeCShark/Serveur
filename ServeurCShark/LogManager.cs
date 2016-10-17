using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServeurCShark
{
    public static class LogManager
    {
        public static bool WriteLogMessage(string Message)
        {
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "log/logs.txt", true))
            {
                file.WriteLine("<" + DateTime.Now.ToString() + "> " + Message);
            }
            return true;
        }
    }
}
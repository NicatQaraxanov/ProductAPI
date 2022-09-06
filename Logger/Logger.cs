using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerService
{
    public static class Logger
    {
        public static void Write(string message)
        {
            if(!File.Exists("log.txt"))
            {
                File.Create("log.txt");
            }
            File.AppendText(message + " - " + DateTime.Now);
        }
    }
}

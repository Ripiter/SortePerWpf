using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortePerWpf
{
    // TO DO: Add option to display logs
    static class Log
    {
        static List<string> logs = new List<string>();

        public static void AddToLog(string message)
        {
            logs.Add(string.Format("{0} {1}", DateTime.Now, message));
        }

    }
}

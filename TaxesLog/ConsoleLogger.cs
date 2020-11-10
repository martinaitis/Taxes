using System;
using System.Collections.Generic;
using System.Text;

namespace TaxesLog
{
    public class ConsoleLogger : ILogger
    {
        public void Error(string str)
        {
            Console.WriteLine($"ERROR: {str}");
        }
        public void Info(string str)
        {
            Console.WriteLine($"INFO: {str}");
        }
        public void Warning(string str)
        {
            Console.WriteLine($"WARNING: {str}");
        }
    }
}

using System;

namespace TaxesLog
{
    public interface ILogger
    {
        void Info(string str);
        void Warning(string str);
        void Error(string str);
    }
}

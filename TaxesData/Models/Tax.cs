using System;
using System.Collections.Generic;
using System.Text;

namespace TaxesData.Models
{
    public class Tax
    {
        public string Rule { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public double Value { get; set; }
        public Tax(string rule, DateTime dateStart, DateTime dateEnd, double value)
        {
            Rule = rule;
            DateStart = dateStart;
            DateEnd = dateEnd;
            Value = value;
        }
    }
}

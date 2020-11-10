using System;
using System.Collections.Generic;
using System.Text;
using TaxesData;
using TaxesData.Models;

namespace TaxesRules
{
    class FirstRule : IRule
    {
        public double CalculateTax(List<Tax> appliedTaxes)
        {           
            double result = 0;

            foreach (Tax tax in appliedTaxes)
                result += tax.Value;

            return result;
        }
        public List<Tax> GetAppliedTaxes(DateTime date, ISourceProvider sourceProvider)
        {
            List<Tax> taxes = sourceProvider.GetRuleTaxes(RuleTypes.FirstRule);
            List<Tax> appliedTaxes = taxes.FindAll(t => DateTime.Compare(t.DateStart.Date, date.Date) <= 0 && DateTime.Compare(t.DateEnd.Date, date.Date) >= 0);

            return appliedTaxes;
        }
    }
}

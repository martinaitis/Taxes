using System;
using System.Collections.Generic;
using TaxesData;
using TaxesData.Models;

namespace TaxesRules
{
    class SecondRule : IRule
    {
        public double CalculateTax(List<Tax> appliedTaxes)
        {
            double result = 0;
            int? period = null;

            foreach (Tax tax in appliedTaxes)
                if (period == null || DateTime.Compare(tax.DateEnd, tax.DateStart) < period)
                {
                    period = DateTime.Compare(tax.DateEnd, tax.DateStart);
                    result = tax.Value;
                }                

            return result;
        }

        public List<Tax> GetAppliedTaxes(DateTime date, ISourceProvider sourceProvider)
        {
            List<Tax> taxes = sourceProvider.GetRuleTaxes(RuleTypes.SecondRule);
            List<Tax> appliedTaxes = taxes.FindAll(t => DateTime.Compare(t.DateStart.Date, date.Date) <= 0 && DateTime.Compare(t.DateEnd.Date, date.Date) >= 0);

            return appliedTaxes;
        }
    }
}

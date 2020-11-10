using System;
using System.Collections.Generic;
using TaxesData;
using TaxesData.Models;

namespace TaxesRules
{
    public interface IRule
    {
        public double CalculateTax(List<Tax> appliedTaxes);
        public List<Tax> GetAppliedTaxes(DateTime date, ISourceProvider sourceProvider);
    }
}

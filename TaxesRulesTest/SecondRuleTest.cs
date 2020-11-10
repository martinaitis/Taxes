using System;
using System.Collections.Generic;
using System.Text;
using TaxesData.Models;
using TaxesRules;
using Xunit;

namespace TaxesRulesTest
{
    public class SecondRuleTest
    {
        [Fact]
        public void CalculateTax_AppliedTaxesDoNotExist()
        {
            IRule secondRule = RuleFactory.GetRule(RuleTypes.SecondRule);

            double tax = secondRule.CalculateTax(new List<Tax>());

            Assert.Equal(0, tax);
        }
        [Fact]
        public void CalculateTaxAppliedTaxesDoExist()
        {
            IRule secondRule = RuleFactory.GetRule(RuleTypes.SecondRule);
            List<Tax> appliedTaxes = new List<Tax>
            {
                new Tax(RuleTypes.SecondRule, new DateTime(2020, 01, 01), new DateTime(2020, 01, 01), 0.1),
                new Tax(RuleTypes.SecondRule, new DateTime(2020, 01, 01), new DateTime(2020, 01, 02), 0.2),
                new Tax(RuleTypes.SecondRule, new DateTime(2020, 01, 01), new DateTime(2020, 01, 03), 0.3)
            };

            double tax = secondRule.CalculateTax(appliedTaxes);

            Assert.Equal(0.1, tax);
        }
    }
}

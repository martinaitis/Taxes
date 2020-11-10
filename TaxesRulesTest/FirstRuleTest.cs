using Xunit;
using TaxesRules;
using System.Collections.Generic;
using TaxesData.Models;
using System;

namespace TaxesRulesTest
{
    public class FirstRuleTest
    {
        [Fact]
        public void CalculateTax_AppliedTaxesDoNotExist()
        {
            IRule firstRule = RuleFactory.GetRule(RuleTypes.FirstRule);

            double tax = firstRule.CalculateTax(new List<Tax>());

            Assert.Equal(0, tax);
        }
        [Fact]
        public void CalculateTax_AppliedTaxesDoExist()
        {
            IRule firstRule = RuleFactory.GetRule(RuleTypes.FirstRule);
            List<Tax> appliedTaxes = new List<Tax>
            {
                new Tax(RuleTypes.FirstRule, new DateTime(2020, 01, 01), new DateTime(2020, 01, 01), 0.1),
                new Tax(RuleTypes.FirstRule, new DateTime(2020, 01, 01), new DateTime(2020, 01, 01), 0.1),
                new Tax(RuleTypes.FirstRule, new DateTime(2020, 01, 01), new DateTime(2020, 01, 01), 0.1)
            };

            double tax = firstRule.CalculateTax(appliedTaxes);

            Assert.True(Math.Abs(tax - 0.3) < 0.000001);
        }
    }
}

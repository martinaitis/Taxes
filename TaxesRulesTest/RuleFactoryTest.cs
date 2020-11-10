using System;
using TaxesRules;
using Xunit;

namespace TaxesRulesTest
{
    public class RuleFactoryTest
    {
        [Fact]
        public void GetRule_RuleDoesNotExist()
        {
            Assert.Throws<ArgumentException>(() => RuleFactory.GetRule("RandomRule"));
        }
    }
}

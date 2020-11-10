using System;
namespace TaxesRules
{
    static public class RuleFactory
    {
        static public IRule GetRule(string rule)
        {
            return rule switch
            {
                RuleTypes.FirstRule => new FirstRule(),
                RuleTypes.SecondRule => new SecondRule(),
                _ => throw new ArgumentException($"Rule '{rule}' does not exist."),
            };
        }
    }
}

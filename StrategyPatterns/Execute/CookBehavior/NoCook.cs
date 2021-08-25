using StrategyPatterns.Interfaces;

namespace StrategyPatterns.Execute.CookBehavior
{
    public class NoCook : ICookBehavior
    {
        public string Cook() => "No cook";
    }
}
using DesignPatterns.Interfaces;

namespace StrategyPatterns.Execute.CookBehavior
{
    public class SimpleCook : ICookBehavior
    {
        public string Cook() => "Simple cooking techniques";        
    }
}
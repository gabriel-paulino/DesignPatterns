using DesignPatterns.Interfaces;

namespace StrategyPatterns.Execute.CookBehavior
{
    public class CookAsAChef : ICookBehavior
    {
        public string Cook() => "Cook as a Chef";        
    }
}
using StrategyPatterns.Interfaces;

namespace StrategyPatterns.Execute.EatBehavior
{
    public class EatMeat: IEatBehavior
    {
        public string Eat() => "Meat";
    }
}
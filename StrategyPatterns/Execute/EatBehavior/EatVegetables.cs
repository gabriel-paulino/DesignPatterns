using StrategyPatterns.Interfaces;

namespace StrategyPatterns.Execute.EatBehavior
{
    public class EatVegetables: IEatBehavior
    {
        public string Eat() => "Vegetables";
    }
}
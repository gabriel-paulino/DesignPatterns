using StrategyPatterns.Interfaces;
using System;

namespace StrategyPatterns.Execute.EatBehavior
{
    public class EatFastFood : IEatBehavior
    {
        public string Eat() => "Fast Food";
    }
}
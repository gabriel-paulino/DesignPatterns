using StrategyPatterns.Interfaces;

namespace StrategyPatterns.Execute.DrinkBehavior
{
    public class DrinkBeer : IDrinkBehavior
    {
        public string Drink() => "Beer";      
    }
}
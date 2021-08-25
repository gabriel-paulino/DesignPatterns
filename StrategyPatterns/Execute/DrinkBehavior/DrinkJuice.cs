using StrategyPatterns.Interfaces;

namespace StrategyPatterns.Execute.DrinkBehavior
{
    public class DrinkJuice : IDrinkBehavior
    {
        public string Drink() => "Juice";
    }
}
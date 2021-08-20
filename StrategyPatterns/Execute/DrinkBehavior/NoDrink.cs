using DesignPatterns.Interfaces;

namespace StrategyPatterns.Execute.DrinkBehavior
{
    public class NoDrink : IDrinkBehavior
    {
        public string Drink() => "No Drink";
    }
}
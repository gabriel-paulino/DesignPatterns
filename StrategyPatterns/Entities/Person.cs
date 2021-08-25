using StrategyPatterns.Interfaces;

namespace StrategyPatterns.Entities
{
    public class Person
    {
        public Person(
            ICookBehavior cookBehavior, 
            IEatBehavior eatBehavior,
            IDrinkBehavior drinkBehavior)
        {
            this.CookBehavior = cookBehavior;
            this.EatBehavior = eatBehavior;
            this.DrinkBehavior = drinkBehavior;
        }

        public ICookBehavior CookBehavior { get; private set; }
        public IEatBehavior EatBehavior { get; private set; }
        public IDrinkBehavior DrinkBehavior { get; private set; }

        public string Cook() => CookBehavior.Cook();
        public string Eat() => EatBehavior.Eat();
        public string Drink() => DrinkBehavior.Drink();
    }
}
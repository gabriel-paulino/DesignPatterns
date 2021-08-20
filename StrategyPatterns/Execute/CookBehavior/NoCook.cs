using DesignPatterns.Interfaces;

namespace DesignPatterns.Execute.CookBehavior
{
    public class NoCook : ICookBehavior
    {
        public string Cook() => "No cook";
    }
}
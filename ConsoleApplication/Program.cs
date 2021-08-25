using StrategyPatterns.Entities;
using StrategyPatterns.Execute.CookBehavior;
using StrategyPatterns.Execute.DrinkBehavior;
using StrategyPatterns.Execute.EatBehavior;
using StrategyPatterns.Execute.SalaryBehavior;
using StrategyPatterns.Interfaces;
using System;

namespace ConsoleApplication
{
    public class Program
    {
        static void Main(string[] args)
        {
            StrategyPatterns();            
        }

        private static void StrategyPatterns()
        {
            InterviewAChild();
            InterviewAMen();

            SalaryExemple();
        }

        private static void SalaryExemple()
        {
            decimal grossSalary = 3800.00m;
            decimal alimony = 700.00m;
            int dependents = 2;

            ISalaryBehavior salaryBehavior = new CltSalary(
                grossSalary: grossSalary,
                alimony: alimony,
                dependents: dependents);

            Employee employee = new(salaryBehavior);

            decimal salaryWithDiscounts = employee.GetSalary();
        }

        private static void InterviewAChild()
        {
            ICookBehavior noCook = new NoCook();
            IEatBehavior vegetables = new EatVegetables();
            IDrinkBehavior juice = new DrinkJuice();

            Person child = new(noCook, vegetables, juice);

            Console.WriteLine(
                $"Interviewer: Hey Child do you know how to cook?{Environment.NewLine}" + 
                $"Child: {child.Cook()}{Environment.NewLine}" +
                $"Interviewer: Ok...But what do you like to eat the most?{Environment.NewLine}" +
                $"Child: {child.Eat()}{Environment.NewLine}" +
                $"Interviewer: Very nice! And drink?{Environment.NewLine}" +  
                $"Child: {child.Drink()}{Environment.NewLine}");
        }

        private static void InterviewAMen()
        {
            ICookBehavior cook = new SimpleCook();
            IEatBehavior eat = new EatMeat();
            IDrinkBehavior drink = new DrinkBeer();

            Person men = new(cook, eat, drink);

            Console.WriteLine(
                $"Interviewer: Excuse me Sir, Do you know how to cook?{Environment.NewLine}" +
                $"Matheus: Yeah...But I have {men.Cook()}{Environment.NewLine}" +
                $"Interviewer: I get... What do you like to eat the most?{Environment.NewLine}" +
                $"Matheus: Let me think... Ah I like {men.Eat()}{Environment.NewLine}" +
                $"Interviewer: Me too ... And drink?{Environment.NewLine}" +
                $"Matheus: I drink {men.Drink()} more than water! Haha.{Environment.NewLine}");
        }
    }
}

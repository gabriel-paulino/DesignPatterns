using StrategyPatterns.Interfaces;

namespace StrategyPatterns.Entities
{
    public class Employee
    {
        public Employee(ISalaryBehavior salaryBehavior)
        {
            SalaryBehavior = salaryBehavior;
        }

        public ISalaryBehavior SalaryBehavior { get; private set; }
        public decimal GetSalary() => SalaryBehavior.CalculateSalary();
    }
}
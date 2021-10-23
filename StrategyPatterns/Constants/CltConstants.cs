namespace StrategyPatterns.Constants
{
    /// <summary>
    /// Source Information: https://www.calculadorafacil.com.br/trabalhista/calculo-salario-liquido
    /// </summary>
    public struct CltConstants
    {
        public const int YearOfConstants = 2021;

        public const decimal
            MinimumSalary = 1100.00m,
            BiggerSalaryOfAliquotInssLevelOne = 2203.48m,
            BiggerSalaryOfAliquotInssLevelTwo = 3305.22m,
            BiggerSalaryOfAliquotInssLevelThree = 6433.57m,
            PercentageAliquotInssMinSalary = 7.5m / 100,
            PercentageAliquotInssLevelOne = 9m / 100,
            PercentageAliquotInssLevelTwo = 12m / 100,
            PercentageAliquotInssLevelThree = 14m / 100,
            MaximumDiscountInss = 751.99m,
            DeductionInssPerDependent = 189.59m,
            BiggerSalaryOfAliquotIrrfLevelOne = 1903.98m,
            BiggerSalaryOfAliquotIrrfLevelTwo = 2826.65m,
            BiggerSalaryOfAliquotIrrfLevelThree = 3751.05m,
            BiggerSalaryOfAliquotIrrfLevelFour = 4664.68m,
            PercentageAliquotIrrfLevelOne = 0m,
            PercentageAliquotIrrfLevelTwo = 7.5m,
            PercentageAliquotIrrfLevelThree = 15m,
            PercentageAliquotIrrfLevelFour = 22.5m,
            PercentageAliquotIrrfLevelMax = 27.5m,
            DeductionIrrfLevelOne = 0m,
            DeductionIrrfLevelTwo = 142.80m,
            DeductionIrrfLevelThree = 354.80m,
            DeductionIrrfLevelFour = 636.13m,
            DeductionIrrfLevelMax = 869.36m;

        public const decimal
            FirstSalaryRange = MinimumSalary * PercentageAliquotInssMinSalary,
            SecondSalaryRange = (BiggerSalaryOfAliquotInssLevelOne - MinimumSalary) * PercentageAliquotInssLevelOne,
            ThirdSalaryRange = (BiggerSalaryOfAliquotInssLevelTwo - BiggerSalaryOfAliquotInssLevelOne) * PercentageAliquotInssLevelTwo;
    }
}

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
            PercentageAliquotInssMinSalary = 7.5m,
            PercentageAliquotInssLevelOne = 9m,
            PercentageAliquotInssLevelTwo = 12m,
            PercentageAliquotInssLevelThree = 14m,
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
            FirstSalaryRange = MinimumSalary * PercentageAliquotInssMinSalary / 100,
            SecondSalaryRange = (BiggerSalaryOfAliquotInssLevelOne - MinimumSalary) * PercentageAliquotInssLevelOne / 100,
            ThirdSalaryRange = (BiggerSalaryOfAliquotInssLevelTwo - BiggerSalaryOfAliquotInssLevelOne) * PercentageAliquotInssLevelTwo / 100;
    }
}

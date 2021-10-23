using StrategyPatterns.Constants;
using StrategyPatterns.Enums;
using StrategyPatterns.Interfaces;
using System;

namespace StrategyPatterns.Execute.SalaryBehavior
{
    public class CltSalary : ISalaryBehavior
    {
        public CltSalary(
            decimal grossSalary,
            decimal alimony = 0.0m,
            int dependents = 0)
        {
            GrossSalary = grossSalary;
            Alimony = alimony;
            OthersDiscounts = alimony;
            Dependents = dependents;
        }

        public decimal GrossSalary { get; private set; }
        public decimal Alimony { get; private set; }
        public decimal NetSalary { get; private set; }
        public decimal AliquotInssPercentage { get; private set; }
        public InssAliquot AliquotInss { get; private set; }
        public decimal TaxInss { get; private set; }
        public decimal BaseCalc { get; private set; }
        public decimal TaxIrrf { get; private set; }
        public int Dependents { get; private set; }
        public decimal AliquotIrrf { get; private set; }
        public decimal DeductionIrrf { get; private set; }
        public decimal OthersDiscounts { get; private set; }

        public decimal CalculateSalary()
        {
            if (CltConstants.YearOfConstants != DateTime.Now.Year)
                throw new Exception("Sorry, this app isn't updated.");

            TaxInss = GetTaxInss();

            TaxIrrf = GetTaxIrrf();

            NetSalary = GrossSalary - (TaxInss + TaxIrrf + OthersDiscounts);

            return NetSalary;
        }

        private decimal GetTaxIrrf()
        {
            BaseCalc = GetBaseCalc();
            var (Aliquot, Deduction) = GetIrrfByBaseCalc();

            AliquotIrrf = Aliquot;
            DeductionIrrf = Deduction;

            return (BaseCalc * AliquotIrrf) - DeductionIrrf;
        }

        private (decimal Aliquot, decimal Deduction) GetIrrfByBaseCalc() =>
            BaseCalc switch
            {
                <= CltConstants.BiggerSalaryOfAliquotIrrfLevelOne => (CltConstants.PercentageAliquotIrrfLevelOne / 100, CltConstants.DeductionIrrfLevelOne),
                <= CltConstants.BiggerSalaryOfAliquotIrrfLevelTwo => (CltConstants.PercentageAliquotIrrfLevelTwo / 100, CltConstants.DeductionIrrfLevelTwo),
                <= CltConstants.BiggerSalaryOfAliquotIrrfLevelThree => (CltConstants.PercentageAliquotIrrfLevelThree / 100, CltConstants.DeductionIrrfLevelThree),
                <= CltConstants.BiggerSalaryOfAliquotIrrfLevelFour => (CltConstants.PercentageAliquotIrrfLevelFour / 100, CltConstants.DeductionIrrfLevelFour),
                _ => (CltConstants.PercentageAliquotIrrfLevelMax / 100, CltConstants.DeductionIrrfLevelMax)
            };

        private decimal GetBaseCalc() =>
            GrossSalary - TaxInss - Alimony - GetDependentDeduction();

        private decimal GetDependentDeduction() =>
            Dependents > 0 ? CltConstants.DeductionInssPerDependent * Dependents : 0.0m;

        private decimal GetTaxInss()
        {
            AliquotInss = GetAliquotInss();
            AliquotInssPercentage = GetAliquotInssPercentage();

            return CalculateTaxInss();
        }

        private decimal CalculateTaxInss() =>
            GrossSalary switch
            {
                <= CltConstants.MinimumSalary => GrossSalary * AliquotInssPercentage,
                <= CltConstants.BiggerSalaryOfAliquotInssLevelOne => CltConstants.FirstSalaryRange + ((GrossSalary - CltConstants.MinimumSalary) * AliquotInssPercentage),
                <= CltConstants.BiggerSalaryOfAliquotInssLevelTwo => CltConstants.FirstSalaryRange + CltConstants.SecondSalaryRange + ((GrossSalary - CltConstants.BiggerSalaryOfAliquotInssLevelOne) * AliquotInssPercentage),
                <= CltConstants.BiggerSalaryOfAliquotInssLevelThree => CltConstants.FirstSalaryRange + CltConstants.SecondSalaryRange + CltConstants.ThirdSalaryRange + ((GrossSalary - CltConstants.BiggerSalaryOfAliquotInssLevelTwo) * AliquotInssPercentage),
                _ => CltConstants.MaximumDiscountInss
            };

        private InssAliquot GetAliquotInss() =>
            GrossSalary switch
            {
                <= CltConstants.MinimumSalary => InssAliquot.MinSalary,
                <= CltConstants.BiggerSalaryOfAliquotInssLevelOne => InssAliquot.LevelOne,
                <= CltConstants.BiggerSalaryOfAliquotInssLevelTwo => InssAliquot.LevelTwo,
                <= CltConstants.BiggerSalaryOfAliquotInssLevelThree => InssAliquot.LevelThree,
                _ => InssAliquot.LevelMax
            };

        private decimal GetAliquotInssPercentage() =>
            AliquotInss switch
            {
                InssAliquot.MinSalary => CltConstants.PercentageAliquotInssMinSalary,
                InssAliquot.LevelOne => CltConstants.PercentageAliquotInssLevelOne,
                InssAliquot.LevelTwo => CltConstants.PercentageAliquotInssLevelTwo,
                InssAliquot.LevelThree => CltConstants.PercentageAliquotInssLevelThree,
                InssAliquot.LevelMax => 0.0m,
                _ => throw new NotImplementedException()
            };
    }
}
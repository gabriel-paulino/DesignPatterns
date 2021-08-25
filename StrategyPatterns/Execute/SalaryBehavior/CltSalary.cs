using StrategyPatterns.Constants;
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
        public decimal AliquotInss { get; private set; }
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

            var inss = GetInssByGrossSalary();

            AliquotInss = inss.Aliquot;
            TaxInss = inss.Tax;

            TaxIrrf = GetTaxIrrf();

            NetSalary = GrossSalary - (TaxInss + TaxIrrf + OthersDiscounts);

            return NetSalary;
        }

        private decimal GetTaxIrrf()
        {
            BaseCalc = GetBaseCalc();
            var irrf = GetIrrfByBaseCalc();

            AliquotIrrf = irrf.Aliquot;
            DeductionIrrf = irrf.Deduction;

            return (BaseCalc * AliquotIrrf) - DeductionIrrf;
        }

        private (decimal Aliquot, decimal Deduction) GetIrrfByBaseCalc()
        {
            decimal aliquotIrrf, deductionIrrf;

            switch (BaseCalc)
            {
                case <= CltConstants.BiggerSalaryOfAliquotIrrfLevelOne:
                    {
                        aliquotIrrf = CltConstants.PercentageAliquotIrrfLevelOne / 100;
                        deductionIrrf = CltConstants.DeductionIrrfLevelOne;
                        break;
                    }
                case <= CltConstants.BiggerSalaryOfAliquotIrrfLevelTwo:
                    {
                        aliquotIrrf = CltConstants.PercentageAliquotIrrfLevelTwo / 100;
                        deductionIrrf = CltConstants.DeductionIrrfLevelTwo;
                        break;
                    }
                case <= CltConstants.BiggerSalaryOfAliquotIrrfLevelThree:
                    {
                        aliquotIrrf = CltConstants.PercentageAliquotIrrfLevelThree / 100;
                        deductionIrrf = CltConstants.DeductionIrrfLevelThree;
                        break;
                    }
                case <= CltConstants.BiggerSalaryOfAliquotIrrfLevelFour:
                    {
                        aliquotIrrf = CltConstants.PercentageAliquotIrrfLevelFour / 100;
                        deductionIrrf = CltConstants.DeductionIrrfLevelFour;
                        break;
                    }
                default:
                    {
                        aliquotIrrf = CltConstants.PercentageAliquotIrrfLevelMax / 100;
                        deductionIrrf = CltConstants.DeductionIrrfLevelMax;
                        break;
                    }
            }

            return (aliquotIrrf, deductionIrrf);
        }

        private decimal GetBaseCalc() =>
            GrossSalary - TaxInss - Alimony - GetDependentDeduction();

        private decimal GetDependentDeduction() =>
            Dependents > 0 ? CltConstants.DeductionInssPerDependent * Dependents : 0.0m;

        private (decimal Aliquot, decimal Tax) GetInssByGrossSalary()
        {
            decimal aliquotInss, taxInss;

            switch (GrossSalary)
            {
                case <= CltConstants.MinimumSalary:
                    {
                        aliquotInss = CltConstants.PercentageAliquotInssMinSalary / 100;
                        taxInss = GrossSalary * AliquotInss;
                        break;
                    }
                case <= CltConstants.BiggerSalaryOfAliquotInssLevelOne:
                    {
                        aliquotInss = CltConstants.PercentageAliquotInssLevelOne / 100;

                        taxInss =
                            CltConstants.FirstSalaryRange +
                            ((GrossSalary - CltConstants.MinimumSalary) * AliquotInss);

                        break;
                    }
                case <= CltConstants.BiggerSalaryOfAliquotInssLevelTwo:
                    {
                        aliquotInss = CltConstants.PercentageAliquotInssLevelTwo / 100;

                        taxInss =
                            CltConstants.FirstSalaryRange +
                            CltConstants.SecondSalaryRange +
                            ((GrossSalary - CltConstants.BiggerSalaryOfAliquotInssLevelOne) * AliquotInss);

                        break;
                    }
                case <= CltConstants.BiggerSalaryOfAliquotInssLevelThree:
                    {
                        aliquotInss = CltConstants.PercentageAliquotInssLevelThree / 100;

                        taxInss =
                            CltConstants.FirstSalaryRange +
                            CltConstants.SecondSalaryRange +
                            CltConstants.ThirdSalaryRange +
                            ((GrossSalary - CltConstants.BiggerSalaryOfAliquotInssLevelTwo) * AliquotInss);

                        break;
                    }

                default:
                    {
                        aliquotInss = 0.0m;
                        taxInss = CltConstants.MaximumDiscountInss;
                        break;
                    }
            }

            return (aliquotInss, taxInss);
        }
    }
}
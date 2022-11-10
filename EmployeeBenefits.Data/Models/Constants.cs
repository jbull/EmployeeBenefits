namespace EmployeeBenefits.Data.Models
{
    public static class Constants
    {
        public const decimal   YearlyEmployeeCost = 1000.00M;

        public const decimal   YearlyDependentCost = 500.00M;

        public const decimal   DiscountAmt = 10.00M;

        public const decimal   CheckGrossPay = 2000.00M;

        public const int       PaychecksPerYear = 26;

        public const decimal   YearlySalary = CheckGrossPay * PaychecksPerYear;

        public const char      DiscountQualifier = 'A';
    }
}

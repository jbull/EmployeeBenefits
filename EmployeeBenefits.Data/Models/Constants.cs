namespace EmployeeBenefits.Data.Models
{
    public static class Constants
    {
        public const decimal   YEARLY_EMPLOYEE_COST = 1000.00M;

        public const decimal   YEARLY_DEPENDENT_COST = 500.00M;

        public const decimal   DISCOUNT_AMT = 10.00M;

        public const decimal   CHECK_GROSS_PAY = 2000.00M;

        public const int       PAYCHECHKS_PER_YEAR = 26;

        public const decimal   YEARLY_SALARY = CHECK_GROSS_PAY * PAYCHECHKS_PER_YEAR;

        public const char      DISCOUNT_QUALIFIER = 'A';
    }
}

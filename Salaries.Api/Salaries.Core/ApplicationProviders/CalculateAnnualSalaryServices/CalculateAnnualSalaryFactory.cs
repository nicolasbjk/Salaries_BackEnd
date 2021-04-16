using Salaries.Core.ApplicationServices.CalculateAnnualSalaryServices;
using Salaries.Entities;
using System;
using System.Threading.Tasks;

namespace Salaries.Core.ApplicationProviders.CalculateAnnualSalaryServices
{
    public class CalculateAnnualSalaryFactory : ICalculateAnnualSalaryFactory
    {
        private readonly string argumentErrorNull = "Employee is null";

        public async Task<ICalculateAnnualSalaryService> GetCalculator(Employee employee) {
            if (employee == null) throw new ArgumentNullException(argumentErrorNull);

            if (employee.ContractTypeName.Equals("HourlySalaryEmployee", StringComparison.OrdinalIgnoreCase)) {
                return new CalculateByHourlySalary();
            }

            return new CalculateByMonthlySalary();
        }
    }
}

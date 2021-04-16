using Salaries.Core.ApplicationServices.CalculateAnnualSalaryServices;
using Salaries.Entities;
using System;
using System.Threading.Tasks;

namespace Salaries.Core.ApplicationProviders.CalculateAnnualSalaryServices
{
    public class CalculateByMonthlySalary : ICalculateAnnualSalaryService
    {
        private readonly string argumentErrorNull = "Employee is null";

        public async Task<Employee> Calculate(Employee employee) {
            if (employee == null) throw new ArgumentNullException(argumentErrorNull);

            employee.AnnualSalary = employee.MonthlySalary * 12;

            return employee;
        }
    }
}

using Salaries.Core.ApplicationServices.CalculateAnnualSalaryServices;
using Salaries.Entities;
using System;
using System.Threading.Tasks;

namespace Salaries.Core.ApplicationProviders.CalculateAnnualSalaryServices
{
    public class CalculateByHourlySalary : ICalculateAnnualSalaryService
    {
        private readonly string argumentErrorNull = "Employee is null";
       
        public async Task<Employee> Calculate(Employee employee) {
            if (employee == null) throw new ArgumentNullException(argumentErrorNull);

            employee.AnnualSalary = 120 * employee.HourlySalary * 12;

            return employee;
        }
    }
}

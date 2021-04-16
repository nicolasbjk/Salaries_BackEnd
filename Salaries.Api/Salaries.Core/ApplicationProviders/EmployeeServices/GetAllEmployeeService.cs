using Salaries.Core.ApplicationServices.CalculateAnnualSalaryServices;
using Salaries.Core.ApplicationServices.EmployeeServices;
using Salaries.Core.Repositories;
using Salaries.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Salaries.Core.ApplicationProviders.EmployeeServices
{
    public class GetAllEmployeeService : IGetAllEmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly ICalculateAnnualSalaryFactory calculateAnnualSalaryFactory;

        public GetAllEmployeeService(
            IEmployeeRepository employeeRepository, 
            ICalculateAnnualSalaryFactory calculateAnnualSalaryFactory) {
            this.employeeRepository = employeeRepository;
            this.calculateAnnualSalaryFactory = calculateAnnualSalaryFactory;
        }

        public async Task<IEnumerable<Employee>> Get() {
            var employees = await employeeRepository.GetAll();
            if (employees == null) return employees;

            foreach (var employee in employees) {
                var calculateAnnualSalaryService = await calculateAnnualSalaryFactory.GetCalculator(employee);
                await calculateAnnualSalaryService.Calculate(employee);
            }

            return employees;
        }
    }
}

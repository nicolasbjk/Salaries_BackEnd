using Salaries.Core.ApplicationServices.CalculateAnnualSalaryServices;
using Salaries.Core.ApplicationServices.EmployeeServices;
using Salaries.Core.Repositories;
using Salaries.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace Salaries.Core.ApplicationProviders.EmployeeServices
{
    public class GetEmployeeByIdService : IGetEmployeeByIdService
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly ICalculateAnnualSalaryFactory calculateAnnualSalaryFactory;

        public GetEmployeeByIdService(
            IEmployeeRepository employeeRepository, 
            ICalculateAnnualSalaryFactory calculateAnnualSalaryFactory) {
            this.employeeRepository = employeeRepository;
            this.calculateAnnualSalaryFactory = calculateAnnualSalaryFactory;
        }

        public async Task<Employee> Get(int employeeId) {
            var employees = await employeeRepository.GetAll();
            if (employees == null || !employees.Any()) return null;

            var employee = employees.FirstOrDefault(x => x.Id == employeeId);
            if (employee == null || !employees.Any()) return employee;

            var calculateAnnualSalaryService = await calculateAnnualSalaryFactory.GetCalculator(employee);
            await calculateAnnualSalaryService.Calculate(employee);

            return employee;
        }
    }
}

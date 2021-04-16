using Salaries.Entities;
using System.Threading.Tasks;

namespace Salaries.Core.ApplicationServices.CalculateAnnualSalaryServices
{
    public interface ICalculateAnnualSalaryService
    {
        Task<Employee> Calculate(Employee employee);
    }
}

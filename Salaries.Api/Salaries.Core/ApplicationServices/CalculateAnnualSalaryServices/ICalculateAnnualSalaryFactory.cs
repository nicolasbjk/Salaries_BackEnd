using Salaries.Entities;
using System.Threading.Tasks;

namespace Salaries.Core.ApplicationServices.CalculateAnnualSalaryServices
{
    public interface ICalculateAnnualSalaryFactory
    {
        Task<ICalculateAnnualSalaryService> GetCalculator(Employee employee);
    }
}

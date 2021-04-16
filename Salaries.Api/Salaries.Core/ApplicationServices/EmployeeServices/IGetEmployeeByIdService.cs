using Salaries.Entities;
using System.Threading.Tasks;

namespace Salaries.Core.ApplicationServices.EmployeeServices
{
    public interface IGetEmployeeByIdService
    {
        Task<Employee> Get(int employeeId);
    }
}

using Salaries.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Salaries.Core.ApplicationServices.EmployeeServices
{
    public interface IGetAllEmployeeService
    {
        Task<IEnumerable<Employee>> Get();
    }
}

using Salaries.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Salaries.Core.Repositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAll();
    }
}

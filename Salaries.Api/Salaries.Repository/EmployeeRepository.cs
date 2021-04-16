using Salaries.Core.Repositories;
using Salaries.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Salaries.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly HttpClient httpClient;
        private readonly string apiUrl = "api/Employees";

        public EmployeeRepository(HttpClient httpClient) {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<Employee>> GetAll() {
            var responseString = await httpClient.GetStringAsync(apiUrl);

            var employees = JsonConvert.DeserializeObject<IEnumerable<Employee>>(responseString);
            return employees;
        }
    }
}

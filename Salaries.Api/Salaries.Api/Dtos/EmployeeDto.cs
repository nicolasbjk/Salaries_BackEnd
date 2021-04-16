using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Salaries.Api.Dtos
{
    public class EmployeeDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ContractTypeName { get; set; }

        public string RoleName { get; set; }

        public float HourlySalary { get; set; }

        public float MonthlySalary { get; set; }

        public float AnnualSalary { get; set; }
    }
}

using System;
using System.Threading.Tasks;
using Salaries.Core.ApplicationServices.EmployeeServices;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mapster;
using Salaries.Api.Dtos;
using System.Collections.Generic;

namespace Salaries.Api.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowOrigin")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IGetEmployeeByIdService getEmployeeByIdService;
        private readonly IGetAllEmployeeService getAllEmployeeService;

        public EmployeeController(
            IGetEmployeeByIdService getEmployeeByIdService, 
            IGetAllEmployeeService getAllEmployeeService) {
            this.getEmployeeByIdService = getEmployeeByIdService;
            this.getAllEmployeeService = getAllEmployeeService;
        }

        [HttpGet()]
        public async Task<ActionResult> Get() {
            try {
                var employees = await getAllEmployeeService.Get();
                var employeesDto = employees.Adapt<IEnumerable<EmployeeDto>>();

                return Ok(employeesDto);
            }
            catch (Exception ex) {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id) {
            try {
                if (id <= 0) return Ok();

                var employee = await getEmployeeByIdService.Get(id);
                var employeeDto = employee.Adapt<EmployeeDto>();

                return Ok(employeeDto);
            }
            catch (Exception ex) {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }
    }
}
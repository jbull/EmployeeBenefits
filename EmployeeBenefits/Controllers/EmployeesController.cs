using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using EmployeeBenefits.Data.Models;
using EmployeeBenefits.Data.Models.Dto;
using EmployeeBenefits.Data.Services.Interfaces;
using System.Net;

namespace EmployeeBenefits.Api.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger<EmployeesController> _logger;
        private readonly IEmployeeService _employeeService;
        private readonly IBenefitService _benefitService;

        public EmployeesController(IMapper mapper, ILogger<EmployeesController> logger, IEmployeeService employeeService, IBenefitService benefitService)
        {
            _mapper = mapper;
            _logger = logger;
            _employeeService = employeeService;
            _benefitService = benefitService;
        }

        // GET: api/Employees
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<EmployeeDto>))]
        [ProducesResponseType(403)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetEmployees()
        {
            try
            {
                var employees = await _employeeService.GetEmployees();

                var empsToReturn = _mapper.Map<IEnumerable<EmployeeDto>>(employees);

                return Ok(empsToReturn);
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                Console.WriteLine(e);
                //throw;
                return BadRequest("Unable to get Employees");
            }

        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(EmployeeDto))]
        [ProducesResponseType(403)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<EmployeeDto>> GetEmployee(int id)
        {
            try
            {
                var employee = await _employeeService.GetEmployeeById(id);

                var empToReturn = _mapper.Map<EmployeeDto>(employee);

                var benefits = await _benefitService.GetBenefitsCost(employee.Id);

                empToReturn.YearlySalary = benefits.YearlySalary;
                empToReturn.CheckGrossPay = benefits.CheckGrossPay;
                empToReturn.CostPerCheck = benefits.CostPerCheck;
                empToReturn.YearlyCost = benefits.YearlyCost;
                empToReturn.Discounts = benefits.Discounts;
                empToReturn.Dependents = benefits.Dependents;

                return Ok(empToReturn);
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                Console.WriteLine(e);
                //throw;
                return BadRequest("Unable to get Employees");
            }

        }

        // POST: api/Employees
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<EmployeeDto>> AddEmployee([FromBody] EmployeeAddDto employeeAddDto)
        {
            try
            {
                var employee = _mapper.Map<Employee>(employeeAddDto);

                var result = await _employeeService.AddOrUpdateEmployee(employee);

                var dataForReturn = _mapper.Map<EmployeeDto>(result);

                return CreatedAtAction("GetEmployee", new { id = dataForReturn.Id }, dataForReturn);
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                Console.WriteLine(e);
                //throw;
                return BadRequest("Unable to Add Employees");
            }

        }

        // PUT: api/Employees/5
        [HttpPut("{id}")]
        [Consumes("application/json")]
        [ProducesResponseType(202)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateEmployee(int id, [FromBody] EmployeeDto employeeDto)
        {
            if (id != employeeDto.Id)
            {
                return BadRequest("Id is invalid or missing");
            }

            try
            {
                var employee = _mapper.Map<Employee>(employeeDto);

                var result = await _employeeService.AddOrUpdateEmployee(employee);

                var dataForReturn = _mapper.Map<EmployeeDto>(result);

                return CreatedAtAction("GetEmployee", new { id = dataForReturn.Id }, dataForReturn);
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                Console.WriteLine(e);
                //throw;
                return BadRequest("Unable to Update Employees");
            }

        }


        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var result = await _employeeService.DeleteEmployee(id);

            return NoContent();
        }
    }
}

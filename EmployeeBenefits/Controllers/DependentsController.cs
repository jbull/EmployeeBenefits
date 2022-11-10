using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using EmployeeBenefits.Data.Models;
using EmployeeBenefits.Data.Models.Dto;
using EmployeeBenefits.Data.Services.Interfaces;

namespace EmployeeBenefits.Api.Controllers
{
    [Route("api/dependents")]
    [ApiController]
    public class DependentsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger<DependentsController> _logger;
        private readonly IDependentService _dependentService;

        public DependentsController(IMapper mapper, ILogger<DependentsController> logger, IDependentService dependentService)
        {
            _mapper = mapper;
            _logger = logger;
            _dependentService = dependentService;
        }

        [HttpGet("dependents/{id}")]
        public async Task<ActionResult<DependentDto>> GetDependents(int id)
        {
            try
            {
                var dependents = await _dependentService.GetDependents(id);

                var dataForReturn = _mapper.Map<IEnumerable<DependentDto>>(dependents);

                return Ok(dataForReturn);
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DependentDto>> GetDependent(int id)
        {
            try
            {
                var dependent = await _dependentService.GetDependentById(id);

                var empToReturn = _mapper.Map<EmployeeDto>(dependent);

                return Ok(empToReturn);
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                Console.WriteLine(e);
                throw;
            }

        }

        [HttpPost("dependents")]
        [Consumes("application/json")]
        public async Task<ActionResult<DependentDto>> AddDependent([FromBody] DependentAddDto dependentAddDto)
        {
            try
            {
                var dependent = _mapper.Map<Dependent>(dependentAddDto);

                var result = await _dependentService.AddOrUpdateDependent(dependent);

                var dataForReturn = _mapper.Map<DependentDto>(result);

                return CreatedAtAction("GetDependent", new { id = dataForReturn.Id }, dataForReturn);
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                Console.WriteLine(e);
                throw;
            }

        }

        [HttpDelete("depnendents/{id}")]
        public async Task<IActionResult> DeleteDependent(int id)
        {
            var result = await _dependentService.DeleteDependent(id);

            return NoContent();
        }
    }
}

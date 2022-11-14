using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using EmployeeBenefits.Data.Models;
using EmployeeBenefits.Data.Models.Dto;
using EmployeeBenefits.Data.Services.Interfaces;
using System.Net;

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

        [HttpGet("list/{id}")]
        [ProducesResponseType(200, Type = typeof(List<DependentDto>))]
        [ProducesResponseType(403)]
        [ProducesResponseType(404)]
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
                //throw;
                return BadRequest("Unable to Get Dependents");
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type= typeof(DependentDto))]
        [ProducesResponseType(403)]
        [ProducesResponseType(404)]
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
                //throw;
                return BadRequest("Unable to Get Dependent");
            }

        }

        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(201, Type = typeof(DependentDto))]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
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
                //throw;
                return BadRequest("Unable to Add Dependent");
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDependent(int id)
        {
            var result = await _dependentService.DeleteDependent(id);

            return NoContent();
        }
    }
}

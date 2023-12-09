using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpeechLive.Business.Dtos;
using SpeechLive.Business.Interfaces;

namespace SpeechLive.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost(Name = "CreateEmployee")]
        public async Task<IActionResult> Post(CreateEmployeeDto employee)
        {
            if (ModelState.IsValid)
            {
                await _employeeService.CreateEmployee(employee);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using SpeechLive.Business.Dtos;
using SpeechLive.Business.Interfaces;

namespace SpeechLive.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        [HttpPost(Name = "CreateDepartment")]
        public async Task<IActionResult> Post(CreateDepartmentDto department)
        {
            if(ModelState.IsValid)
            {
                var result = await _departmentService.CrateDepartment(department);
                if(!result)
                {
                    return StatusCode(500, "Unable to add department to database, something went wrong");
                }
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPatch(Name = "UpdateDepartment")]
        public async Task<IActionResult> Patch(UpdateDepartmentDto department)
        {
            if(ModelState.IsValid)
            {
                var response = await _departmentService.UpdateDepartment(department);
                if(response == false)
                {
                    return NotFound();
                }
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpGet("GetDepartmentsWithXEmployees/{numberOfEmployees}", Name = "GetDepartmentsWithXEmployees")]
        public async Task<List<DepartmentDto>> GetDepartmentsWithXEmployees(int numberOfEmployees)
        {
            if(numberOfEmployees < 1)
            {
                throw new Exception("Number must be positive");
            }
            return await _departmentService.GetDepartmentsWithXEmployees(numberOfEmployees);
        }
    }
}

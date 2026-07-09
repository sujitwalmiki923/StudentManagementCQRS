using Microsoft.AspNetCore.Mvc;
using StudentManagementCQRS.Features.Students.Commands.CreateStudent;

namespace StudentManagementCQRS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly CreateStudentCommandHandler _command;

        public StudentController(CreateStudentCommandHandler command) 
        {
            _command = command;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateStudentCommand command)
        {
            await _command.Handle(command);

            return Ok(new
                { 
                Message = "Student Created Succesfully"
            });
        }
        
    }
}

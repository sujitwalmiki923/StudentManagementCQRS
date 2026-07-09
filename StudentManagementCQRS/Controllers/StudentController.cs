using MediatR;
using Microsoft.AspNetCore.Mvc;
using StudentManagementCQRS.Features.Students.Commands.CreateStudent;
using StudentManagementCQRS.Features.Students.Queries.GetAllStudents;

namespace StudentManagementCQRS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        //Instead of Injectecting of every Command & Queries we can Inject Mediator
        private readonly IMediator _mediator;
        //private readonly CreateStudentCommandHandler _command;
        //private readonly GetAllStudentsQueryHandler _queryHandler;

        //public StudentController(CreateStudentCommandHandler command , GetAllStudentsQueryHandler queryHandler) 
        //{
        //    _command = command;
        //    _queryHandler = queryHandler;
        //}

        public StudentController(IMediator mediator)
        {
           _mediator = mediator;     
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateStudentCommand command)
        {
            //Handler Implemenation
            // await _command.Handle(command);

            //Mediator Implementation
            var Id = await _mediator.Send(command);

            return Ok(new
                { 
                StudentId = Id,
                Message = "Student Created Succesfully"
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //var students = await
            //    _queryHandler.Handle(new GetAllStudentQuery());

            var students = await
                             _mediator.Send(new GetAllStudentQuery());

            return Ok(students);
        }
        
    }
}

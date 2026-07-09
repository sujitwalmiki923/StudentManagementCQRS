using MediatR;
using StudentManagementCQRS.Data;
using StudentManagementCQRS.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace StudentManagementCQRS.Features.Students.Commands.CreateStudent
{
    public class CreateStudentCommandHandler
        : IRequestHandler<CreateStudentCommand,int>
    {
        private readonly ApplicationDbContext _context;

        public CreateStudentCommandHandler(ApplicationDbContext dbContext)
        {
                _context = dbContext;
        }

        //public async Task Handle(CreateStudentCommand command)
        //{
        //    var student = new Student
        //    {
        //        Name = command.Name,
        //        Age = command.Age,
        //        Email = command.Email,
        //        Department = command.Department,
        //    };

        //    _context.Students.Add(student);

        //    await _context.SaveChangesAsync();
        //}

        public async Task<int> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = new Student
            {
                Name = request.Name,
                Age = request.Age,
                Email = request.Email,
                Department = request.Department,
            };

            _context.Students.Add(student);

            await _context.SaveChangesAsync(cancellationToken);

            return student.Id;


            // throw new NotImplementedException();
        }
    }
}

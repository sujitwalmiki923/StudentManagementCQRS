using StudentManagementCQRS.Data;
using StudentManagementCQRS.Entities;

namespace StudentManagementCQRS.Features.Students.Commands.CreateStudent
{
    public class CreateStudentCommandHandler
    {
        private readonly ApplicationDbContext _context;

        public CreateStudentCommandHandler(ApplicationDbContext dbContext)
        {
                _context = dbContext;
        }

        public async Task Handle(CreateStudentCommand command)
        {
            var student = new Student
            {
                Name = command.Name,
                Age = command.Age,
                Email = command.Email,
                Department = command.Department,
            };

            _context.Students.Add(student);

            await _context.SaveChangesAsync();
        }
    }
}

using MediatR;
using Microsoft.EntityFrameworkCore;
using StudentManagementCQRS.Data;
using StudentManagementCQRS.DTOs;

namespace StudentManagementCQRS.Features.Students.Queries.GetAllStudents
{
    public class GetAllStudentsQueryHandler
        : IRequestHandler<GetAllStudentQuery , List<StudentDto>>
    {
        private readonly ApplicationDbContext _context;

        public GetAllStudentsQueryHandler(ApplicationDbContext context)
        {
            _context = context;    
        }

        //public async Task<List<StudentDto>> Handle(GetAllStudentQuery query)
        //{
        //    return await
        //         _context.Students
        //         .Select(student => new StudentDto
        //         {
        //             Id = student.Id,
        //             Name = student.Name,
        //             Age = student.Age,
        //             Email = student.Email,
        //             Department = student.Department,
        //         })
        //         .ToListAsync();
        //}

        public async Task<List<StudentDto>> Handle(GetAllStudentQuery request, CancellationToken cancellationToken)
        {
            //throw new NotImplementedException();
            return await
     _context.Students
     .Select(student => new StudentDto
     {
         Id = student.Id,
         Name = student.Name,
         Age = student.Age,
         Email = student.Email,
         Department = student.Department,
     })
     .ToListAsync(cancellationToken);
        }
    }
}

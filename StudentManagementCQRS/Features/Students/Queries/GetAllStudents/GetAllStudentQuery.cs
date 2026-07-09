using MediatR;
using StudentManagementCQRS.DTOs;

namespace StudentManagementCQRS.Features.Students.Queries.GetAllStudents
{
    public class GetAllStudentQuery : IRequest<List<StudentDto>>
    {
        public int Id { get; set; }
    }
}

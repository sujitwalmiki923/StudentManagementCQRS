namespace StudentManagementCQRS.Features.Students.Commands.CreateStudent
{
    public class CreateStudentCommand
    {
        public string Name { get; set; } = string.Empty;

        public int Age { get; set; }

        public string Email { get; set; } = string.Empty;

        public string Department { get; set; } = string.Empty;
    }
}

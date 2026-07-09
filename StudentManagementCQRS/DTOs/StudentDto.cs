namespace StudentManagementCQRS.DTOs
{
    public class StudentDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int Age { get; set; }

        public string Email { get; set; } = string.Empty;

        public string Department { get; set; } = string.Empty;
    }
}

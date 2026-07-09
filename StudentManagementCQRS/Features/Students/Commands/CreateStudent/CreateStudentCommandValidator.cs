using FluentValidation;

namespace StudentManagementCQRS.Features.Students.Commands.CreateStudent
{
    public class CreateStudentCommandValidator : 
        AbstractValidator<CreateStudentCommand>
    {

        public CreateStudentCommandValidator()
        {
            RuleFor(x => x.Name)
               .NotEmpty()
               .MaximumLength(100);

            RuleFor(x => x.Age)
                .InclusiveBetween(18, 60);

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Department)
                .NotEmpty();
        }
    }
}

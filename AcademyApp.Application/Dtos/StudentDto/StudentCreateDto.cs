using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace AcademyApp.Application.Dtos.StudentDto
{
    public class StudentCreateDto
    {
        public int GroupId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDay { get; set; }
        public IFormFile File { get; set; }
    }
    public class StudentCreateDtoValidator : AbstractValidator<StudentCreateDto>
    {
        public StudentCreateDtoValidator()
        {
            RuleFor(s => s.Name).NotEmpty().MaximumLength(35).MinimumLength(4);
            RuleFor(s => s.Email).EmailAddress().NotEmpty().MaximumLength(100).MinimumLength(5);
            RuleFor(s => s.BirthDay.Date).LessThanOrEqualTo(DateTime.Now.AddYears(-15));
            RuleFor(s => s).Custom((s, c) =>
            {
                if (s.Name != null && !char.IsUpper(s.Name[0]))
                {
                    c.AddFailure(nameof(s.Name), "Fullname must start with uppercase");
                }
            });
            RuleFor(s => s).Custom((s, c) =>
            {
                if (s.File != null && s.File.Length / 1024 > 300)
                {
                    c.AddFailure("File", "File size must less than 300");
                }
                if (!(s.File != null && s.File.ContentType.Contains("image/")))
                {
                    c.AddFailure("File", "File  must only image");
                }
            });
        }
    }
}

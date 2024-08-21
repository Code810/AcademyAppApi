using FluentValidation;

namespace AcademyApp.Application.Dtos.GroupDto
{
    public class GroupCreateDto
    {
        public string Name { get; set; }
        public int Limit { get; set; }
    }

    public class GroupCreateDtoValidator : AbstractValidator<GroupCreateDto>
    {
        public GroupCreateDtoValidator()
        {
            RuleFor(g => g.Name).NotEmpty().MaximumLength(5).MinimumLength(4);
            RuleFor(g => g.Limit).NotEmpty().GreaterThanOrEqualTo(5).LessThanOrEqualTo(18);
        }
    }
}

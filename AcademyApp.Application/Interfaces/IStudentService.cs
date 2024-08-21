using AcademyApp.Application.Dtos.StudentDto;

namespace AcademyApp.Application.Interfaces
{
    public interface IStudentService
    {
        int Create(StudentCreateDto studentCreateDto);
    }
}

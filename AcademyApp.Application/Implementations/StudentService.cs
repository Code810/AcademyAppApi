using AcademyApp.Application.Dtos.StudentDto;
using AcademyApp.Application.Exceptions;
using AcademyApp.Application.Interfaces;
using AcademyApp.Core.Entities;
using AcademyApp.Data.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AcademyApp.Application.Implementations
{
    public class StudentService : IStudentService
    {
        private readonly AcademyContext _context;
        private readonly IMapper _mapper;

        public StudentService(AcademyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Create(StudentCreateDto studentCreateDto)
        {
            var group = _context.groups
                .Include(g => g.Students)
                .FirstOrDefault(g => g.Id == studentCreateDto.GroupId);
            if (group == null)
            {
                throw new CustomException(404, "Id", "Group Not Found");
            }
            if (group.Students.Count >= group.Limit)
            {
                throw new CustomException(400, "Limit", "Group is full");

            }
            var student = _mapper.Map<Student>(studentCreateDto);
            _context.students.Add(student);
            _context.SaveChanges();
            return student.Id;
        }

        public List<StudentReturnDto> GetAll()
        {
            return _mapper.Map<List<StudentReturnDto>>(_context.students.Include(s => s.Group).ToList());
        }
    }
}

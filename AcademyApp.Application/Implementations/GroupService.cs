using AcademyApp.Application.Dtos.GroupDto;
using AcademyApp.Application.Exceptions;
using AcademyApp.Application.Interfaces;
using AcademyApp.Core.Entities;
using AcademyApp.Data.Data;
using AutoMapper;

namespace AcademyApp.Application.Implementations
{
    public class GroupService : IGroupService
    {
        private readonly AcademyContext _context;
        private readonly IMapper _mapper;
        public GroupService(AcademyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public int Create(GroupCreateDto groupCreateDto)
        {
            if (_context.groups.Any(g => g.Name == groupCreateDto.Name))
                throw new CustomException(400, "Name", "Dublicate entity");
            var group = _mapper.Map<Group>(groupCreateDto);
            _context.groups.Add(group);
            _context.SaveChanges();
            return group.Id;
        }

        public List<Group> GetAll()
        {
            return _context.groups.ToList();
        }
    }
}

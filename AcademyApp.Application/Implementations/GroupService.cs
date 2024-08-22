using AcademyApp.Application.Dtos.GroupDto;
using AcademyApp.Application.Exceptions;
using AcademyApp.Application.Interfaces;
using AcademyApp.Core.Entities;
using AcademyApp.Data.Implementations;
using AutoMapper;

namespace AcademyApp.Application.Implementations
{
    public class GroupService : IGroupService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GroupService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<int> Create(GroupCreateDto groupCreateDto)
        {
            if (await _unitOfWork.groupRepository.IsExist(g => g.Name == groupCreateDto.Name))
                throw new CustomException(400, "Name", "Dublicate entity");
            var group = _mapper.Map<Group>(groupCreateDto);
            await _unitOfWork.groupRepository.Create(group);
            await _unitOfWork.Commit();
            return group.Id;
        }

        public async Task<Group> Get(string name)
        {
            return await _unitOfWork.groupRepository.GetEntity(g => g.Name == name);
        }

        public async Task<List<Group>> GetAll()
        {
            return await _unitOfWork.groupRepository.GetAll();
        }
    }
}

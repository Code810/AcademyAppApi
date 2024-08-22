using AcademyApp.Application.Dtos.GroupDto;
using AcademyApp.Core.Entities;

namespace AcademyApp.Application.Interfaces
{
    public interface IGroupService
    {
        Task<int> Create(GroupCreateDto groupCreateDto);
        Task<List<Group>> GetAll();
        Task<Group> Get(string name);
    }
}

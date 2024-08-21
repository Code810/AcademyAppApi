using AcademyApp.Application.Dtos.GroupDto;
using AcademyApp.Core.Entities;

namespace AcademyApp.Application.Interfaces
{
    public interface IGroupService
    {
        public int Create(GroupCreateDto groupCreateDto);
        List<Group> GetAll();
    }
}

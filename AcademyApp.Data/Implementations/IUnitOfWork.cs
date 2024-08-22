using AcademyApp.Core.Repositories;

namespace AcademyApp.Data.Implementations
{
    public interface IUnitOfWork
    {
        public IGroupRepository groupRepository { get; }
        public Task Commit();
    }
}

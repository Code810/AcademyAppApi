using AcademyApp.Core.Entities;
using AcademyApp.Core.Repositories;
using AcademyApp.Data.Data;

namespace AcademyApp.Data.Implementations
{
    public class GroupRepository : Repository<Group>, IGroupRepository
    {
        public GroupRepository(AcademyContext context) : base(context)
        {
        }
    }
}

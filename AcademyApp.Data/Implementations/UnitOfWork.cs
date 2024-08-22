using AcademyApp.Core.Repositories;
using AcademyApp.Data.Data;

namespace AcademyApp.Data.Implementations
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly AcademyContext _context;
        public IGroupRepository groupRepository { get; private set; }
        public UnitOfWork(AcademyContext context)
        {
            _context = context;
            groupRepository = new GroupRepository(_context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }
    }
}

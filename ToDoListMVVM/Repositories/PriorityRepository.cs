using ToDoListMVVM.Interface;
using ToDoListMVVM.Models;

namespace ToDoListMVVM.Repositories
{
    internal class PriorityRepository(AppDbContext appDbContext) : IPriorityRepository
    {
        private readonly AppDbContext _appDbContext = appDbContext;

        public IEnumerable<Priority> GetAll()
        {
            return _appDbContext.Priorities;
        }
    }
}
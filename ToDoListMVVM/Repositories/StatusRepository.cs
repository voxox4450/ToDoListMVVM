using ToDoListMVVM.Entities;
using ToDoListMVVM.Interface;
using ToDoListMVVM.Models;

namespace ToDoListMVVM.Repositories
{
    internal class StatusRepository(AppDbContext appDbContext) : IStatusRepository
    {
        private readonly AppDbContext _appDbContext = appDbContext;

        public IEnumerable<Status> GetAll()
        {
            return _appDbContext.Statuses;
        }
    }
}
using ToDoListMVVM.Interface;
using ToDoListMVVM.Models;

namespace ToDoListMVVM.Services
{
    internal class StatusService(IStatusRepository statusRepository) : IStatusService
    {
        private readonly IStatusRepository _statusRepository = statusRepository;

        public IEnumerable<Status> GetAll()
        {
            return _statusRepository.GetAll();
        }
    }
}
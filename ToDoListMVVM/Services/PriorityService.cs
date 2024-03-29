using ToDoListMVVM.Interface;
using ToDoListMVVM.Models;

namespace ToDoListMVVM.Services
{
    internal class PriorityService(IPriorityRepository priorityRepository) : IPriorityService
    {
        private readonly IPriorityRepository _priorityRepository = priorityRepository;

        public IEnumerable<Priority> GetAll()
        {
            return _priorityRepository.GetAll();
        }
    }
}
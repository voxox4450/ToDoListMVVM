using ToDoListMVVM.Models;

namespace ToDoListMVVM.Interface
{
    public interface IPriorityRepository
    {
        IEnumerable<Priority> GetAll();
    }
}
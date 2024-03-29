using ToDoListMVVM.Models;

namespace ToDoListMVVM.Interface
{
    public interface IPriorityService
    {
        IEnumerable<Priority> GetAll();
    }
}
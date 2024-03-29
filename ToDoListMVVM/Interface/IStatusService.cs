using ToDoListMVVM.Models;

namespace ToDoListMVVM.Interface
{
    public interface IStatusService
    {
        IEnumerable<Status> GetAll();
    }
}
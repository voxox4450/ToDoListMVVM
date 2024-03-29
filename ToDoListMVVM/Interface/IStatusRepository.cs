using ToDoListMVVM.Models;

namespace ToDoListMVVM.Interface
{
    public interface IStatusRepository
    {
        IEnumerable<Status> GetAll();
    }
}
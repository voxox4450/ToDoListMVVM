using ToDoListMVVM.Entities;

namespace ToDoListMVVM.Interface
{
    public interface IStatusRepository
    {
        IEnumerable<Status> GetAll();
    }
}
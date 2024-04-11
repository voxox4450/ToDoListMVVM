using ToDoListMVVM.Entities;

namespace ToDoListMVVM.Interface
{
    public interface IStatusService
    {
        IEnumerable<Status> GetAll();
    }
}
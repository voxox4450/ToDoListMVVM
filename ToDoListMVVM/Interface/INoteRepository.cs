using ToDoListMVVM.Entities;

namespace ToDoListMVVM.Interface
{
    public interface INoteRepository
    {
        void Add(Note noteToAdd);

        void Update(Note noteToUpdate);

        void Delete(Note noteToRemove);

        IEnumerable<Note> GetAll();
    }
}
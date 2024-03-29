using ToDoListMVVM.Models;

namespace ToDoListMVVM.Interface
{
    public interface INoteRepository
    {
        void Add(Note noteToAdd);

        void Update(Note noteToUpdate);

        void Delete(Note noteToRemove);

        IEnumerable<Note> GetAll();

        Note Find(int id);
    }
}
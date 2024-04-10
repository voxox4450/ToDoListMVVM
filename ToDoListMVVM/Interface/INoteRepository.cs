using ToDoListMVVM.Entities;

namespace ToDoListMVVM.Interface
{
    public interface INoteRepository
    {
        void Add(Note note);

        void Update(Note note);

        void Delete(Note note);

        IEnumerable<Note> GetAll();

        Note? Get(int noteId);
    }
}
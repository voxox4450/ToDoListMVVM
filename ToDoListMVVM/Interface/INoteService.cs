using ToDoListMVVM.Entities;

namespace ToDoListMVVM.Interface
{
    public interface INoteService
    {
        void Remove(Note note);

        IEnumerable<Note> GetAll();

        void Add(Note newNote);

        void Edit(Note existingNote, Note newNote);
    }
}
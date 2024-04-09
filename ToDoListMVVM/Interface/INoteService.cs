using ToDoListMVVM.Entities;

namespace ToDoListMVVM.Interface
{
    public interface INoteService
    {
        void Remove(Note note);

        IEnumerable<Note> GetAll();

        void Add(Note note);

        void Edit(Note existingNote, Note newNote);

        Note? Get(int noteId);

        event EventHandler<Note> NoteAdded;
    }
}
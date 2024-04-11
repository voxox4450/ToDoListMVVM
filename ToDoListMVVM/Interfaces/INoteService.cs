using ToDoListMVVM.Entities;

namespace ToDoListMVVM.Interface
{
    public interface INoteService
    {
        void Remove(int id);

        IEnumerable<Note> GetAll();

        void Add(Note note);

        void Edit(Note existingNote, Note note);

        Note? Get(int noteId);

        event EventHandler<Note> NoteAdded;

        event EventHandler<int> NoteDeleted;

        event EventHandler<Note> NoteEdited;
    }
}
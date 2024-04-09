using ToDoListMVVM.Entities;
using ToDoListMVVM.Interface;

namespace ToDoListMVVM.Services
{
    public class NoteService(INoteRepository noteRepository) : INoteService
    {
        private readonly INoteRepository _noteRepository = noteRepository;

        public event EventHandler<Note>? NoteAdded;

        public event EventHandler<Note>? NoteDeleted;

        public event EventHandler<Note>? NoteEdited;

        public void Add(Note note)
        {
            _noteRepository.Add(note);

            var newNote = Get(note.Id);
            if (newNote != null)
            {
                NoteAdded?.Invoke(this, newNote);
            }
        }

        public Note? Get(int noteId)
        {
            return _noteRepository.Get(noteId);
        }

        public void Edit(Note existingNote, Note note)
        {
            existingNote.ContentText = note.ContentText;
            existingNote.StartDate = note.StartDate;
            existingNote.EndDate = note.EndDate;
            existingNote.PriorityId = note.PriorityId;
            existingNote.StatusId = note.StatusId;

            _noteRepository.Update(existingNote);
            var newNote = Get(existingNote.Id);
            if (newNote != null)
            {
                NoteEdited?.Invoke(this, newNote);
            }
        }

        public void Remove(Note note)
        {
            var newNote = Get(note.Id);
            if (newNote != null)
            {
                NoteDeleted?.Invoke(this, newNote);
            }
            _noteRepository.Delete(note);
        }

        public IEnumerable<Note> GetAll()
        {
            return _noteRepository.GetAll();
        }
    }
}
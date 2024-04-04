using System.Windows;
using ToDoListMVVM.Entities;
using ToDoListMVVM.Interface;
using ToDoListMVVM.Views;

namespace ToDoListMVVM.Services
{
    public class NoteService(INoteRepository noteRepository) : INoteService

    {
        private readonly INoteRepository _noteRepository = noteRepository;

        public void Add(Note newNote)
        {
            _noteRepository.Add(newNote);
        }

        public void Edit(Note existingNote, Note newNote)
        {
            existingNote.ContentText = newNote.ContentText;
            existingNote.StartDate = newNote.StartDate;
            existingNote.EndDate = newNote.EndDate;
            existingNote.PriorityId = newNote.PriorityId;
            existingNote.StatusId = newNote.StatusId;

            _noteRepository.Update(existingNote);
        }

        public void Remove(Note note)
        {
            _noteRepository.Delete(note);
        }

        public IEnumerable<Note> GetAll()
        {
            return _noteRepository.GetAll();
        }
    }
}
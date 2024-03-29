using System.Windows;
using ToDoListMVVM.Entities;
using ToDoListMVVM.Interface;
using ToDoListMVVM.Views;

namespace ToDoListMVVM.Services
{
    public class NoteService(INoteRepository noteRepository) : INoteService

    {
        private readonly INoteRepository _noteRepository = noteRepository;

        //TODO: parametrem ma byc notatka
        public void Add(string Content,
            DateTime StartDate,
            DateTime EndDate,
            int Priority,
            int Statuses)
        {
            var newNote = new Note()
            {
                ContentText = Content,
                StartDate = StartDate,

                EndDate = EndDate,

                PriorityId = Priority,

                StatusId = Statuses,
            };
            _noteRepository.Add(newNote);
        }

        //TODO: parametrem ma byc notatka
        public void Edit(Note existingNote,
            string Content,
            DateTime StartDate,
            DateTime EndDate,
            int Priority,
            int Statuses)
        {
            existingNote.ContentText = Content;
            existingNote.StartDate = StartDate;
            existingNote.EndDate = EndDate;
            existingNote.PriorityId = Priority;
            existingNote.StatusId = Statuses;

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
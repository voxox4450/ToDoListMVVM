using System.Windows;
using ToDoListMVVM.Entities;
using ToDoListMVVM.Interface;
using ToDoListMVVM.Views;

namespace ToDoListMVVM.Services
{
    public class NoteService(INoteRepository noteRepository) : INoteService

    {
        private Window? _dialog;
        private readonly INoteRepository _noteRepository = noteRepository;

        //TODO: przeniesc np do innego serwisu
        public void ShowAdd()
        {
            _dialog = new Window
            {
                Title = "Dodaj zadanie do ToDoList",
                Content = new UserControlAdd(),
                SizeToContent = SizeToContent.WidthAndHeight,
            };
            _dialog.ShowDialog();
        }

        public void ShowEdit(Note note)
        {
            _dialog = new Window
            {
                Title = "Edytuj zadanie",
                Content = new UserControlEdit(note),
                SizeToContent = SizeToContent.WidthAndHeight,
            };
            _dialog.ShowDialog();
        }

        public void CloseDialog()
        {
            _dialog?.Close();
        }

        //TODO: parametrem ma byc notatka
        public void Add(string noteContent, DateTime noteStartDate, DateTime noteEndDate, int notePrio, int noteSta)
        {
            var newNote = new Note()
            {
                ContentText = noteContent,
                StartDate = noteStartDate,

                EndDate = noteEndDate,

                PriorityId = notePrio,

                StatusId = noteSta,
            };
            _noteRepository.Add(newNote);
        }

        //TODO: parametrem ma byc notatka
        public void Edit(Note existingNote,
            string noteContent,
            DateTime noteStartDate,
            DateTime noteEndDate,
            int notePrio,
            int noteSta)
        {
            existingNote.ContentText = noteContent;
            existingNote.StartDate = noteStartDate;
            existingNote.EndDate = noteEndDate;
            existingNote.PriorityId = notePrio;
            existingNote.StatusId = noteSta;

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
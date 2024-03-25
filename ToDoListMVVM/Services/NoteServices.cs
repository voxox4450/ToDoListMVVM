using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ToDoListMVVM.Interface;
using ToDoListMVVM.Models;
using ToDoListMVVM.Views;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace ToDoListMVVM.Services
{
    public class NoteService(INoteRepository noteRepository) : INoteService

    {
        private Window _dialog;
        private readonly INoteRepository _noteRepository = noteRepository;

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
            if (_dialog != null)
            {
                _dialog.Close();
            }
        }

        public Note Add(string noteContent, DateTime noteStartDate, DateTime noteEndDate, int notePrio, int noteSta)
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
            return newNote;
        }

        public Note Edit(Note existingNote, string noteContent, DateTime noteStartDate, DateTime noteEndDate, int notePrio, int noteSta)
        {
            existingNote.ContentText = noteContent;
            existingNote.StartDate = noteStartDate;
            existingNote.EndDate = noteEndDate;
            existingNote.PriorityId = notePrio;
            existingNote.StatusId = noteSta;
            _noteRepository.Update(existingNote);
            return existingNote;
        }

        public void Remove(Note note)
        {
            _noteRepository.Delete(note);
        }

        public Note FindNote(int id)
        {
            return _noteRepository.Find(id);
        }

        public IEnumerable<Note> GetAll()
        {
            return _noteRepository.GetAll();
        }
    }
}
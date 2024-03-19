using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListMVVM.Interface;
using ToDoListMVVM.Models;

namespace ToDoListMVVM.Services
{
    public class NoteService : INoteService
    {
        private readonly List<Note> _notes = new List<Note>();

        public NoteService()
        { }

        public void AddNote(Note note)
        {
            _notes.Add(note);
        }
    }
}
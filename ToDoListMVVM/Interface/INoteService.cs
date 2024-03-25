using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListMVVM.Models;

namespace ToDoListMVVM.Interface
{
    public interface INoteService
    {
        void ShowAdd();

        void ShowEdit(Note note);

        void CloseDialog();

        void Remove(Note note);

        Note FindNote(int id);

        IEnumerable<Note> GetAll();

        Note Add(string noteContent, DateTime noteStartDate, DateTime noteEndDate, int notePrio, int noteSta);

        Note Edit(Note existingNote, string noteContent, DateTime noteStartDate, DateTime noteEndDate, int notePrio, int noteSta);
    }
}
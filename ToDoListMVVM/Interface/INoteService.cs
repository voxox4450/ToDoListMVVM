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
        void ShowDialog();

        void CloseDialog();

        void Remove(int id);

        Note FindNote(int id);

        IEnumerable<Note> GetAll();

        Note Add(string noteContent, DateTime noteStartDate, DateTime noteEndDate, int notePrio, int noteSta);
    }
}
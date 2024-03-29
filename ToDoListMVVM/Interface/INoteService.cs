using ToDoListMVVM.Models;

namespace ToDoListMVVM.Interface
{
    public interface INoteService
    {
        void ShowAdd();

        void ShowEdit(Note note);

        void CloseDialog();

        void Remove(Note note);

        IEnumerable<Note> GetAll();

        Note Add(string noteContent, DateTime noteStartDate, DateTime noteEndDate, int notePrio, int noteSta);

        Note Edit(Note existingNote, string noteContent, DateTime noteStartDate, DateTime noteEndDate, int notePrio, int noteSta);
    }
}
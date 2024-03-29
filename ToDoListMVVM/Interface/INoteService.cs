using ToDoListMVVM.Entities;

namespace ToDoListMVVM.Interface
{
    public interface INoteService
    {
        void ShowAdd();

        void ShowEdit(Note note);

        void CloseDialog();

        void Remove(Note note);

        IEnumerable<Note> GetAll();

        void Add(string noteContent, DateTime noteStartDate, DateTime noteEndDate, int notePrio, int noteSta);

        void Edit(Note existingNote, string noteContent, DateTime noteStartDate, DateTime noteEndDate, int notePrio, int noteSta);
    }
}
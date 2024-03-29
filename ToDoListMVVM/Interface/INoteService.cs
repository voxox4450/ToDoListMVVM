using ToDoListMVVM.Entities;

namespace ToDoListMVVM.Interface
{
    public interface INoteService
    {
        //void ShowAdd();

        //void ShowEdit(Note note);

        //void CloseDialog();

        void Remove(Note note);

        IEnumerable<Note> GetAll();

        void Add(string Content, DateTime StartDate, DateTime EndDate, int Priority, int Statuses);

        void Edit(Note existingNote, string Content, DateTime StartDate, DateTime EndDate, int Priority, int Statuses);
    }
}
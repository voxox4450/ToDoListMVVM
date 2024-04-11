using ToDoListMVVM.Entities;

namespace ToDoListMVVM.Interface
{
    public interface IDialogService
    {
        void CloseDialog();

        void ShowAdd();

        void ShowEdit(Note note);
    }
}
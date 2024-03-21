using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ToDoListMVVM.Views;

namespace ToDoListMVVM.ViewModel
{
    public interface IDialogService
    {
        void ShowDialog();
    }

    public class DialogsServices : IDialogService
    {
        public void ShowDialog()
        {
            var dialog = new Window
            {
                Title = "Dodaj zadanie do ToDoList",
                Content = new UserControlAdd(),
                SizeToContent = SizeToContent.WidthAndHeight,
            };
            dialog.ShowDialog();
        }
    }
}
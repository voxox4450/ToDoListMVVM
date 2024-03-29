using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ToDoListMVVM.Entities;
using ToDoListMVVM.Interface;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using ToDoListMVVM.Views;

namespace ToDoListMVVM.Services
{
    public class DialogService : IDialogService
    {
        private Window? _dialog;

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
    }
}
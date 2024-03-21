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
    public class NoteService : INoteService
    {
        private Window _dialog;

        public void ShowDialog()
        {
            _dialog = new Window
            {
                Title = "Dodaj zadanie do ToDoList",
                Content = new UserControlAdd(),
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
    }
}
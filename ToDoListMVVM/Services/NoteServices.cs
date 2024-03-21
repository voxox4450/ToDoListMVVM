using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ToDoListMVVM.Interface;
using ToDoListMVVM.Models;
using ToDoListMVVM.Views;

namespace ToDoListMVVM.Services
{
    public class NoteService : INoteService
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
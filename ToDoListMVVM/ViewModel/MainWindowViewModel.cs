using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using ToDoListMVVM.Models;
using ToDoListMVVM.Views;
using Serilog;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ToDoListMVVM;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

namespace ToDoListMVVM.ViewModel
{
    public class MainWindowViewModel
    {
        public ICommand ExitCommand { get; }
        public ICommand AddNoteComand { get; }

        public MainWindowViewModel()
        {
            ExitCommand = new RelayCommand(ExitApplication);
            AddNoteComand = new RelayCommand(NextPage);
        }

        private void ExitApplication()
        {
            Application.Current.Shutdown();
        }

        private void NextPage()
        {
            //MessengerInstance.Send(new OpenDialogMessage(typeof(UserControlAddViewModel), "Dodaj notatkę"));
        }
    }
}
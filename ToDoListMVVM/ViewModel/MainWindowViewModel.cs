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

namespace ToDoListMVVM.ViewModel
{
    public class MainWindowViewModel
    {
        public ICommand ExitCommand { get; }

        public MainWindowViewModel()
        {
            ExitCommand = new RelayCommand(ExitApplication);
        }

        private void ExitApplication()
        {
            Application.Current.Shutdown();
        }
    }
}
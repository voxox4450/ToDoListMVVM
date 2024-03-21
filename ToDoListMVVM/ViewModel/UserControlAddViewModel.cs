using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ToDoListMVVM.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using GalaSoft.MvvmLight.Views;
using ToDoListMVVM.Interface;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace ToDoListMVVM.ViewModel
{
    public class UserControlAddViewModel
    {
        public ICommand ExitAddCommand { get; }
        private INoteService _noteService;

        public UserControlAddViewModel(INoteService noteService)
        {
            _noteService = noteService;
            ExitAddCommand = new RelayCommand(ExitCommand);
        }

        private void ExitCommand()
        {
            _noteService.CloseDialog();
        }
    }
}
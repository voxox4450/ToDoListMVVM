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
using ToDoListMVVM.Services;
using ToDoListMVVM.Views;

namespace ToDoListMVVM.ViewModel
{
    public class UserControlAddViewModel
    {
        public ICommand ExitAddCommand { get; }
        private readonly INoteService _noteService;
        private readonly IPriorityService _priorityService;
        private readonly IStatusService _statusService;
        public List<Priority> NotePrio { get; set; }
        public List<Status> NoteStatus { get; set; }
        public DateTime StartDateNote { get; set; }
        public DateTime EndDateNote { get; set; }

        public UserControlAddViewModel(INoteService noteService, IPriorityService priorityService, IStatusService statusService)
        {
            _noteService = noteService;
            _priorityService = priorityService;
            _statusService = statusService;
            NotePrio = [.. _priorityService.GetAll()];

            NoteStatus = [.. _statusService.GetAll()];

            ExitAddCommand = new RelayCommand(ExitCommand);
        }

        private void ExitCommand()
        {
            _noteService.CloseDialog();
        }
    }
}
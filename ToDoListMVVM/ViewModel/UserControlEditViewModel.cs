using CommunityToolkit.Mvvm.Input;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ToDoListMVVM.Interface;
using ToDoListMVVM.Models;

namespace ToDoListMVVM.ViewModel
{
    public class UserControlEditViewModel
    {
        public UserControlEditViewModel(INoteService noteService, IPriorityService priorityService, IStatusService statusService)
        {
            _noteService = noteService;
            _priorityService = priorityService;
            _statusService = statusService;
            TextEdit = string.Empty;
            StartDateEdit = DateTime.Today;
            EndDateEdit = DateTime.Today;
            EditPrio = [.. _priorityService.GetAll()];
            EditStatus = [.. _statusService.GetAll()];

            ExitEditCommand = new RelayCommand(ExitCommand);
        }

        private readonly INoteService _noteService;
        private readonly IPriorityService _priorityService;
        private readonly IStatusService _statusService;
        public List<Priority> EditPrio { get; set; }
        public List<Status> EditStatus { get; set; }
        public int SelectedPrio { get; set; }
        public int SelectedStatus { get; set; }

        public DateTime StartDateEdit { get; set; }
        public DateTime EndDateEdit { get; set; }
        public string TextEdit { get; set; }
        public ICommand ExitEditCommand { get; }

        private void ExitCommand()
        {
            _noteService.Edit(TextEdit, StartDateEdit, EndDateEdit, SelectedPrio, SelectedStatus);
            _noteService.CloseDialog();
        }
    }
}
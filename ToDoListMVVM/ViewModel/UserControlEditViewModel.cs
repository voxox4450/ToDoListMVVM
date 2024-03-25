using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Input;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
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
        public UserControlEditViewModel(Note note)
        {
            _noteService = Ioc.Default.GetRequiredService<INoteService>();
            _priorityService = Ioc.Default.GetRequiredService<IPriorityService>();
            _statusService = Ioc.Default.GetRequiredService<IStatusService>();
            _noteToEdit = note;
            TextEdit = _noteToEdit.ContentText;
            StartDateEdit = _noteToEdit.StartDate;
            EndDateEdit = _noteToEdit.EndDate;
            SelectedPrio = _noteToEdit.PriorityId;
            SelectedStatus = _noteToEdit.StatusId;

            EditPrio = [.. _priorityService.GetAll()];
            EditStatus = [.. _statusService.GetAll()];

            ExitEditCommand = new RelayCommand(ExitCommand);
            _noteToEdit = note;
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
        private readonly Note _noteToEdit;

        private void ExitCommand()
        {
            if (StartDateEdit > EndDateEdit)
            {
                MessageBox.Show("Błąd: Data rozpoczęcia musi być mniejsza niż data zakończenia.");
            }
            else
            {
                _noteService.Edit(_noteToEdit, TextEdit, StartDateEdit, EndDateEdit, SelectedPrio, SelectedStatus);
                _noteService.CloseDialog();
            }
        }
    }
}
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
using System.Collections.ObjectModel;

namespace ToDoListMVVM.ViewModel
{
    public class UserControlAddViewModel
    {
        public UserControlAddViewModel(INoteService noteService, IPriorityService priorityService, IStatusService statusService)
        {
            _noteService = noteService;
            _priorityService = priorityService;
            _statusService = statusService;
            TextNote = string.Empty;
            StartDateNote = DateTime.Today;
            EndDateNote = DateTime.Today;
            NotePrio = [.. _priorityService.GetAll()];
            NoteStatus = [.. _statusService.GetAll()];

            ExitAddCommand = new RelayCommand(ExitCommand);
        }

        public ICommand ExitAddCommand { get; }
        private readonly INoteService _noteService;
        private readonly IPriorityService _priorityService;
        private readonly IStatusService _statusService;
        public List<Priority> NotePrio { get; set; }
        public List<Status> NoteStatus { get; set; }
        public int SelectedPrio { get; set; }
        public int SelectedStatus { get; set; }
        public DateTime StartDateNote { get; set; }
        public DateTime EndDateNote { get; set; }
        public string TextNote { get; set; }

        private void ExitCommand()
        {
            if (StartDateNote > EndDateNote)
            {
                MessageBox.Show("Błąd: Data rozpoczęcia musi być mniejsza niż data zakończenia.");
            }
            else
            {
                _noteService.Add(TextNote, StartDateNote, EndDateNote, SelectedPrio, SelectedStatus);
                _noteService.CloseDialog();
            }
        }
    }
}
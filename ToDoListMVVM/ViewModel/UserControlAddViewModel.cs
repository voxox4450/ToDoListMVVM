using System.Windows;
using ToDoListMVVM.Models;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using ToDoListMVVM.Interface;

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
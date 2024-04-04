using System.Windows;
using ToDoListMVVM.Models;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using ToDoListMVVM.Interface;
using ToDoListMVVM.Entities;

namespace ToDoListMVVM.ViewModel
{
    public class AddViewModel
    {
        private readonly INoteService _noteService;
        private readonly IDialogService _dialogService;

        public AddViewModel(INoteService noteService, IPriorityService priorityService, IStatusService statusService, IDialogService dialogService)
        {
            _noteService = noteService;
            _dialogService = dialogService;
            TextNote = string.Empty;
            StartDate = DateTime.Today;
            EndDate = DateTime.Today;
            Priorities = [.. priorityService.GetAll()];
            Statuses = [.. statusService.GetAll()];

            AddCommand = new RelayCommand(Add);
        }

        public ICommand AddCommand { get; }

        public List<Priority> Priorities { get; set; }

        public List<Status> Statuses { get; set; }
        public int SelectedPriorities { get; set; }
        public int SelectedStatuses { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string TextNote { get; set; }

        private void Add()
        {
            if (StartDate > EndDate)
            {
                MessageBox.Show("Błąd: Data rozpoczęcia musi być mniejsza niż data zakończenia.");
            }
            else
            {
                var newNote = new Note()
                {
                    ContentText = TextNote,
                    StartDate = StartDate,
                    EndDate = EndDate,
                    PriorityId = SelectedPriorities,
                    StatusId = SelectedStatuses
                };
                _noteService.Add(newNote);
                _dialogService.CloseDialog();
            }
        }
    }
}
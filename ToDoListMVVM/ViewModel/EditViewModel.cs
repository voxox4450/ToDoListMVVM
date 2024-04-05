using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Input;
using System.Windows;
using System.Windows.Input;
using ToDoListMVVM.Entities;
using ToDoListMVVM.Interface;
using ToDoListMVVM.Models;

namespace ToDoListMVVM.ViewModel
{
    public class EditViewModel
    {
        private readonly INoteService _noteService;
        private readonly IPriorityService _priorityService;
        private readonly IStatusService _statusService;
        private readonly IDialogService _dialogService;
        private readonly Note _noteToEdit;

        private readonly Action<object, Note> _noteEditedCallback;

        public EditViewModel(Note note)
        {
            _noteService = Ioc.Default.GetRequiredService<INoteService>();
            _priorityService = Ioc.Default.GetRequiredService<IPriorityService>();
            _statusService = Ioc.Default.GetRequiredService<IStatusService>();
            _dialogService = Ioc.Default.GetRequiredService<IDialogService>();

            _noteToEdit = note;
            TextEdit = _noteToEdit.ContentText;
            StartDate = _noteToEdit.StartDate;
            EndDate = _noteToEdit.EndDate;
            SelectedPriorities = _noteToEdit.PriorityId;
            SelectedStatuses = _noteToEdit.StatusId;

            Priorities = [.. _priorityService.GetAll()];
            Statuses = [.. _statusService.GetAll()];

            EditCommand = new RelayCommand(Edit);
        }

        public List<Priority> Priorities { get; set; }
        public List<Status> Statuses { get; set; }
        public int SelectedPriorities { get; set; }
        public int SelectedStatuses { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? TextEdit { get; set; }
        public ICommand EditCommand { get; }

        private void Edit()
        {
            if (StartDate > EndDate)
            {
                MessageBox.Show("Błąd: Data rozpoczęcia musi być mniejsza niż data zakończenia.");
            }
            else
            {
                var newNote = new Note()
                {
                    ContentText = TextEdit,
                    StartDate = StartDate,
                    EndDate = EndDate,
                    PriorityId = SelectedPriorities,
                    StatusId = SelectedStatuses,
                };
                newNote.CreatedOn = true;
                _noteService.Edit(_noteToEdit, newNote);
                _dialogService.CloseDialog();
            }
        }
    }
}
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel.DataAnnotations;
using System.Windows.Input;
using ToDoListMVVM.Entities;
using ToDoListMVVM.Interface;
using ToDoListMVVM.Models;
using ToDoListMVVM.Validation;

namespace ToDoListMVVM.ViewModel
{
    public class EditViewModel : ObservableValidator
    {
        private readonly INoteService _noteService;
        private readonly IPriorityService _priorityService;
        private readonly IStatusService _statusService;
        private readonly IDialogService _dialogService;
        private readonly Note _noteToEdit;

        public EditViewModel(Note note)
        {
            _noteService = Ioc.Default.GetRequiredService<INoteService>();
            _priorityService = Ioc.Default.GetRequiredService<IPriorityService>();
            _statusService = Ioc.Default.GetRequiredService<IStatusService>();
            _dialogService = Ioc.Default.GetRequiredService<IDialogService>();

            _noteToEdit = note;
            TextNote = _noteToEdit.ContentText!;
            StartDate = _noteToEdit.StartDate;
            EndDate = _noteToEdit.EndDate;
            SelectedPriorities = _noteToEdit.PriorityId;
            SelectedStatuses = _noteToEdit.StatusId;

            Priorities = [.. _priorityService.GetAll()];
            Statuses = [.. _statusService.GetAll()];

            EditCommand = new RelayCommand(Edit);
        }

        public ICommand EditCommand { get; }
        public List<Priority> Priorities { get; set; }
        public List<Status> Statuses { get; set; }
        private DateTime _startDate;
        private DateTime _endDate;
        private string? _textNote;
        private int _selectedPriorities;
        private int _selectedStatuses;

        [Required(ErrorMessage = "Pole tekstowe jest wymagane.")]
        [MaxLength(150, ErrorMessage = "Pole tekstowe nie może zawierać więcej niż 150 znaków.")]
        public string TextNote
        {
            get => _textNote!;
            set
            {
                SetProperty(ref _textNote, value);
                ValidateProperty(_textNote);
            }
        }

        public int SelectedPriorities
        {
            get => _selectedPriorities;
            set
            {
                SetProperty(ref _selectedPriorities, value);
                ValidateProperty(_selectedPriorities);
            }
        }

        public int SelectedStatuses
        {
            get => _selectedStatuses;
            set
            {
                SetProperty(ref _selectedStatuses, value);
                ValidateProperty(_selectedStatuses);
            }
        }

        [Required(ErrorMessage = "Proszę podać datę rozpoczęcia.")]
        public DateTime StartDate
        {
            get => _startDate;
            set
            {
                SetProperty(ref _startDate, value);
                ValidateProperty(_startDate);
            }
        }

        [Required(ErrorMessage = "Proszę podać datę zakończenia.")]
        [CustomValidation(typeof(ValidationDate), nameof(ValidationDate.ValidateEndDate))]
        public DateTime EndDate
        {
            get => _endDate;
            set
            {
                SetProperty(ref _endDate, value);
                ValidateProperty(_endDate);
            }
        }

        private void Edit()
        {
            if (HasErrors)

            {
                return;
            }
            var newNote = new Note()
            {
                ContentText = TextNote,
                StartDate = StartDate,
                EndDate = EndDate,
                PriorityId = SelectedPriorities,
                StatusId = SelectedStatuses,
            };
            _noteService.Edit(_noteToEdit, newNote);
            _dialogService.CloseDialog();
        }
    }
}
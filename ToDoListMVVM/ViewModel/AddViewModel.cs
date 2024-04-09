using System.Windows;
using ToDoListMVVM.Models;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using ToDoListMVVM.Interface;
using ToDoListMVVM.Entities;
using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ToDoListMVVM.Validation;

namespace ToDoListMVVM.ViewModel
{
    public class AddViewModel : ObservableValidator
    {
        private readonly INoteService _noteService;
        private readonly IDialogService _dialogService;

        public AddViewModel(INoteService noteService,
            IPriorityService priorityService,
            IStatusService statusService,
            IDialogService dialogService)
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
        private int _selectedPriorities;
        private int _selectedStatuses;
        private DateTime _startDate = DateTime.Today;
        private DateTime _endDate = DateTime.Today;
        private string _textNote;

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
        [CustomValidation(typeof(ValidationForm), nameof(ValidationForm.ValidateEndDate))]
        public DateTime EndDate
        {
            get => _endDate;
            set
            {
                SetProperty(ref _endDate, value);
                ValidateProperty(_endDate);
            }
        }

        [Required(ErrorMessage = "Pole tekstowe jest wymagane.")]
        [MaxLength(150, ErrorMessage = "Pole tekstowe nie może zawierać więcej niż 150 znaków.")]
        public string TextNote
        {
            get => _textNote;
            set
            {
                SetProperty(ref _textNote, value);
                ValidateProperty(_textNote);
            }
        }

        //public static ValidationResult ValidateEndDate(DateTime endDate, ValidationContext context)

        //{
        //    if (context.ObjectInstance is AddViewModel addViewModel && addViewModel.StartDate > endDate)

        //    {
        //        return new ValidationResult("Data zakończenia musi być większa niż rozpoczęcia");
        //    }

        //    return ValidationResult.Success!;
        //}

        private void Add()
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
                StatusId = SelectedStatuses
            };
            _noteService.Add(newNote);
            _dialogService.CloseDialog();
        }
    }
}
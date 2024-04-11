using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ToDoListMVVM.Entities;
using ToDoListMVVM.Interface;

namespace ToDoListMVVM.ViewModel
{
    public class MainViewModel : ObservableObject
    {
        private readonly INoteService _noteService;
        private readonly IDialogService _dialogService;

        public MainViewModel(INoteService noteService, IDialogService dialogService)
        {
            _noteService = noteService;
            _dialogService = dialogService;
            _noteService.NoteAdded += OnNoteAdded;
            _noteService.NoteDeleted += OnNoteDeleted;
            _noteService.NoteEdited += OnNoteEdited;

            ExitCommand = new RelayCommand(ExitApplication);
            AddNoteComand = new RelayCommand(Add);
            DeleteCommand = new RelayCommand(Delete);
            EditCommand = new RelayCommand(Edit);

            LoadNotes();
        }

        public ICommand ExitCommand { get; }
        public ICommand AddNoteComand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand EditCommand { get; }
        public NoteViewModel? SelectedItem { get; set; }

        public ObservableCollection<NoteViewModel> CollectionList { get; set; } = [];

        private void ExitApplication()
        {
            Application.Current.Shutdown();
        }

        private void Add()
        {
            _dialogService.ShowAdd();
        }

        private void OnNoteAdded(object? sender, Note note)
        {
            CollectionList.Add(CreateNoteVm(note));
        }

        private void Delete()
        {
            if (SelectedItem is null)
            {
                return;
            }
            _noteService.Remove(SelectedItem.Id);
        }

        private void OnNoteDeleted(object? sender, int id)
        {
            var noteToRemove = CollectionList.FirstOrDefault(x => x.Id == id);
            if (noteToRemove is null)
            {
                return;
            }

            CollectionList.Remove(noteToRemove);
        }

        private void Edit()
        {
            if (SelectedItem is null)
            {
                return;
            }

            _dialogService.ShowEdit(SelectedItem.Note);
        }

        private void OnNoteEdited(object? sender, Note note)
        {
            var noteToUpdate = CollectionList.FirstOrDefault(x => x.Id == note.Id);
            if (noteToUpdate is null)
            {
                return;
            }

            noteToUpdate.Update(note);
        }

        private void LoadNotes()
        {
            var notes = _noteService.GetAll();
            var noteVms = new List<NoteViewModel>();

            foreach (var note in notes)
            {
                noteVms.Add(CreateNoteVm(note));
            }

            CollectionList = new ObservableCollection<NoteViewModel>(noteVms);
        }

        private static NoteViewModel CreateNoteVm(Note note)
        {
            return new NoteViewModel(note);
        }
    }
}
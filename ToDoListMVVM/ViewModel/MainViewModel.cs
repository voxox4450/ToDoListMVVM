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

            ExitCommand = new RelayCommand(ExitApplication);
            AddNoteComand = new RelayCommand(Add);
            DeleteCommand = new RelayCommand(DeletePage);
            EditCommand = new RelayCommand(EditPage);

            CollectionList = new ObservableCollection<Note>(_noteService.GetAll());
            _dialogService = dialogService;
        }

        public ICommand ExitCommand { get; }
        public ICommand AddNoteComand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand EditCommand { get; }
        public Note? SelectedItem { get; set; }
        public ObservableCollection<Note> CollectionList { get; set; }

        private void ExitApplication()
        {
            Application.Current.Shutdown();
        }

        private void Add()
        {
            _dialogService.ShowAdd();
            CollectionList.Clear();
            foreach (var note in _noteService.GetAll())
            {
                CollectionList.Add(note);
            }
        }

        private void DeletePage()
        {
            if (SelectedItem is null)
            {
                return;
            }
            _noteService.Remove(SelectedItem);
            CollectionList.Remove(SelectedItem);
        }

        private void EditPage()
        {
            if (SelectedItem is null)
            {
                return;
            }

            int selectedIndex = CollectionList.IndexOf(SelectedItem);

            _dialogService.ShowEdit(SelectedItem);

            Note OldNote = SelectedItem;
            CollectionList.Remove(OldNote);
            CollectionList.Insert(selectedIndex, OldNote);
        }
    }
}
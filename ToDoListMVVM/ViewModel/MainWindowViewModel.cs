using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using ToDoListMVVM.Interface;
using ToDoListMVVM.Models;
using ToDoListMVVM.Services;
using ToDoListMVVM.Views;

namespace ToDoListMVVM.ViewModel
{
    public class MainWindowViewModel : ObservableObject
    {
        public MainWindowViewModel(INoteService noteService)
        {
            _noteService = noteService;
            ExitCommand = new RelayCommand(ExitApplication);
            AddNoteComand = new RelayCommand(NextPage);
            DeleteCommand = new RelayCommand(DeletePage);
            EditCommand = new RelayCommand(EditPage);
            CollectionList = new ObservableCollection<Note>(_noteService.GetAll());
        }

        private readonly INoteService _noteService;

        public ICommand ExitCommand { get; }
        public ICommand AddNoteComand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand EditCommand { get; }
        public Note SelectedItem { get; set; }

        public ObservableCollection<Note> CollectionList { get; set; }

        private void ExitApplication()
        {
            Application.Current.Shutdown();
        }

        private void NextPage()
        {
            _noteService.ShowAdd();
            refresh();
        }

        private void DeletePage()
        {
            if (SelectedItem != null)
            {
                _noteService.Remove(SelectedItem);
                refresh();
            }
        }

        private void EditPage()
        {
            if (SelectedItem != null)
            {
                _noteService.ShowEdit(SelectedItem);
                refresh();
            }
        }

        private void refresh()
        {
            CollectionList.Clear();
            foreach (var note in _noteService.GetAll())
            {
                CollectionList.Add(note);
            }
        }
    }
}
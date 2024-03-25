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
            CollectionList = new ObservableCollection<Note>(_noteService.GetAll());
        }

        private readonly INoteService _noteService;
        public ICommand ExitCommand { get; }

        public ObservableCollection<Note> CollectionList { get; set; }
        public ICommand AddNoteComand { get; }

        private void ExitApplication()
        {
            Application.Current.Shutdown();
        }

        private void NextPage()
        {
            _noteService.ShowDialog();
            CollectionList.Clear();
            foreach (var note in _noteService.GetAll())
            {
                CollectionList.Add(note);
            }
        }
    }
}
using System.Windows;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using ToDoListMVVM.Interface;
using ToDoListMVVM.Services;
using ToDoListMVVM.Views;

namespace ToDoListMVVM.ViewModel
{
    public class MainWindowViewModel
    {
        private INoteService _addNote;
        public ICommand ExitCommand { get; }

        public ICommand AddNoteComand { get; }

        public MainWindowViewModel(INoteService addNote)
        {
            _addNote = addNote;
            ExitCommand = new RelayCommand(ExitApplication);
            AddNoteComand = new RelayCommand(NextPage);
        }

        private void ExitApplication()
        {
            Application.Current.Shutdown();
        }

        private void NextPage()
        {
            _addNote.ShowDialog();
        }

        private void CloseDialog()
        {
            _addNote.CloseDialog();
        }
    }
}
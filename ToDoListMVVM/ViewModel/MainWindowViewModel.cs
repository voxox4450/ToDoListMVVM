using System.Windows;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using ToDoListMVVM.Views;

namespace ToDoListMVVM.ViewModel
{
    public class MainWindowViewModel
    {
        private IDialogService _dialogService = new DialogsServices();
        public ICommand ExitCommand { get; }
        public ICommand AddNoteComand { get; }

        public MainWindowViewModel()

        {
            ExitCommand = new RelayCommand(ExitApplication);
            AddNoteComand = new RelayCommand(NextPage);
        }

        private void ExitApplication()
        {
            Application.Current.Shutdown();
        }

        private void NextPage()
        {
            _dialogService.ShowDialog();
        }
    }
}
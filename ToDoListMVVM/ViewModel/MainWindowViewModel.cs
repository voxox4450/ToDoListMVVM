using System.Windows;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using GalaSoft.MvvmLight.Messaging;

namespace ToDoListMVVM.ViewModel
{
    public class MainWindowViewModel
    {
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
        }
    }
}
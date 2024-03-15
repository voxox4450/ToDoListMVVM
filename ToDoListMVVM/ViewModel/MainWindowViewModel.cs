using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using ToDoListMVVM.Models;
using ToDoListMVVM.Views;
using Serilog;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ToDoListMVVM.Commands;

namespace ToDoListMVVM.ViewModel
{
    public class MainWindowViewModel
    {
        private UserControlAddViewModel userControlAdd;
        private UserControlEditViewModel userControlEdit;
        public ObservableCollection<Note> Notes1 { get; set; }
        public ICommand ShowWindowCommand { get; set; }

        public List<Priority> priorityList { get; set; } = Constants.GetPriorities();

        public List<Note> Notes { get; set; }

        public List<Status> statusList { get; set; } = Constants.GetStatuses();

        public MainWindowViewModel()
        {
            ShowWindowCommand = new RelayCommand(ShowWindow, CanShowWindow);
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .Enrich.WithProperty("DeviceName", Environment.MachineName)
                .WriteTo.File("logs.txt", rollingInterval: RollingInterval.Day, outputTemplate: "{Properties} {Timestamp:dd-MM-yyyy HH:mm:ss} [{Level:u3}] {Message:lj}{NewLine}")
                //.WriteTo.Debug(outputTemplate: "{Properties} {Timestamp:dd-MM-yyyy HH:mm:ss} [{Level:u3}] {Message:lj}{NewLine}")
                .CreateLogger();

            Log.Information("Włączono aplikację");

            userControlAdd = new UserControlAddViewModel(this);
            userControlEdit = new UserControlEditViewModel(this);
            using (var dbContext = new Database())
            {
                Notes = dbContext.GetNotesWithDetails();
            }
            listView.ItemsSource = Notes;
        }

        private bool CanShowWindow(object obj)
        {
            return true;
        }

        private void ShowWindow(object obj)
        {
            //show window
        }

        private void WindowClosed(object sender, EventArgs e)
        {
            Log.Information("Aplikacja została zamknięta.");
        }

        public void ButtonExit(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }

        public void Show()
        {
            MainMenu.Visibility = Visibility.Visible;
        }

        public void Hide()
        {
            MainMenu.Visibility = Visibility.Collapsed;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            Frame.Navigate(new UserControlAddViewModel(this));
        }

        private void DelButton_Click(object sender, RoutedEventArgs e)
        {
            if (listView.SelectedItem is Note delNote)
            {
                using (var dbContext = new Database())
                {
                    var noteToRemove = dbContext.Notes.FirstOrDefault(n => n.Id == delNote.Id);
                    if (noteToRemove != null)
                    {
                        dbContext.Notes.Remove(noteToRemove);
                        dbContext.SaveChanges();
                        Log.Information("Usunięto zadanie: {@name}", delNote);
                        Notes = dbContext.GetNotesWithDetails();
                    }
                    else
                    {
                        Log.Warning("Nie można znaleźć notatki do usunięcia w bazie danych.");
                    }
                }
            }
            else
            {
                Log.Warning("Zaznaczony obiekt nie jest obiektem klasy Note");
            }
            listView.ItemsSource = Notes;
        }

        private void EditButton_Click(Object sender, RoutedEventArgs e)
        {
            object EditNote = listView.SelectedItem;
            if (EditNote != null)
            {
                Frame.Navigate(new UserControlEditViewModel(this));
                Hide();
            }
            else
            {
                MessageBox.Show("Musisz wybrać element z listy", "Błąd");
                Log.Error("Nie wybrano elementu z listy");
            }
        }
    }
}
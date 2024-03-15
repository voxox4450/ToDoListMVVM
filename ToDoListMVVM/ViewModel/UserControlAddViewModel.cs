using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ToDoListMVVM.Models;

namespace ToDoListMVVM.ViewModel
{
    public class UserControlAddViewModel
    {
        public MainWindowViewModel MainWindow { get; set; }

        public UserControlAddViewModel(MainWindowViewModel mainWindow)
        {
            MainWindow = mainWindow;
            prio.ItemsSource = MainWindow.priorityList;
            status.ItemsSource = MainWindow.statusList;
        }

        public void Show()
        {
            AddControl.Visibility = Visibility.Visible;
        }

        public void Hide()
        {
            AddControl.Visibility = Visibility.Collapsed;
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            Hide();
            MainWindow.Show();
            string contentText = content.Text;
            DateTime EndDate = Convert.ToDateTime(end.SelectedDate);
            DateTime StartDate = Convert.ToDateTime(start.SelectedDate);
            int priorityInt = MainWindow.priorityList.FindIndex(x => x.Name == prio.Text);
            int statusInt = MainWindow.statusList.FindIndex(x => x.Name == status.Text);
            if (EndDate < DateTime.Now && StartDate < EndDate)
            {
                statusInt = 0;
            }
            if (DateTime.Compare(StartDate, EndDate) >= 0)
            {
                MessageBox.Show("Rozpoczecie musi być większe niż zakończenie", "Błąd");
                Log.Error("Błąd wybrano błędną datę");
            }
            else
            {
                using (var dbContext = new Database())
                {
                    Note newNote = new Note()
                    {
                        ContentText = contentText,
                        EndDate = EndDate,
                        StartDate = StartDate,
                        PriorityId = priorityInt,
                        StatusId = statusInt
                    };
                    dbContext.AddRange(newNote);
                    dbContext.SaveChanges();
                    newNote.GetPriority();
                    newNote.GetStatus();
                    Log.Information("Dodano zadanie:{@name}", newNote);
                    MainWindow.Notes = dbContext.GetNotesWithDetails();
                    MainWindow.listView.ItemsSource = MainWindow.Notes;
                }
            }
        }
    }
}
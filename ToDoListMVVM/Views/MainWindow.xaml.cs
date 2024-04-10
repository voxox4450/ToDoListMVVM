using CommunityToolkit.Mvvm.DependencyInjection;
using System.ComponentModel;
using System.Windows;
using ToDoListMVVM.ViewModel;

namespace ToDoListMVVM.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = Ioc.Default.GetRequiredService<MainViewModel>();
            if (DataContext is INotifyPropertyChanged viewModel)
            {
                viewModel.PropertyChanged += PropertyChanged;
            }
        }

        private void PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(MainViewModel.CollectionList))
            {
                listView.Items.Refresh();
            }
        }
    }
}
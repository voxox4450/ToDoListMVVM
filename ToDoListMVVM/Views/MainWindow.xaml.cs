using CommunityToolkit.Mvvm.DependencyInjection;
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
            DataContext = Ioc.Default.GetRequiredService<MainWindowViewModel>();
        }
    }
}
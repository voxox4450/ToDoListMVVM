using CommunityToolkit.Mvvm.DependencyInjection;
using System.Windows.Controls;
using ToDoListMVVM.ViewModel;

namespace ToDoListMVVM.Views
{
    /// <summary>
    /// Interaction logic for UserControlAdd.xaml
    /// </summary>
    public partial class UserControlAdd : UserControl
    {
        public UserControlAdd()
        {
            InitializeComponent();
            DataContext = Ioc.Default.GetRequiredService<UserControlAddViewModel>();
        }
    }
}
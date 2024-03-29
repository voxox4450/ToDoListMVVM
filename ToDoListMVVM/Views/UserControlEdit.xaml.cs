using System.Windows.Controls;
using ToDoListMVVM.Models;
using ToDoListMVVM.ViewModel;

namespace ToDoListMVVM.Views
{
    /// <summary>
    /// Interaction logic for UserControlEdit.xaml
    /// </summary>
    public partial class UserControlEdit : UserControl
    {
        public UserControlEdit(Note note)
        {
            InitializeComponent();
            DataContext = new UserControlEditViewModel(note);
        }
    }
}
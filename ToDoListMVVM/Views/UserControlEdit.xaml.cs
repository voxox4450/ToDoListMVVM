using System.Windows.Controls;
using ToDoListMVVM.Entities;
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
            DataContext = new EditViewModel(note);
        }
    }
}
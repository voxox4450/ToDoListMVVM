
namespace ToDoListMVVM.ViewModel
{
    internal class OpenDialogMessage
    {
        private Type type;
        private string v;

        public OpenDialogMessage(Type type, string v)
        {
            this.type = type;
            this.v = v;
        }
    }
}
using ToDoListMVVM.Entities;

namespace ToDoListMVVM.Models
{
    public class Priority
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public ICollection<Note>? Notes { get; set; }
    }
}
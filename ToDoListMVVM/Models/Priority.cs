namespace ToDoListMVVM.Models
{
    public class Priority
    {
        public ICollection<Note>? Notes { get; set; }
        public int Id { get; set; }
        public string? Name { get; set; } = default(string);
    }
}
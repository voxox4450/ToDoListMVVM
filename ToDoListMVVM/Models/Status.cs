namespace ToDoListMVVM.Models
{
    public class Status
    {
        public ICollection<Note>? Notes { get; set; }
        public int Id { get; set; }
        public string? Name { get; set; } = default(string);
    }
}
namespace ToDoListMVVM.Entities
{
    public class Status
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public ICollection<Note>? Notes { get; set; }
    }
}
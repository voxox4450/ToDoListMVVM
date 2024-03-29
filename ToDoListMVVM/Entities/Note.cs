using ToDoListMVVM.Models;

namespace ToDoListMVVM.Entities
{
    public class Note
    {
        public int Id { get; set; }
        public string? ContentText { get; set; } = default;
        public DateTime EndDate { get; set; }
        public DateTime StartDate { get; set; }
        public int PriorityId { get; set; } = default;
        public int StatusId { get; set; } = default;

        //TODO: dodac CreatedOn
        //public bool CreatedOn { get; set; }

        public Priority? Priority { get; set; }
        public Status? Status { get; set; }
    }
}
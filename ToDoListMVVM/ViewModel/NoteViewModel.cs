using CommunityToolkit.Mvvm.ComponentModel;
using ToDoListMVVM.Entities;

namespace ToDoListMVVM.ViewModel
{
    public partial class NoteViewModel(
        Note note) : ObservableObject
    {
        public int Id { get; set; } = note.Id;

        [ObservableProperty]
        private string? _contentText = note.ContentText;

        [ObservableProperty]
        private DateTime _endDate = note.EndDate;

        [ObservableProperty]
        private DateTime _startDate = note.StartDate;

        [ObservableProperty]
        private int _priorityId = note.PriorityId;

        [ObservableProperty]
        private int _statusId = note.StatusId;

        [ObservableProperty]
        private string _priority = note.Priority?.Name ?? string.Empty;

        [ObservableProperty]
        private string _status = note.Status?.Name ?? string.Empty;

        public Note Note { get; private set; } = note;

        public void Update(Note note)
        {
            ContentText = note.ContentText;
            EndDate = note.EndDate;
            StartDate = note.StartDate;
            PriorityId = note.PriorityId;
            StatusId = note.StatusId;
            Priority = note.Priority?.Name ?? string.Empty;
            Status = note.Status?.Name ?? string.Empty;

            Note = note;
        }
    }
}
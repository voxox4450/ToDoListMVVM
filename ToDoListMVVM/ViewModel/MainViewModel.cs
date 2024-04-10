using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ToDoListMVVM.Entities;
using ToDoListMVVM.Interface;

namespace ToDoListMVVM.ViewModel
{
    public class MainViewModel : ObservableObject
    {
        private readonly INoteService _noteService;
        private readonly IDialogService _dialogService;

        public MainViewModel(INoteService noteService, IDialogService dialogService)
        {
            _noteService = noteService;
            _dialogService = dialogService;
            _noteService.NoteAdded += OnNoteAdded;
            _noteService.NoteDeleted += OnNoteDeleted;
            _noteService.NoteEdited += OnNoteEdited;

            ExitCommand = new RelayCommand(ExitApplication);
            AddNoteComand = new RelayCommand(Add);
            DeleteCommand = new RelayCommand(DeletePage);
            EditCommand = new RelayCommand(EditPage);

            CollectionList = new ObservableCollection<Note>(_noteService.GetAll());
        }

        public ICommand ExitCommand { get; }
        public ICommand AddNoteComand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand EditCommand { get; }
        public Note? SelectedItem { get; set; }

        public ObservableCollection<Note> CollectionList { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void ExitApplication()
        {
            Application.Current.Shutdown();
        }

        private void Add()
        {
            _dialogService.ShowAdd();
        }

        private void OnNoteAdded(object? sender, Note note)
        {
            CollectionList.Add(note);
        }

        private void DeletePage()
        {
            if (SelectedItem is null)
            {
                return;
            }
            _noteService.Remove(SelectedItem);
        }

        private void OnNoteDeleted(object? sender, Note note)
        {
            CollectionList.Remove(note);
        }

        private void EditPage()
        {
            if (SelectedItem is null)
            {
                return;
            }

            _dialogService.ShowEdit(SelectedItem);
        }

        private void OnNoteEdited(object? sender, Note note)
        {
            var index = CollectionList.IndexOf(CollectionList.FirstOrDefault(n => n.Id == note.Id));
            CollectionList[index].ContentText = note.ContentText;
            CollectionList[index].StartDate = note.StartDate;
            CollectionList[index].EndDate = note.EndDate;
            CollectionList[index].PriorityId = note.PriorityId;
            CollectionList[index].StatusId = note.StatusId;
            CollectionList[index].Priority = note.Priority;
            CollectionList[index].Status = note.Status;
            OnPropertyChanged(nameof(CollectionList));
        }
    }
}
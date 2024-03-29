﻿using System.Collections.ObjectModel;
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

        public MainViewModel(INoteService noteService)
        {
            _noteService = noteService;

            ExitCommand = new RelayCommand(ExitApplication);
            AddNoteComand = new RelayCommand(NextPage);
            DeleteCommand = new RelayCommand(DeletePage);
            EditCommand = new RelayCommand(EditPage);

            CollectionList = new ObservableCollection<Note>(_noteService.GetAll());
            _noteService = noteService;
        }

        public ICommand ExitCommand { get; }
        public ICommand AddNoteComand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand EditCommand { get; }
        public Note? SelectedItem { get; set; }
        public ObservableCollection<Note> CollectionList { get; set; }

        private void ExitApplication()
        {
            Application.Current.Shutdown();
        }

        private void NextPage()
        {
            _noteService.ShowAdd();
            Refresh();
        }

        private void DeletePage()
        {
            if (SelectedItem != null)
            {
                _noteService.Remove(SelectedItem);

                //TODO: nie pobieraj wszystkiego z bazy danych lecz usuwaj z listy ten usuniety
                Refresh();
            }
        }

        private void EditPage()
        {
            if (SelectedItem is null)
            {
                return;
            }

            _noteService.ShowEdit(SelectedItem);

            //TODO: nie pobieraj wszystkiego z bazy danych lecz odswiezaj ten element na interfejsie
            Refresh();
        }

        private void Refresh()
        {
            CollectionList.Clear();
            foreach (var note in _noteService.GetAll())
            {
                CollectionList.Add(note);
            }
        }
    }
}
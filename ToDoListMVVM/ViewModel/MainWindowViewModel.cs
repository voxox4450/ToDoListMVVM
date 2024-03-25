﻿using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using ToDoListMVVM.Interface;
using ToDoListMVVM.Models;
using ToDoListMVVM.Services;
using ToDoListMVVM.Views;

namespace ToDoListMVVM.ViewModel
{
    public class MainWindowViewModel : ObservableObject
    {
        public MainWindowViewModel(INoteService noteService)
        {
            _noteService = noteService;
            ExitCommand = new RelayCommand(ExitApplication);
            AddNoteComand = new RelayCommand(NextPage);
            DeleteCommand = new RelayCommand(DeletePage);
            CollectionList = new ObservableCollection<Note>(_noteService.GetAll());
        }

        private readonly INoteService _noteService;

        //private Note _selectedItem;
        public ICommand ExitCommand { get; }

        public ICommand AddNoteComand { get; }
        public ICommand DeleteCommand { get; }
        public Note SelectedItem { get; set; }

        public ObservableCollection<Note> CollectionList { get; set; }

        private void ExitApplication()
        {
            Application.Current.Shutdown();
        }

        private void NextPage()
        {
            _noteService.ShowDialog();
            CollectionList.Clear();
            foreach (var note in _noteService.GetAll())
            {
                CollectionList.Add(note);
            }
        }

        private void DeletePage()
        {
            _noteService.Remove(SelectedItem);
            CollectionList.Clear();
            foreach (var note in _noteService.GetAll())
            {
                CollectionList.Add(note);
            }
        }
    }
}
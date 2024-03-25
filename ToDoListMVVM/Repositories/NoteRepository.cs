using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListMVVM.Entities;
using ToDoListMVVM.Interface;
using ToDoListMVVM.Models;

namespace ToDoListMVVM.Repositories
{
    public class NoteRepository(AppDbContext appDbContext) : INoteRepository
    {
        private readonly AppDbContext _noteRepository = appDbContext;

        public void Add(Note noteToAdd)
        {
            _noteRepository.Add(noteToAdd);
            _noteRepository.SaveChanges();
        }

        public void Delete(Note noteToRemove)
        {
            _noteRepository.Remove(noteToRemove);
            _noteRepository.SaveChanges();
        }

        public void Update(Note noteToUpdate)
        {
            _noteRepository.Update(noteToUpdate);
            _noteRepository.SaveChanges();
        }

        public Note Find(int id)
        {
            return _noteRepository.Notes.First(x => x.Id == id);
        }

        public IEnumerable<Note> GetAll()
        {
            _noteRepository.ChangeTracker.LazyLoadingEnabled = false;
            return _noteRepository.Notes.Include(x => x.Priority).Include(x => x.Status).ToList();
        }
    }
}
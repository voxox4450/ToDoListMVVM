using Microsoft.EntityFrameworkCore;
using ToDoListMVVM.Entities;
using ToDoListMVVM.Interface;
using ToDoListMVVM.Models;

namespace ToDoListMVVM.Repositories
{
    public class NoteRepository(AppDbContext appDbContext) : INoteRepository
    {
        private readonly AppDbContext _appDbContext = appDbContext;

        public void Add(Note noteToAdd)
        {
            _appDbContext.Add(noteToAdd);
            _appDbContext.SaveChanges();
        }

        public void Delete(Note noteToRemove)
        {
            _appDbContext.Remove(noteToRemove);
            _appDbContext.SaveChanges();
        }

        public void Update(Note noteToUpdate)
        {
            _appDbContext.Update(noteToUpdate);
            _appDbContext.SaveChanges();
        }

        public IEnumerable<Note> GetAll()
        {
            return _appDbContext.Notes
                .Include(x => x.Priority)
                .Include(x => x.Status);
        }

        public Note? Get(int noteId)
        {
            return _appDbContext.Notes
                .Include(x => x.Priority)
                .Include(x => x.Status)
                .FirstOrDefault(x => x.Id == noteId);
        }
    }
}
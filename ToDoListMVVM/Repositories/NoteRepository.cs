using Microsoft.EntityFrameworkCore;
using ToDoListMVVM.Entities;
using ToDoListMVVM.Interface;
using ToDoListMVVM.Models;

namespace ToDoListMVVM.Repositories
{
    public class NoteRepository(AppDbContext appDbContext) : INoteRepository
    {
        private readonly AppDbContext _appDbContext = appDbContext;

        public void Add(Note note)
        {
            _appDbContext.Add(note);
            _appDbContext.SaveChanges();
        }

        public void Delete(Note note)
        {
            _appDbContext.Remove(note);
            _appDbContext.SaveChanges();
        }

        public void Update(Note note)
        {
            _appDbContext.Update(note);
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
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
    internal class StatusRepository(AppDbContext appDbContext) : IStatusRepository
    {
        private readonly AppDbContext _noteRepository = appDbContext;

        public IEnumerable<Status> GetAll()
        {
            _noteRepository.ChangeTracker.LazyLoadingEnabled = false;
            return [.. _noteRepository.Statuses];
        }
    }
}
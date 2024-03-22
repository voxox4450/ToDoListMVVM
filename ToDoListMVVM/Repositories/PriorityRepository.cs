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
    internal class PriorityRepository(AppDbContext appDbContext) : IPriorityRepository
    {
        private readonly AppDbContext _noteRepository = appDbContext;

        public IEnumerable<Priority> GetAll()
        {
            _noteRepository.ChangeTracker.LazyLoadingEnabled = false;
            return [.. _noteRepository.Priorities];
        }
    }
}
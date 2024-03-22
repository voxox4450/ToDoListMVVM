using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListMVVM.Entities;
using ToDoListMVVM.Interface;
using ToDoListMVVM.Models;
using ToDoListMVVM.Repositories;

namespace ToDoListMVVM.Services
{
    internal class StatusService(IStatusRepository statusRepository) : IStatusService
    {
        private readonly IStatusRepository _statusRepository = statusRepository;

        public IEnumerable<Status> GetAll()
        {
            return _statusRepository.GetAll();
        }
    }
}
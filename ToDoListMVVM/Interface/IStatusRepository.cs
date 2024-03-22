using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListMVVM.Models;

namespace ToDoListMVVM.Interface
{
    public interface IStatusRepository
    {
        IEnumerable<Status> GetAll();
    }
}
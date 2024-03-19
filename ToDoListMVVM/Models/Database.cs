using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListMVVM.Models
{
    public class Database
    {
        public DbSet<Note>? Notes { get; set; }
        public DbSet<Status>? Statuses { get; set; }
        public DbSet<Priority>? Priorities { get; set; }
    }
}
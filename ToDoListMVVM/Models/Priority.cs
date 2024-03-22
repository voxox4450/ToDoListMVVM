using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListMVVM.Models
{
    public class Priority
    {
        public ICollection<Note>? Notes { get; set; }
        public int Id { get; set; }
        public string? Name { get; set; } = default(string);
    }
}
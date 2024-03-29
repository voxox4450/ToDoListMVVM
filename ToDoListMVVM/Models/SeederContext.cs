//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ToDoListMVVM.Models
//{
//    public class SeederContext
//    {
//        public SeederContext()
//        {
//        }

//        private void SeedPriorities(AppDbContext dbContext)
//        {
//            var priorities = new List<Priority>()
//            {
//                new Priority { Id = 0, Name = "Wysoki" },
//                new Priority { Id = 1, Name = "Średni" },
//                new Priority { Id = 2, Name = "Niski" }
//            };

//            if (!dbContext.Priorities.Any())
//            {
//                dbContext.AddRange(priorities);
//                dbContext.SaveChanges();
//            }
//        }

//        private void SeedStatuses(AppDbContext dbContext)
//        {
//            var statuses = new List<Status>()
//            {
//                new Status { Id = 0, Name = "Ukończono" },
//                new Status { Id = 1, Name = "Rozpoczęto" },
//                new Status { Id = 2, Name = "Dodano" }
//            };

//            if (!dbContext.Statuses.Any())
//            {
//                dbContext.AddRange(statuses);
//                dbContext.SaveChanges();
//            }
//        }
//    }
//}
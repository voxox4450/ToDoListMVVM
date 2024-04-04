using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using ToDoListMVVM.Entities;

namespace ToDoListMVVM.Models
{
    public class SeederContext(AppDbContext dbContext)
    {
        private readonly AppDbContext _dbContext = dbContext;

        public void SeedPriorities()
        {
            if (!_dbContext.Priorities.Any())
            {
                var priorytety = new List<Priority>()
                {
                    new Priority { Id = 0, Name = "Wysoki" },
                    new Priority { Id = 1, Name = "Średni" },
                    new Priority { Id = 2, Name = "Niski" }
                };

                _dbContext.AddRange(priorytety);
                _dbContext.SaveChanges();
            }
        }

        public void SeedStatuses()
        {
            if (!_dbContext.Statuses.Any())
            {
                var statusy = new List<Status>()
                {
                    new Status { Id = 0, Name = "Ukończono" },
                    new Status { Id = 1, Name = "Rozpoczęto" },
                    new Status { Id = 2, Name = "Dodano" }
                };

                _dbContext.AddRange(statusy);
                _dbContext.SaveChanges();
            }
        }
    }
}
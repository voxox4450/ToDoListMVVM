using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using ToDoListMVVM.Entities;

namespace ToDoListMVVM.Models
{
    public class SeederContext
    {
        private readonly AppDbContext _dbContext;

        public SeederContext()
        {
            using var scope = Ioc.Default.CreateScope();
            _dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            _dbContext.Database.EnsureCreated();
            GetPriorities();
            GetStatuses();
        }

        private void GetPriorities()
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

        private void GetStatuses()
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
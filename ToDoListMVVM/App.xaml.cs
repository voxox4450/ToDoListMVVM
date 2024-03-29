using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System.Windows;
using ToDoListMVVM.Models;
using ToDoListMVVM.ViewModel;
using ToDoListMVVM.Interface;
using ToDoListMVVM.Services;
using Microsoft.EntityFrameworkCore;
using ToDoListMVVM.Repositories;
using ToDoListMVVM.Entities;

namespace ToDoListMVVM
{
    public partial class App : Application
    {
        public App()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            // TODO: przeniesc constring do pliku appsettings.json
            // mozliwosc przesylania migracji przestanie dzialac -> zastanowic sie jak to naprawic

            Ioc.Default.ConfigureServices(
                new ServiceCollection()
                .AddDbContext<AppDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")))
                .AddTransient<MainViewModel>()
                .AddTransient<AddViewModel>()
                .AddTransient<EditViewModel>()
                .AddScoped<INoteService, NoteService>()
                .AddScoped<INoteRepository, NoteRepository>()
                .AddScoped<IPriorityService, PriorityService>()
                .AddScoped<IPriorityRepository, PriorityRepository>()
                .AddScoped<IStatusService, StatusService>()
                .AddScoped<IStatusRepository, StatusRepository>()
                .BuildServiceProvider());

            //TODO: przeniesc seedowanie do nowej klasy, tutaj ją tylko wywołać
            using var scope = Ioc.Default.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            dbContext.Database.EnsureCreated();
            var priorities = new List<Priority>()
            {
                new(){ Id = 0, Name = "Wysoki" },
                new(){ Id = 1, Name = "Średni" },
                new(){ Id = 2, Name = "Niski" }
            };
            if (!dbContext.Priorities.Any())
            {
                dbContext.AddRange(priorities);
                dbContext.SaveChanges();
            }

            var statuses = new List<Status>()
            {
                new(){ Id = 0, Name = "Ukończono" },
                new(){ Id = 1, Name = "Rozpoczęto" },
                new(){ Id = 2, Name = "Dodano" },
            };
            if (!dbContext.Statuses.Any())
            {
                dbContext.AddRange(statuses);
                dbContext.SaveChanges();
            }
        }
    }
}
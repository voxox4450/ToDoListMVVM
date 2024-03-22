using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using System.IO;
using System.Windows;
using ToDoListMVVM.Models;
using ToDoListMVVM.ViewModel;
using ToDoListMVVM.Interface;
using ToDoListMVVM.Services;
using ToDoListMVVM;
using System;
using ToDoListMVVM.Entities;
using Microsoft.EntityFrameworkCore;
using ToDoListMVVM.Repositories;

namespace ToDoListMVVM
{
    public partial class App : Application
    {
        public App()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory());

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            Ioc.Default.ConfigureServices(
                new ServiceCollection()
                .AddDbContext<AppDbContext>(options => options.UseSqlServer("Server=ACARS-0099;User=sa;Password=praktyki;Database=myDb;Trust Server Certificate=True;"))
                .AddTransient<MainWindowViewModel>()
                .AddTransient<UserControlAddViewModel>()
                .AddSingleton<INoteService, NoteService>()
                .AddSingleton<INoteRepository, NoteRepository>()
                .BuildServiceProvider());

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
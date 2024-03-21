using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.IO;
using System.Windows;
using ToDoListMVVM.Models;
using ToDoListMVVM.ViewModel;
using ToDoListMVVM.Views;
using ToDoListMVVM.Interface;
using ToDoListMVVM.Services;
using ToDoListMVVM;
using Microsoft.EntityFrameworkCore;
using System;
using ToDoListMVVM.Entities;

namespace ToDoListMVVM
{
    public partial class App : Application
    {
        public IConfiguration Configuration { get; private set; }

        public App()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory());

            using var dbContext = new AppDbContext();

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
            Configuration = builder.Build();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            var options = new DbContextOptionsBuilder<Entities.AppDbContext>()
                .UseSqlServer(connectionString)
                .Options;
            Ioc.Default.ConfigureServices(
                new ServiceCollection()
                .AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString))
                .AddTransient<MainWindowViewModel>()
                .AddTransient<UserControlAddViewModel>()
                .AddSingleton<INoteService, NoteService>()
                .BuildServiceProvider());
        }
    }
}
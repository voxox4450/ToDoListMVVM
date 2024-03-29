﻿using CommunityToolkit.Mvvm.DependencyInjection;
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
                .SetBasePath(Directory.GetCurrentDirectory());
            //.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            // TODO: przeniesc constring do pliku appsettings.json
            // mozliwosc przesylania migracji przestanie dzialac -> zastanowic sie jak to naprawic

            Ioc.Default.ConfigureServices(
                new ServiceCollection()
                .AddDbContext<AppDbContext>(options => options
                    .UseSqlServer("Server=ACARS-0099;User=sa;Password=praktyki;Database=myDb;Trust Server Certificate=True;"))
                //.AddDbContext<AppDbContext>(options.UseSqlServer("Server=ACARS-0099;User=sa;Password=praktyki;Database=myDb;Trust Server Certificate=True;")
                //options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")))
                .AddTransient<MainViewModel>()
                .AddTransient<AddViewModel>()
                .AddTransient<EditViewModel>()
                .AddTransient<SeederContext>()
                .AddScoped<INoteService, NoteService>()
                .AddScoped<INoteRepository, NoteRepository>()
                .AddScoped<IPriorityService, PriorityService>()
                .AddScoped<IPriorityRepository, PriorityRepository>()
                .AddScoped<IStatusService, StatusService>()
                .AddScoped<IStatusRepository, StatusRepository>()
                .AddScoped<IDialogService, DialogService>()
                .BuildServiceProvider());
        }
    }
}
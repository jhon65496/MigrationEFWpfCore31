﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Diagnostics;
using MigrationEFWpfCore31.DALTest1.Entities;

namespace MigrationEFWpfCore31Test1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        public static IHost Host => CreateHostBuilder(Environment.GetCommandLineArgs()).Build();

        public static IServiceProvider Services => Host.Services;


        public App()
        {
            
        }


        public static IHostBuilder CreateHostBuilder(string[] args) => Microsoft.Extensions.Hosting.Host
                .CreateDefaultBuilder(args)
                .ConfigureServices(
                    (hostContext, services) => services
                       .AddDbContext<ContextDBBookinist>(opt =>
                       {
                           string path = Directory.GetCurrentDirectory();
                           string connectionString = hostContext.Configuration.GetConnectionString("DefaultConnection")
                           .Replace("[DataDirectory]", path);
                           // Debug.WriteLine("=== === === ===");                           
                           opt.UseSqlServer(connectionString);                           
                       } 
                    ));
        
        protected override async void OnStartup(StartupEventArgs e)
        {
            var host = Host;
            base.OnStartup(e);
            await host.StartAsync();

            
        }

    }
}

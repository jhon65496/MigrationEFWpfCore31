using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Diagnostics;
using MigrationEFWpfCore31.DAL.Entities;

namespace MigrationEFWpfCore31
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
                           // string connectionstr = hostContext.Configuration.GetValue<string>("Data:DefaultConnection:ConnectionString");
                           Debug.WriteLine("=== === === ===");
                           // Debug.WriteLine(connectionstr);
                           Debug.WriteLine("=== === === ===");
                          // string connectionstr2 = hostContext.Configuration.GetValue<string>("Data:DefaultConnection:ConnectionString");
                           string connectionString = hostContext.Configuration.GetConnectionString("DefaultConnection");

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

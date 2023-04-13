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
                           string connectionstr = hostContext.Configuration.GetConnectionString("ConnectionString");
                           Debug.WriteLine("=== === === ===");
                           Debug.WriteLine(connectionstr);
                           Debug.WriteLine("=== === === ===");

                           opt.UseSqlServer(hostContext.Configuration.GetConnectionString("ConnectionString"));
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

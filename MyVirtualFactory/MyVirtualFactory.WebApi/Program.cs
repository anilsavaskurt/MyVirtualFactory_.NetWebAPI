using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyVirtualFactory.Application.Interfaces.Repositories;
using MyVirtualFactory.Infrastructure.Identity;
using MyVirtualFactory.Infrastructure.Identity.Models;

namespace MyVirtualFactory.WebApi
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            //Read Configuration from appSettings
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            //Initialize Logger
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(config)
                .CreateLogger();
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();
                try
                {
                    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

                    await Infrastructure.Identity.Seeds.DefaultRoles.SeedAsync(userManager, roleManager);
                    await Infrastructure.Identity.Seeds.DefaultSuperAdmin.SeedAsync(userManager, roleManager);
                    await Infrastructure.Identity.Seeds.DefaultBasicUser.SeedAsync(userManager, roleManager);



                    var productRepository = services.GetRequiredService<IProductRepositoryAsync>();
                    var operationRepository = services.GetRequiredService<IOperationRepositoryAsync>();
                    var customerRepository = services.GetRequiredService<ICustomerRepositoryAsync>();
                    var orderItemRepository = services.GetRequiredService<IOrderItemRepositoryAsync>();
                    var orderRepository = services.GetRequiredService<IOrderRepositoryAsync>();
                    var subProductRepository = services.GetRequiredService<ISubProductTreeRepositoryAsync>();
                    var userRepository = services.GetRequiredService<IUserRepositoryAsync>();
                    var workCenterRepository = services.GetRequiredService<IWorkCenterRepositoryAsync>();
                    var workCenterOperationRepository = services.GetRequiredService<IWorkCenterOperationRepositoryAsync>();


                    await Infrastructure.Persistence.Seeds.SeedData.SeedAsync(operationRepository,customerRepository,
                        orderItemRepository, orderRepository, productRepository, subProductRepository, userRepository, workCenterRepository, workCenterOperationRepository);




                    Log.Information("Finished Seeding Default Data");
                    Log.Information("Application Starting");
                }
                catch (Exception ex)
                {
                    Log.Warning(ex, "An error occurred seeding the DB");
                }
                finally
                {
                    Log.CloseAndFlush();
                }
            }
            host.Run();
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseSerilog() //Uses Serilog instead of default .NET Logger
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

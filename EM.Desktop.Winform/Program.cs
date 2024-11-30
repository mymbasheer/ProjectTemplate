using EM.Desktop.Winform.Services;
using EM.Desktop.Winform.ViewModels;
using EM.Domain.Model;
using EM.Domain.Services;
using EM.Domain.Services.Common;
using EM.EF;
using EM.EF.Services;
using EM.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace EM.Desktop.Winform
{
    public class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static async Task Main()
        {
            // Set up the host (dependency injection container) and services
            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    // Register DbContext with connection string from app settings
                    var connectionString = hostContext.Configuration.GetConnectionString("SqlServer");
                    services.AddDbContext<EMDBContext>(options =>
                        options.UseSqlServer(connectionString));

                    // Register application services
                    services.AddScoped<IDataServices<District>, GenericDataServices<District>>();
                    services.AddScoped<IDistrict, DistrictServices>();

                    services.AddScoped<IDataServices<Employee>, GenericDataServices<Employee>>();
                    services.AddScoped<IEmployee, EmployeeServices>();

                    services.AddScoped<IUnitOfWork, UnitOfWork>();


                    // Register window service for form operations
                    services.AddSingleton<IWindowService, WindowService>(); // Register WindowService



                    // Register ViewModels
                    services.AddSingleton<MDIParentViewModel>();
                    services.AddTransient<DistrictViewModel>();
                    services.AddTransient<EmployeeViewModel>();



                    // Register main MDI parent form
                    services.AddSingleton<MDIParent>();

                    // Register forms
                    services.AddTransient<DistrictForm>();
                    services.AddTransient<EmployeeForm>();


                    // Optional: Add logging if you need it
                    services.AddLogging();

                })
                .Build();

            // Ensure database creation and apply migrations
            using (var scope = host.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<EMDBContext>();
                var loggerFactory = scope.ServiceProvider.GetRequiredService<ILoggerFactory>();
                var logger = loggerFactory.CreateLogger<Program>();

                try
                {
                    // Apply pending migrations or create the database if necessary
                    await dbContext.Database.MigrateAsync();
                    logger.LogInformation("Database migrations applied successfully.");
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "An error occurred while applying migrations.");
                    throw;  // You can handle this differently if needed
                }
            }

            // Run the Windows Forms app after setting up DI and database
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Resolve Form1 and pass the dependencies
            var mdiParent = host.Services.GetRequiredService<MDIParent>();
            Application.Run(mdiParent);
        }
    }
}

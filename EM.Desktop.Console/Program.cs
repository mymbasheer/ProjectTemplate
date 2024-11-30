using EM.Domain.Model;
using EM.Domain.Services;
using EM.Domain.Services.Common;
using EM.EF;
using EM.EF.Services;
using EM.Services;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

public class Program
{
    public static async Task Main(string[] args)
    {
        // Set up the host with DI container and services, including logging
        var host = Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                // Register DbContext and services
                services.AddDbContext<EMDBContext>(options =>
                    options.UseSqlServer(hostContext.Configuration.GetConnectionString("SqlServer")));

                // Register application services
                services.AddScoped<IDataServices<District>, GenericDataServices<District>>();
                services.AddScoped<IDistrict, DistrictServices>();

                services.AddScoped<IDataServices<Employee>, GenericDataServices<Employee>>();
                services.AddScoped<IEmployee, EmployeeServices>();

                services.AddScoped<IUnitOfWork, UnitOfWork>();

                // Register ViewModels
                services.AddTransient<DistrictViewModel>();
                services.AddTransient<EmployeeViewModel>();


                // Register logging
                services.AddLogging(configure => configure.AddConsole());
            })
            .Build();

        // Resolve the required services, including the logger
        var logger = host.Services.GetRequiredService<ILogger<Program>>();
        var dbContext = host.Services.GetRequiredService<EMDBContext>();
        var districtService = host.Services.GetRequiredService<IDistrict>();
        var employeeService = host.Services.GetRequiredService<IEmployee>();

        try
        {
            // Log an information message indicating that database migration is starting
            logger.LogInformation("Applying database migrations...");

            // Apply migrations and ensure the database is set up
            await dbContext.Database.MigrateAsync();

            // Log success message after migration
            logger.LogInformation("Database migrations applied successfully.");
        }
        catch (SqlException ex)
        {
            logger.LogError(ex, "SQL Error occurred during migration.");
            return;
        }
        catch (Exception ex)
        {
            // Log error message if something goes wrong
            logger.LogError(ex, "An unexpected error occurred during the database migration.");
            return;
        }

        var districtViewModel = new DistrictViewModel(districtService);
        var employeeViewModel = new EmployeeViewModel(employeeService);

        var consoleView = new ConsoleView(districtViewModel, employeeViewModel);

        consoleView.ShowMainMenu();
    }


}

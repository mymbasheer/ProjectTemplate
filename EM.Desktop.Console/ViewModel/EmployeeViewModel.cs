using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EM.Domain.Model;
using EM.Domain.Services;
using System.Collections.ObjectModel;

public partial class EmployeeViewModel : ObservableObject
{
    private readonly IEmployee _employeeService;

    // Constructor to inject the employee service
    public EmployeeViewModel(IEmployee employeeService)
    {
        _employeeService = employeeService;
    }

    // This method adds the employee, you can call this directly from the ConsoleView
    public async Task AddEmployeeAsync(string employeeName, DateTime dob, int districtId)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(employeeName))
            {
                // Show validation message if name is empty
                Console.WriteLine("Employee name cannot be empty.");
                return;
            }

            var employee = new Employee(employeeName, dob, districtId);
            await _employeeService.AddEmployee(employee);

            // Show success message
            Console.WriteLine($"Employee {employeeName} added successfully!");
        }
        catch (Exception ex)
        {
            // Handle errors
            Console.WriteLine($"Error adding employee: {ex.Message}");
        }
    }

    // Method to load the employee list
    [RelayCommand]
    public async Task LoadEmployeeAsync()
    {
        try
        {
            IsLoading = true; // Set loading state
            Employees = new ObservableCollection<Employee>(await _employeeService.ListEmployees());
        }
        catch (Exception ex)
        {
            // Handle errors
            Console.WriteLine($"Error loading employees: {ex.Message}");
        }
        finally
        {
            IsLoading = false; // Set loading state to false
        }
    }

    // Observable property for employees
    [ObservableProperty]
    private ObservableCollection<Employee> employees = [];

    // Observable property for loading state
    [ObservableProperty]
    private bool isLoading = false;
}

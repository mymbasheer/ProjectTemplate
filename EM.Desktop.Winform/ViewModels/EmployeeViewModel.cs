using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EM.Domain.Model;
using EM.Domain.Services;
using System.Collections.ObjectModel;

namespace EM.Desktop.Winform.ViewModels
{
    public partial class EmployeeViewModel(IEmployee employeeService, IDistrict districtService) : ObservableObject
    {
        private readonly IEmployee _employeeService = employeeService;
        private readonly IDistrict _districtService = districtService;

        // Command for adding an employee
        [RelayCommand]
        public async Task AddEmployeeAsync()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(EmployeeName))
                {
                    // You can show a validation message here (e.g., Name cannot be empty)
                    return;
                }

                var employee = new Employee(EmployeeName, DateOfBirth, SelectedDistrictId);
                await _employeeService.AddEmployee(employee);

                // Optionally, refresh the employee list or clear fields
                EmployeeName = string.Empty;
                DateOfBirth = DateTime.Now;
                SelectedDistrictId = 0;  // Reset selected district
            }
            catch (Exception ex)
            {
                // Handle errors
                // Optionally, add a property to show the error message in the View
                MessageBox.Show($"Error adding employee: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Command for loading the districts
        [RelayCommand]
        public async Task LoadDistrictsAsync()
        {
            try
            {
                IsLoading = true; // Set loading state to true
                Districts = new ObservableCollection<District>(await _districtService.ListDistricts());
            }
            catch (Exception ex)
            {
                // Handle errors in loading districts
                MessageBox.Show($"Error loading districts: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                IsLoading = false; // Set loading state to false
            }
        }

        [RelayCommand]
        public async Task LoadEmployeesAsync()
        {
            try
            {
                IsLoading = true; // Set loading state to true
                Employees = new ObservableCollection<Employee>(await _employeeService.ListEmployees());
            }
            catch (Exception ex)
            {
                // Handle errors in loading employees
                MessageBox.Show($"Error loading employees: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                IsLoading = false; // Set loading state to false
            }
        }

        // Properties for binding to the form controls
        [ObservableProperty]
        private string? employeeName;

        [ObservableProperty]
        private DateTime dateOfBirth = DateTime.Now;

        [ObservableProperty]
        private int selectedDistrictId;

        [ObservableProperty]
        private ObservableCollection<District> districts = [];

        [ObservableProperty]
        private ObservableCollection<Employee>? employees = [];

        [ObservableProperty]
        private bool isLoading = false;
    }
}

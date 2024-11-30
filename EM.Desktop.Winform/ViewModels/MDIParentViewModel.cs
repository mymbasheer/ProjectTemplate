using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EM.Desktop.Winform.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EM.Desktop.Winform.ViewModels
{
    public partial class MDIParentViewModel : ObservableObject
    {
        private readonly IWindowService _windowService;
        private readonly IServiceProvider _serviceProvider;  // Inject IServiceProvider to resolve forms

        // Inject IWindowService and IServiceProvider into the ViewModel
        public MDIParentViewModel(IWindowService windowService, IServiceProvider serviceProvider)
        {
            _windowService = windowService;
            _serviceProvider = serviceProvider;
        }

        // Command to open the EmployeeForm
        [RelayCommand]
        public void OpenEmployeeForm()
        {
            try
            {
                // Resolve the form from DI container, which will provide the required dependencies
                var employeeForm = _serviceProvider.GetRequiredService<EmployeeForm>();
                _windowService.ShowForm(employeeForm);  // Use window service to show the form
            }
            catch (Exception ex)
            {
                _windowService.ShowMessage($"Error opening EmployeeForm: {ex.Message}");
            }
        }

        // Command to open the DistrictForm
        [RelayCommand]
        public void OpenDistrictForm()
        {
            try
            {
                // Resolve the form from DI container, which will provide the required dependencies
                var districtForm = _serviceProvider.GetRequiredService<DistrictForm>();
                _windowService.ShowForm(districtForm);  // Use window service to show the form
            }
            catch (Exception ex)
            {
                _windowService.ShowMessage($"Error opening DistrictForm: {ex.Message}");
            }
        }


    }
}

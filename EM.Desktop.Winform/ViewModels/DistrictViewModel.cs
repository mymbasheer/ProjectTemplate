using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EM.Domain.Model;
using EM.Domain.Services;
using System.Collections.ObjectModel;

namespace EM.Desktop.Winform.ViewModels
{
    public partial class DistrictViewModel : ObservableObject
    {
        private readonly IDistrict _districtService;

        // Constructor to inject the district service
        public DistrictViewModel(IDistrict districtService)
        {
            _districtService = districtService;
        }

        // Command for adding a district
        [RelayCommand]
        public async Task AddDistrictAsync()
        {
            if (string.IsNullOrEmpty(DistrictName))
            {
                // You can add validation or show a message here if the name is empty
                return;
            }

            var district = new District { Name = DistrictName };
            await _districtService.AddDistrict(district);

            // Reset the field or show a success message
            DistrictName = string.Empty;  // Reset after adding
            await LoadDistrictsAsync();  // Optionally refresh the list
        }

        // Command for loading the districts
        [RelayCommand]
        public async Task LoadDistrictsAsync()
        {
            // Load the districts and notify the form to refresh its UI
            var districtsList = await _districtService.ListDistricts();
            Districts = new ObservableCollection<District>(districtsList);
        }

        // Properties to bind to the form
        [ObservableProperty]
        private string? districtName;

        [ObservableProperty]
        private ObservableCollection<District> districts = [];
    }
}

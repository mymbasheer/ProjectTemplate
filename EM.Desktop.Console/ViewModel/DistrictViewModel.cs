using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EM.Domain.Model;
using EM.Domain.Services;
using System.Collections.ObjectModel;

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
    public async Task AddDistrictAsync(string districtName)
    {
        if (string.IsNullOrEmpty(districtName))
        {
            // Handle validation
            Console.WriteLine("District name cannot be empty.");
            return;
        }

        var district = new District(districtName);
        await _districtService.AddDistrict(district);

        Console.WriteLine($"District '{districtName}' added successfully.");
    }

    // Command for loading the districts
    [RelayCommand]
    public async Task LoadDistrictsAsync()
    {
        var districtsList = await _districtService.ListDistricts();
        Districts = new ObservableCollection<District>(districtsList);

    }

    [ObservableProperty]
    private ObservableCollection<District> districts = [];
}

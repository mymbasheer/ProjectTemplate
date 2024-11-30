public class ConsoleView
{
    private readonly DistrictViewModel districtViewModel;
    private readonly EmployeeViewModel employeeViewModel;

    public ConsoleView(DistrictViewModel districtViewModel, EmployeeViewModel employeeViewModel)
    {
        this.districtViewModel = districtViewModel;
        this.employeeViewModel = employeeViewModel;
    }

    public void ShowMainMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Please choose an option:");
            Console.WriteLine("1. District Menu");
            Console.WriteLine("2. Employee Menu");
            Console.WriteLine("3. Exit");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    _ = ShowDistrictMenuAsync();
                    break;
                case "2":
                    _ = ShowEmployeeMenuAsync();
                    break;
                case "3":
                    Console.WriteLine("Exiting program...");
                    return;
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }
        }
    }

    private async Task ShowDistrictMenuAsync()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("District Menu:");
            Console.WriteLine("1. Add New District");
            Console.WriteLine("2. List All Districts");
            Console.WriteLine("3. Back to Main Menu");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("Enter new district name:");
                    string? districtName = Console.ReadLine();
                    if (!string.IsNullOrEmpty(districtName))
                    {
                        await districtViewModel.AddDistrictAsync(districtName);
                    }
                    break;
                case "2":
                    Console.WriteLine("Listing all districts:");
                    await districtViewModel.LoadDistrictsAsync();

                    if (districtViewModel.Districts != null && districtViewModel.Districts.Any())
                    {
                        foreach (var district in districtViewModel.Districts)
                        {
                            Console.WriteLine($"ID: {district.ID}, Name: {district.Name}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No districts available.");
                    }
                    break;
                case "3":
                    return; // Go back to the main menu
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }

    private async Task ShowEmployeeMenuAsync()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Employee Menu:");
            Console.WriteLine("1. Add New Employee");
            Console.WriteLine("2. List All Employees");
            Console.WriteLine("3. Back to Main Menu");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("Enter employee name:");
                    string? employeeName = Console.ReadLine();

                    if (string.IsNullOrEmpty(employeeName))
                    {
                        Console.WriteLine("Employee name cannot be empty.");
                        break;
                    }

                    DateTime dob;
                    Console.WriteLine("Enter employee date of birth (yyyy-MM-dd):");
                    var dobInput = Console.ReadLine();
                    if (!DateTime.TryParse(dobInput, out dob))
                    {
                        Console.WriteLine("Invalid date format.");
                        break;
                    }

                    Console.WriteLine("Enter district ID:");
                    int districtID;
                    if (!int.TryParse(Console.ReadLine(), out districtID))
                    {
                        Console.WriteLine("Invalid district ID.");
                        break;
                    }

                    await employeeViewModel.AddEmployeeAsync(employeeName, dob, districtID);
                    break;
                case "2":
                    // Show the loaded employees (for the console view)
                    Console.WriteLine("List of available employees:");
                    await employeeViewModel.LoadEmployeeAsync();

                    if (employeeViewModel.Employees != null && employeeViewModel.Employees.Any())
                    {
                        foreach (var employee in employeeViewModel.Employees)
                        {
                            Console.WriteLine($"ID: {employee.Id}, Name: {employee.Name}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No employees available.");
                    }

                    break;
                case "3":
                    return; // Go back to the main menu
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }

}

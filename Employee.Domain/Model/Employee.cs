using System.ComponentModel.DataAnnotations;

namespace EM.Domain.Model;

public class Employee
{
    [Key]
    public int Id { get; set; }
    public string? Name { get; set; }
    public DateTime Dob { get; set; }
    public int DistrictId { get; set; }

    // Constructor to initialize required properties
    public Employee(string name, DateTime dob, int districtId)
    {
        Name = name;
        Dob = dob;
        DistrictId = districtId;
    }

    // Optionally, you can include a parameterless constructor if you need to use object initializer too
    public Employee()
    {
    }
}

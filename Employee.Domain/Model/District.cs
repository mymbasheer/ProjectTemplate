using System.ComponentModel.DataAnnotations;

namespace EM.Domain.Model;

public class District
{
    [Key]
    public int ID { get; set; }
    public string? Name { get; set; }

    public District(string name)
    {
        Name = name;
    }

    public District()
    {

    }
}

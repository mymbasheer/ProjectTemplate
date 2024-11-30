using EM.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace EM.EF;

public class EMDBContext : DbContext
{
    public EMDBContext()
    {

    }

    public EMDBContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<Employee>? Employees { get; set; }
    public DbSet<District>? Districts { get; set; }
}

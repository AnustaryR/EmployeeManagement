using EmployeeManagement.Areas.Identity.Data;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Data;

public class EmployeeManagementDBContext : IdentityDbContext<User>
{
    public EmployeeManagementDBContext(DbContextOptions<EmployeeManagementDBContext> options)
        : base(options)
    {
    }
    public DbSet<PhoneBook> PhoneBook { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}

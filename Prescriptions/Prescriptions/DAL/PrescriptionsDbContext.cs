using Microsoft.EntityFrameworkCore;
using Prescriptions.Models;

namespace Prescriptions.DAL;

public class PrescriptionsDbContext : DbContext
{
    
    public DbSet<Doctor> Doctors { get; set; }
    
    protected PrescriptionsDbContext()
    {
    }

    public PrescriptionsDbContext(DbContextOptions options) : base(options)
    {
    }
}
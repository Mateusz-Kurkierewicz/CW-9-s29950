using Microsoft.EntityFrameworkCore;

namespace Prescriptions.DAL;

public class PrescriptionsDbContext : DbContext
{
    protected PrescriptionsDbContext()
    {
    }

    public PrescriptionsDbContext(DbContextOptions options) : base(options)
    {
    }
}
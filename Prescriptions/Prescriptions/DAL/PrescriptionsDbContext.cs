using Microsoft.EntityFrameworkCore;
using Prescriptions.Models;

namespace Prescriptions.DAL;

public class PrescriptionsDbContext : DbContext
{
    
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Medicament> Medicaments { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<PrescriptionMedicament> PrescriptionMedicaments { get; set; }
    
    protected PrescriptionsDbContext()
    {
    }

    public PrescriptionsDbContext(DbContextOptions options) : base(options)
    {
    }
}
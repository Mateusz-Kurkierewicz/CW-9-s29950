using System.ComponentModel.DataAnnotations;

namespace Prescriptions.Models;

public class Doctor(int idDoctor, string firstName, string lastName, string email)
{
    [Key]
    public int IdDoctor { get; set; } = idDoctor;
    [MaxLength(100)]
    public string FirstName { get; set; } = firstName;
    [MaxLength(100)]
    public string LastName { get; set; } = lastName;
    [EmailAddress]
    [MaxLength(100)]
    public string Email { get; set; } = email;

    public virtual ICollection<Prescription> Prescriptions { get; set; } = null!;
}
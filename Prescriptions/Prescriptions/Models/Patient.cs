using System.ComponentModel.DataAnnotations;

namespace Prescriptions.Models;

public class Patient(int idPatient, string firstName, string lastName, DateTime birthDate)
{
    [Key]
    public int IdPatient { get; set; } = idPatient;
    [MaxLength(100)]
    public string FirstName { get; set; } = firstName;
    [MaxLength(100)]
    public string LastName { get; set; } = lastName;

    public DateTime BirthDate { get; set; } = birthDate;
    public virtual ICollection<Prescription> Prescriptions { get; set; } = null!;
}
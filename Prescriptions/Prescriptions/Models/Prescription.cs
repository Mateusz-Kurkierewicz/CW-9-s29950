using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prescriptions.Models;

public class Prescription(int idPrescription, DateTime date, DateTime dueDate, int idPatient, int idDoctor)
{
    [Key]
    public int IdPrescription { get; set; } = idPrescription;
    public DateTime Date { get; set; } = date;
    public DateTime DueDate { get; set; } = dueDate;
    public int IdPatient { get; set; } = idPatient;
    public int IdDoctor { get; set; } = idDoctor;
    [ForeignKey(nameof(IdPatient))]
    public Patient Patient { get; set; }
    [ForeignKey(nameof(IdDoctor))]
    public Doctor Doctor { get; set; }
}
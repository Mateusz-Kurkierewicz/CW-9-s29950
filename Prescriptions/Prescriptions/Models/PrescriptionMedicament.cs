using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prescriptions.Models;

[Table("Prescription_Medicament")]
public class PrescriptionMedicament(int idMedicament, int idPrescription, int dose, string details)
{
    public int IdMedicament { get; set; } = idMedicament;
    public int IdPrescription { get; set; } = idPrescription;
    public int? Dose { get; set; } = dose;
    [MaxLength(100)]
    public string Details { get; set; } = details;
    [ForeignKey(nameof(IdMedicament))]
    public Medicament Medicament { get; set; }
    [ForeignKey(nameof(IdPrescription))]
    public Prescription Prescription { get; set; }
}
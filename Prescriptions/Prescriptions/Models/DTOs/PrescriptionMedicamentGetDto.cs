namespace Prescriptions.Models.DTOs;

public class PrescriptionMedicamentGetDto
{
    public int IdMedicament { get; set; }
    public int IdPrescription { get; set; }
    public int? Dose { get; set; } = null!;
    public string Details { get; set; } = null!;
    public ICollection<MedicamentGetDto> Medicaments { get; set; } = null!;
}
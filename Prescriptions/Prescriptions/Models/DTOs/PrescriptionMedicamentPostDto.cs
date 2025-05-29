namespace Prescriptions.Models.DTOs;

public class PrescriptionMedicamentPostDto
{
    public int IdMedicament { get; set; }
    public int? Dose { get; set; }
    public string Details { get; set; } = null!;
}
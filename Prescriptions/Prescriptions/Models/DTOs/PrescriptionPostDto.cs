namespace Prescriptions.Models.DTOs;

public class PrescriptionPostDto
{
    public DateTime DueDate { get; set; }
    public int IdDoctor { get; set; }
    public ICollection<PrescriptionMedicamentPostDto> Medicaments { get; set; } = null!;
    public PatientPostDto Patient { get; set; } = null!;
}
namespace Prescriptions.Models.DTOs;

public class PrescriptionGetDto
{
    public int IdPrescription { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    public int IdPatient { get; set; }
    public int IdDoctor { get; set; }
    public ICollection<PrescriptionMedicamentGetDto> PrescriptionMedicaments { get; set; } = null!;
    public ICollection<DoctorGetDto> Doctors { get; set; } = null!;
}
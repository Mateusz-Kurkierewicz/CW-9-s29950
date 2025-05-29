namespace Prescriptions.Models.DTOs;

public class MedicamentGetDto
{
    public int IdMedicament { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Type { get; set; } = null!;
}
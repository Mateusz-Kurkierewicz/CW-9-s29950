using System.ComponentModel.DataAnnotations;

namespace Prescriptions.Models;

public class Medicament(int idMedicament, string name, string description, string type)
{
    [Key]
    public int IdMedicament { get; set; } = idMedicament;
    [MaxLength(100)]
    public string Name { get; set; } = name;
    [MaxLength(100)]
    public string Description { get; set; } = description;
    [MaxLength(100)]
    public string Type { get; set; } = type;
}
using Microsoft.EntityFrameworkCore;
using Prescriptions.DAL;
using Prescriptions.Exceptions;
using Prescriptions.Models.DTOs;

namespace Prescriptions.Services;

public class OrmService(PrescriptionsDbContext data) : IPrescriptionService
{
    public Task<int> AddPrescriptionAsync(PrescriptionPostDto request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<PatientGetDto> GetPatientAsync(int id, CancellationToken cancellationToken)
    {
        var result = await data.Patients.Select(p => new PatientGetDto
        {
            IdPatient = p.IdPatient,
            FirstName = p.FirstName,
            LastName = p.LastName,
            BirthDate = p.BirthDate,
            Prescriptions = p.Prescriptions.Select(pr => new PrescriptionGetDto
            {
                IdPrescription = pr.IdPrescription,
                Date = pr.Date,
                DueDate = pr.DueDate,
                Doctor = new DoctorGetDto
                {
                    IdDoctor = pr.Doctor.IdDoctor,
                    FirstName = pr.Doctor.FirstName,
                    LastName = pr.Doctor.LastName,
                    Email = pr.Doctor.Email
                },
                Medicaments = pr.PrescriptionMedicaments.Select(prm => new MedicamentGetDto
                {
                    IdMedicament = prm.Medicament.IdMedicament,
                    Name = prm.Medicament.Name,
                    Description = prm.Medicament.Description,
                    Type = prm.Medicament.Type
                }).ToList()
            }).OrderBy(o => o.DueDate).ToList()
        }).FirstOrDefaultAsync(s => s.IdPatient == id, cancellationToken);
        return result ?? throw new NotFoundException($"Nie odnaleziono pacjenta o id: {id}.");
    }
    
}
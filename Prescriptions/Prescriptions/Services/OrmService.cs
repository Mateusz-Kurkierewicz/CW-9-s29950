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

        }).FirstOrDefaultAsync(s => s.IdPatient == id, cancellationToken);
        return result ?? throw new NotFoundException($"Nie odnaleziono pacjenta o id: {id}.");
    }
    
}
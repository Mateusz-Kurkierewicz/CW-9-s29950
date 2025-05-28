using Prescriptions.Models.DTOs;

namespace Prescriptions.Services;

public class OrmService : IPrescriptionService
{
    public void AddPrescriptionAsync(PrescriptionPostDto request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<PatientGetDto> GetPatientAsync(string firstName, string lastName, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
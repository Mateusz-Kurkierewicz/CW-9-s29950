using Prescriptions.Models.DTOs;

namespace Prescriptions.Services;

public interface IPrescriptionService
{
    public Task AddPrescriptionAsync(PrescriptionPostDto request, CancellationToken cancellationToken);
    public Task<PatientGetDto> GetPatientAsync(string firstName, string lastName, CancellationToken cancellationToken);
}
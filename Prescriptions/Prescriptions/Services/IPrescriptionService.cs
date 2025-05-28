using Prescriptions.Models.DTOs;

namespace Prescriptions.Services;

public interface IPrescriptionService
{
    public void AddPrescriptionAsync(PrescriptionPostDto request, CancellationToken cancellationToken);
    public Task<PatientGetDto> GetPatientAsync(string firstName, string lastName, CancellationToken cancellationToken);
}
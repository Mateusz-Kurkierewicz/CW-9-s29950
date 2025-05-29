using Prescriptions.Models.DTOs;

namespace Prescriptions.Services;

public interface IPrescriptionService
{
    public Task<int> AddPrescriptionAsync(PrescriptionPostDto request, CancellationToken cancellationToken);
    public Task<PatientGetDto> GetPatientAsync(int id, CancellationToken cancellationToken);
}
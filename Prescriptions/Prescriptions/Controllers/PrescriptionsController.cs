using Microsoft.AspNetCore.Mvc;
using Prescriptions.Models.DTOs;
using Prescriptions.Services;

namespace Prescriptions.Controllers;

public class PrescriptionsController(IPrescriptionService service) : ControllerBase
{

    [HttpPost]
    public async Task<IActionResult> AddPrescription(PrescriptionPostDto request, CancellationToken cancellationToken)
    {
        service.AddPrescriptionAsync(request, cancellationToken);
        return Ok();
    }
    
}
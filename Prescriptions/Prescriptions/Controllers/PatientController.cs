using Microsoft.AspNetCore.Mvc;
using Prescriptions.Services;

namespace Prescriptions.Controllers;

[ApiController]
[Route("patients")]
public class PatientController(IPrescriptionService service) : ControllerBase
{

    [HttpGet]
    [Route("{firstName}/{lastName}")]
    public async Task<IActionResult> GetPatientPrescriptions(string firstName, string lastName, CancellationToken cancellationToken)
    {
        var result = await service.GetPatientAsync(firstName, lastName, cancellationToken);
        return Ok(result);
    }
    
}
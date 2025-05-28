using Microsoft.AspNetCore.Mvc;

namespace Prescriptions.Controllers;

[ApiController]
[Route("patients")]
public class PatientController : ControllerBase
{

    [HttpGet]
    [Route("{firstName}/{lastName}")]
    public async Task<IActionResult> GetPatientPrescriptions(string firstName, string lastName, CancellationToken cancellationToken)
    {

        return Ok();
    }
    
}
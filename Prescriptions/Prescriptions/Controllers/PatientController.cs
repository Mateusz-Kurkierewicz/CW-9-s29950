using Microsoft.AspNetCore.Mvc;
using Prescriptions.Exceptions;
using Prescriptions.Services;

namespace Prescriptions.Controllers;

[ApiController]
[Route("patients")]
public class PatientController(IPrescriptionService service) : ControllerBase
{

    [HttpGet]
    [Route("{id:int}")]
    public async Task<IActionResult> GetPatientPrescriptions([FromRoute]int id, CancellationToken cancellationToken)
    {
        try
        {
            var result = await service.GetPatientAsync(id, cancellationToken);
            return Ok(result);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
    
}
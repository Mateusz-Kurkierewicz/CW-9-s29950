using Microsoft.AspNetCore.Mvc;
using Prescriptions.Exceptions;
using Prescriptions.Models.DTOs;
using Prescriptions.Services;

namespace Prescriptions.Controllers;

public class PrescriptionsController(IPrescriptionService service) : ControllerBase
{

    [HttpPost]
    public async Task<IActionResult> AddPrescription(PrescriptionPostDto request, CancellationToken cancellationToken)
    {
        try
        {
            var result = service.AddPrescriptionAsync(request, cancellationToken);
            return Ok(result);
        }
        catch (NotFoundException e)
        {
            return BadRequest(e.Message);
        }
    }
    
}
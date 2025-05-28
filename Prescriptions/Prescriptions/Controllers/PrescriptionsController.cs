using Microsoft.AspNetCore.Mvc;
using Prescriptions.Models.DTOs;

namespace Prescriptions.Controllers;

public class PrescriptionsController : ControllerBase
{

    [HttpPost]
    public async Task<IActionResult> AddPrescription(PrescriptionCreateRequest request, CancellationToken cancellationToken)
    {
        return Ok();
    }
    
}
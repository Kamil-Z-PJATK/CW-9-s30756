using APBD_CW_4.Models;
using APBD_CW_4.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBD_CW_4.Controllers;

[ApiController]
[Route("[controller]")]
public class PatientController(IDbService service):ControllerBase
{
    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GestPatientAsync([FromRoute] int id)
    {
        var patient= await service.GetPatientAsync(id);
        return Ok(patient);
    }
}
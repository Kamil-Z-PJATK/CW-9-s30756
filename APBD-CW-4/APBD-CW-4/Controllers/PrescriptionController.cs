using APBD_CW_4.DTOs;
using APBD_CW_4.Models;
using APBD_CW_4.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBD_CW_4.Controllers;

[ApiController]
[Route("[controller]")]
public class PrescriptionController(IDbService service):ControllerBase
{
    public async Task<IActionResult> CreatePrescriptionAsync(PerscriptionCreateDTO prescription)
    {
        try
        {
            var result= await service.AddPerscriptionAsync(prescription);
            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
            throw;
        }
    }
}
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using zadanie11.Services;

namespace zadanie11.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PatientController :ControllerBase
{
    private readonly IPatientService _service;

    public PatientController(IPatientService service)
    {
        _service = service;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPatientDetails(int id)
    {
        var patient = await _service.GetPatientDetailsAsync(id);
        if (patient == null)
            return NotFound($"Patient with ID {id} not found.");

        return Ok(patient);
    }
}
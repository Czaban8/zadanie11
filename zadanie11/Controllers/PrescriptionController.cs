using Microsoft.AspNetCore.Mvc;
using zadanie11.DTOs;
using zadanie11.Services;

namespace zadanie11.Controllers;


[ApiController]
[Route("api/[controller]")]
public class PrescriptionController : ControllerBase
{
    private readonly IPrescriptionService _service;

    public PrescriptionController(IPrescriptionService service)
    {
        _service = service;
    }
    
    [HttpPost("{doctorId}")]
    public async Task<IActionResult> AddPrescription([FromBody] PrescriptionDTO dto, int doctorId)
    {
        try
        {
            var result = await _service.CreatePrescription(dto, doctorId);
            return CreatedAtAction(nameof(AddPrescription), new { id = result.PrescriptionId }, result);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VetConnectAPI.Models;
using VetConnectAPI.Data;

[ApiController]
[Route("api/[controller]")]
public class CitasController : ControllerBase
{
    private readonly ICitaService _citaService;

    public CitasController(ICitaService citaService)
    {
        _citaService = citaService;
    }

    [HttpGet]
    public async Task<IActionResult> GetCitas()
    {
        var citas = await _citaService.GetAllCitasAsync();
        return Ok(citas);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCita(int id)
    {
        var cita = await _citaService.GetCitaByIdAsync(id);
        if (cita == null) return NotFound();
        return Ok(cita);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCita([FromBody] Cita cita)
    {
        var newCita = await _citaService.CreateCitaAsync(cita);
return CreatedAtAction(nameof(GetCita), new { id = newCita.IdCita }, newCita);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCita(int id, [FromBody] Cita cita)
    {
        if (!await _citaService.UpdateCitaAsync(id, cita)) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCita(int id)
    {
        if (!await _citaService.DeleteCitaAsync(id)) return NotFound();
        return NoContent();
    }
}

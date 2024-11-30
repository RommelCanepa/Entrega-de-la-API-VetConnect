using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VetConnectAPI.Models;

[ApiController]
[Route("api/[controller]")]
public class MascotaController : ControllerBase
{
    private readonly IMascotaService _mascotaService;

    public MascotaController(IMascotaService mascotaService)
    {
        _mascotaService = mascotaService;
    }

    [HttpGet]
    public async Task<IActionResult> GetMascotas()
    {
        var mascotas = await _mascotaService.GetAllMascotasAsync();
        return Ok(mascotas);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetMascota(int id)
    {
        var mascota = await _mascotaService.GetMascotaByIdAsync(id);
        if (mascota == null) return NotFound();
        return Ok(mascota);
    }

    [HttpPost]
    public async Task<IActionResult> CreateMascota([FromBody] Mascota mascota)
    {
        var newMascota = await _mascotaService.CreateMascotaAsync(mascota);
        return CreatedAtAction(nameof(GetMascota), new { id = newMascota.IdMascota }, newMascota);  // Cambié a 'IdMascota'
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateMascota(int id, [FromBody] Mascota mascota)
    {
        if (!await _mascotaService.UpdateMascotaAsync(id, mascota)) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMascota(int id)
    {
        if (!await _mascotaService.DeleteMascotaAsync(id)) return NotFound();
        return NoContent();
    }
}

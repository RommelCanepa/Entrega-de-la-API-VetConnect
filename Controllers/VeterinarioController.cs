using Microsoft.AspNetCore.Mvc;
using VetConnectAPI.Models;
using System.Collections.Generic;
using System.Linq;

[ApiController]
[Route("api/[controller]")]
public class VeterinarioController : ControllerBase
{
    private readonly IVeterinarioService _veterinarioService;

    public VeterinarioController(IVeterinarioService veterinarioService)
    {
        _veterinarioService = veterinarioService;
    }

    [HttpGet]
    public async Task<IActionResult> GetVeterinarios()
    {
        var veterinarios = await _veterinarioService.GetAllVeterinariosAsync();
        return Ok(veterinarios);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetVeterinario(int id)
    {
        var veterinario = await _veterinarioService.GetVeterinarioByIdAsync(id);
        if (veterinario == null) return NotFound();
        return Ok(veterinario);
    }

    [HttpPost]
    public async Task<IActionResult> CreateVeterinario([FromBody] Veterinario veterinario)
    {
        var newVeterinario = await _veterinarioService.CreateVeterinarioAsync(veterinario);
        return CreatedAtAction(nameof(GetVeterinario), new { id = newVeterinario.IDVeterinario }, newVeterinario);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateVeterinario(int id, [FromBody] Veterinario veterinario)
    {
        if (!await _veterinarioService.UpdateVeterinarioAsync(id, veterinario)) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteVeterinario(int id)
    {
        if (!await _veterinarioService.DeleteVeterinarioAsync(id)) return NotFound();
        return NoContent();
    }
}

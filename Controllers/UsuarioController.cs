using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VetConnectAPI.Models;
using VetConnectAPI.Services;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;

    public UsuarioController(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    // Obtener todos los usuarios
    [HttpGet]
    public async Task<IActionResult> GetUsuarios()
    {
        var usuarios = await _usuarioService.GetAllUsuariosAsync();
        return Ok(usuarios);
    }

    // Obtener un usuario por su ID
    [HttpGet("{id}")]
    public async Task<IActionResult> GetUsuario(int id)
    {
        var usuario = await _usuarioService.GetUsuarioByIdAsync(id);
        if (usuario == null) return NotFound();
        return Ok(usuario);
    }

    // Crear un nuevo usuario
    [HttpPost]
    public async Task<IActionResult> CreateUsuario([FromBody] Usuario usuario)
    {
        var newUsuario = await _usuarioService.CreateUsuarioAsync(usuario);
        return CreatedAtAction(nameof(GetUsuario), new { id = newUsuario.IDUsuario }, newUsuario);
    }

    // Actualizar un usuario existente
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUsuario(int id, [FromBody] Usuario usuario)
    {
        if (!await _usuarioService.UpdateUsuarioAsync(id, usuario)) 
            return NotFound();
        return NoContent();
    }

    // Eliminar un usuario
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUsuario(int id)
    {
        if (!await _usuarioService.DeleteUsuarioAsync(id)) 
            return NotFound();
        return NoContent();
    }
}

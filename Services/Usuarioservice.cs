using VetConnectAPI.Services;
using Microsoft.EntityFrameworkCore;
using VetConnectAPI.Models;
using VetConnectAPI.Data;


public class UsuarioService : IUsuarioService
{
    private readonly VetConnectDbContext _context;

    public UsuarioService(VetConnectDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Usuario>> GetAllUsuariosAsync()
    {
        return await _context.Usuarios.ToListAsync();
    }

    public async Task<Usuario> GetUsuarioByIdAsync(int id)
    {
        return await _context.Usuarios.FindAsync(id);
    }

    public async Task<Usuario> CreateUsuarioAsync(Usuario usuario)
    {
        _context.Usuarios.Add(usuario);
        await _context.SaveChangesAsync();
        return usuario;
    }

    public async Task<bool> UpdateUsuarioAsync(int id, Usuario usuario)
    {
        if (id != usuario.IDUsuario) return false;

        _context.Entry(usuario).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteUsuarioAsync(int id)
    {
        var usuario = await _context.Usuarios.FindAsync(id);
        if (usuario == null) return false;

        _context.Usuarios.Remove(usuario);
        await _context.SaveChangesAsync();
        return true;
    }
}

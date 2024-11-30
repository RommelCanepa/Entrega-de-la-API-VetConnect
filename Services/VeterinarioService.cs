using Microsoft.EntityFrameworkCore;
using VetConnectAPI.Models;
using VetConnectAPI.Data;
public class VeterinarioService : IVeterinarioService
{
    private readonly VetConnectDbContext _context;

    public VeterinarioService(VetConnectDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Veterinario>> GetAllVeterinariosAsync()
    {
        return await _context.Veterinarios.ToListAsync();
    }

    public async Task<Veterinario> GetVeterinarioByIdAsync(int id)
    {
        return await _context.Veterinarios.FindAsync(id);
    }

    public async Task<Veterinario> CreateVeterinarioAsync(Veterinario veterinario)
    {
        _context.Veterinarios.Add(veterinario);
        await _context.SaveChangesAsync();
        return veterinario;
    }

    public async Task<bool> UpdateVeterinarioAsync(int id, Veterinario veterinario)
    {
        if (id != veterinario.IDVeterinario) return false;

        _context.Entry(veterinario).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteVeterinarioAsync(int id)
    {
        var veterinario = await _context.Veterinarios.FindAsync(id);
        if (veterinario == null) return false;

        _context.Veterinarios.Remove(veterinario);
        await _context.SaveChangesAsync();
        return true;
    }
}

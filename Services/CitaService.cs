using Microsoft.EntityFrameworkCore;
using VetConnectAPI.Models;
using VetConnectAPI.Data;

public class CitaService : ICitaService
{
    private readonly VetConnectDbContext _context;

    public CitaService(VetConnectDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Cita>> GetAllCitasAsync()
    {
        return await _context.Citas.Include(c => c.Mascota).Include(c => c.Veterinario).Include(c => c.Usuario).ToListAsync();
    }

    public async Task<Cita> GetCitaByIdAsync(int id)
    {
        return await _context.Citas
                             .Include(c => c.Mascota)
                             .Include(c => c.Veterinario)
                             .Include(c => c.Usuario)
                             .FirstOrDefaultAsync(c => c.IdCita == id);
    }

    public async Task<Cita> CreateCitaAsync(Cita cita)
    {
        _context.Citas.Add(cita);
        await _context.SaveChangesAsync();
        return cita;
    }

    public async Task<bool> UpdateCitaAsync(int id, Cita cita)
    {
        if (id != cita.IdCita) return false;

        _context.Entry(cita).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteCitaAsync(int id)
    {
        var cita = await _context.Citas.FindAsync(id);
        if (cita == null) return false;

        _context.Citas.Remove(cita);
        await _context.SaveChangesAsync();
        return true;
    }
}


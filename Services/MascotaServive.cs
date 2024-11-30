using Microsoft.EntityFrameworkCore;
using VetConnectAPI.Models;
using VetConnectAPI.Data;

public class MascotaService : IMascotaService
{
    private readonly VetConnectDbContext _context;

    public MascotaService(VetConnectDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Mascota>> GetAllMascotasAsync()
    {
        return await _context.Mascotas.ToListAsync();
    }

    public async Task<Mascota> GetMascotaByIdAsync(int id)
    {
        return await _context.Mascotas.FindAsync(id);
    }

    public async Task<Mascota> CreateMascotaAsync(Mascota mascota)
    {
        _context.Mascotas.Add(mascota);
        await _context.SaveChangesAsync();
        return mascota;
    }

    public async Task<bool> UpdateMascotaAsync(int id, Mascota mascota)
    {
        if (id != mascota.IdMascota) return false;

        _context.Entry(mascota).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteMascotaAsync(int id)
    {
        var mascota = await _context.Mascotas.FindAsync(id);
        if (mascota == null) return false;

        _context.Mascotas.Remove(mascota);
        await _context.SaveChangesAsync();
        return true;
    }
}

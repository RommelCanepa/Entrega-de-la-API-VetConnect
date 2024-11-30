using VetConnectAPI.Models;
public interface IMascotaService
{
    Task<IEnumerable<Mascota>> GetAllMascotasAsync();
    Task<Mascota> GetMascotaByIdAsync(int id);
    Task<Mascota> CreateMascotaAsync(Mascota mascota);
    Task<bool> UpdateMascotaAsync(int id, Mascota mascota);
    Task<bool> DeleteMascotaAsync(int id);
}


using VetConnectAPI.Models;
public interface ICitaService
{
    Task<IEnumerable<Cita>> GetAllCitasAsync();
    Task<Cita> GetCitaByIdAsync(int id);
    Task<Cita> CreateCitaAsync(Cita cita);
    Task<bool> UpdateCitaAsync(int id, Cita cita);
    Task<bool> DeleteCitaAsync(int id);
}


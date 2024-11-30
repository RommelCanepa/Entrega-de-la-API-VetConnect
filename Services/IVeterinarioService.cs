using Microsoft.EntityFrameworkCore;
using VetConnectAPI.Models;
public interface IVeterinarioService
{
    Task<IEnumerable<Veterinario>> GetAllVeterinariosAsync();
    Task<Veterinario> GetVeterinarioByIdAsync(int id);
    Task<Veterinario> CreateVeterinarioAsync(Veterinario veterinario);
    Task<bool> UpdateVeterinarioAsync(int id, Veterinario veterinario);
    Task<bool> DeleteVeterinarioAsync(int id);
}

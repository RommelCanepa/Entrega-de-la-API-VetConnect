using VetConnectAPI.Models;

namespace VetConnectAPI.Services
{
public interface IUsuarioService
{
    Task<IEnumerable<Usuario>> GetAllUsuariosAsync();
    Task<Usuario> GetUsuarioByIdAsync(int id);
    Task<Usuario> CreateUsuarioAsync(Usuario usuario);
    Task<bool> UpdateUsuarioAsync(int id, Usuario usuario);
    Task<bool> DeleteUsuarioAsync(int id);
}
}